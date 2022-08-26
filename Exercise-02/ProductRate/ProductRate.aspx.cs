using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductRate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMessage.Text = "";
            fillGridViewProductRate();
        }
    }
    private void fillGridViewProductRate()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_ProductRate_SelectAll", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            gvProductRate.DataSource = sdr;
            gvProductRate.DataBind();
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

    protected void gvProductRate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = gvProductRate.Rows[Convert.ToInt32(e.CommandArgument)];
        int id = Convert.ToInt32(gvr.Cells[0].Text);
        string ProductName = gvr.Cells[1].Text;
        //string Rate = gvr.Cells[2].Text;
        //string dateOfRate = Convert.ToDateTime(gvr.Cells[3].Text).ToString("dd-MM-yyyy");
        try
        {
            if (e.CommandName == "edi")
            {
                Response.Redirect("~/ProductRate/ProductRateAddEdit.aspx?id=" + id);
            }
            if (e.CommandName == "del")
            {
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
                    conn.Open();
                    string query = "DELETE FROM PRODUCT_RATE WHERE ID=" + id;
                    SqlCommand cmd = new SqlCommand("PR_ProductRate_DeleteByPK", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductRateID", id);
                    cmd.ExecuteNonQuery();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Product rate of " + ProductName + " deleted sucessfully";
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = ex.Message.ToString();
                }
                finally
                {
                    conn.Close();
                    fillGridViewProductRate();
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message.ToString();
        }
    }
}