using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        fillGridView();
    }
    //Excersice NEW
    protected void gvParty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gv = gvParty.Rows[Convert.ToInt32(e.CommandArgument)];
        int id = Convert.ToInt32(gv.Cells[0].Text);
        string PName = gv.Cells[1].Text;
        if (e.CommandName == "del")
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("PR_Party_DeleteByPK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartyID", id);
                cmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Party " + PName + " Deleted Sucessfully";
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
        if (e.CommandName == "edi")
        {
            lblMessage.Text = "";
            Response.Redirect("~/Party/PartyAddEdit.aspx?ID=" + id);
        }
    }

    private void fillGridView()
    {
        SqlConnection con = null;
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            SqlCommand cmd = new SqlCommand("PR_Party_SelectAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            gvParty.DataSource = sdr;
            gvParty.DataBind();
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