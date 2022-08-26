using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        fillGridView();
    }

    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        GridViewRow gv = gvProduct.Rows[Convert.ToInt32(e.CommandArgument)];
        int id = Convert.ToInt32(gv.Cells[0].Text);
        string PName = gv.Cells[1].Text;
        if (e.CommandName == "edit")
        {
            Response.Redirect("~/Product/ProductAddEdit.aspx?ID=" + id);
        }
        if (e.CommandName == "del")
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("PR_Product_DeleteByPK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", id);
                cmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Product " + PName + " Deleted Sucessfully";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
                fillGridView();
            }
        }
    }
    private void fillGridView()
    {
        SqlConnection con = null;
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            SqlCommand cmd = new SqlCommand("PR_Product_SelectAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            gvProduct.DataSource = sdr;
            gvProduct.DataBind();
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
    }
}