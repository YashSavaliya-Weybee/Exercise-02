using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductRate_ProductAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillDropdownProduct();
            if (Request.QueryString["id"] != null)
            {
                fillControlsProductRate();
            }
        }
    }
    private void fillDropdownProduct()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Product_SelectAll", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            ddlProductName.DataSource = sdr;
            ddlProductName.DataValueField = "ID";
            ddlProductName.DataTextField = "Product_Name";
            ddlProductName.DataBind();
            ddlProductName.Items.Insert(0, new ListItem("Select Product", "-1"));
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductRate/ProductRate.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int product = Convert.ToInt32(ddlProductName.SelectedValue);
        Boolean flag = checkProductRate(product);

        if (flag)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Rate already assigned to " + ddlProductName.SelectedItem.Text + ", please select another product";
        }
        else
        {
            lblMessage.Text = "";
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("PR_ProductRate_Insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", ddlProductName.SelectedValue);
                cmd.Parameters.AddWithValue("@Rate", Convert.ToInt32(txtProductRate.Text));
                cmd.Parameters.AddWithValue("@DateOFRate", Convert.ToDateTime(txtDateOfRate.Text).ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Rate of Product " + Convert.ToString(ddlProductName.SelectedItem.Text) + " Added Successfully";
                ddlProductName.SelectedIndex = 0;
                txtDateOfRate.Text = "";
                txtProductRate.Text = "";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Enter valid date!";
            }
            finally
            {
                conn.Close();
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_ProductRate_UpdateByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductRateID", Request.QueryString["id"]);
            cmd.Parameters.AddWithValue("@ProductID", ddlProductName.SelectedValue);
            cmd.Parameters.AddWithValue("@Rate", txtProductRate.Text);
            cmd.Parameters.AddWithValue("@DateOfRate", Convert.ToDateTime(txtDateOfRate.Text).ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
            Response.Redirect("~/ProductRate/ProductRate.aspx");
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

    protected void fillControlsProductRate()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_ProductRate_SelectByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductRateID", Request.QueryString["id"]);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            ddlProductName.SelectedValue = sdr["ID"].ToString();
            txtProductRate.Text = sdr["Rate"].ToString();
            txtDateOfRate.Text = Convert.ToDateTime(sdr["Date_Of_Rate"]).ToString("dd-MM-yyyy");
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
    protected Boolean checkProductRate(int product)
    {
        Boolean flag = true;
        SqlConnection con = null;
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("PR_ProductRate_SelectAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr.GetInt32(1) == product)
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
}