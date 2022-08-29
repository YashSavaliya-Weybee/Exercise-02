using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product_ProductAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                fillControlsProduct();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string product = txtProductName.Text.ToString();
        Boolean flag = checkProduct(product);

        if (flag)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Product " + txtProductName.Text + " already exists, Please enter different product";
        }
        else
        {
            saveProdauct();
            saveProductRate(selectSavedProductForProductRate());
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Product/Product.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Product_UpdateByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
            cmd.Parameters.AddWithValue("@ProductID", Request.QueryString["ID"]);
            cmd.ExecuteNonQuery();
            Response.Redirect("~/Product/Product.aspx", true);
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
            txtProductName.Text = "";
            txtProductName.Focus();
        }
    }
    protected void fillControlsProduct()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Product_SelectByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", Request.QueryString["ID"]);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            txtProductName.Text = sdr["Product_Name"].ToString();
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
        btnSave.Visible = false;
        btnUpdate.Visible = true;
    }
    protected Boolean checkProduct(string product)
    {
        Boolean flag = false;
        SqlConnection con = null;
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("PR_Product_SelectAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (sdr.GetString(1).ToLower() == product.ToLower())
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            con.Close();
        }
        return flag;
    }

    protected void saveProdauct()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Product_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.ToString());
            cmd.ExecuteNonQuery();
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }
    protected int selectSavedProductForProductRate()
    {
        int productId = 0;
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Product_SelectAll", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                productId = sdr.GetInt32(0);
            }
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
        return productId;
    }

    protected void saveProductRate(int productId)
    {
        lblMessage.Text = "";
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_ProductRate_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productId);
            cmd.Parameters.AddWithValue("@Rate", Convert.ToInt32(txtProductRate.Text));
            cmd.Parameters.AddWithValue("@DateOFRate", Convert.ToDateTime(txtdateOfRate.Text).ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Product " + txtProductName.Text + " with rate " + txtProductRate.Text + " saved sucessfully";
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Enter valid date!";
        }
        finally
        {
            conn.Close();
            txtProductName.Text = "";
            txtProductRate.Text = "";
            txtdateOfRate.Text = "";
        }
    }
}