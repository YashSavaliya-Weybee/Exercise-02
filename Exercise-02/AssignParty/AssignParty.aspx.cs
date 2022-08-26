using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssignParty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillGridViewAssignParty();
        }
    }
    private void fillGridViewAssignParty()
    {
        SqlConnection con = null;
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            SqlCommand cmd = new SqlCommand("PR_AssignParty_SelectAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            gvAssignParty.DataSource = sdr;
            gvAssignParty.DataBind();
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

    protected void gvAssignParty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gv = gvAssignParty.Rows[Convert.ToInt32(e.CommandArgument)];
        int id = Convert.ToInt32(gv.Cells[0].Text);
        string PartyName = gv.Cells[1].Text;
        string ProductName = gv.Cells[2].Text;
        if (e.CommandName == "edi")
        {
            Response.Redirect("~/AssignParty/AssignAddEdit.aspx?id=" + id);
        }
        if (e.CommandName == "del")
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("PR_AssignParty_DeleteByPK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssignPartyID", id);
                cmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Party " + PartyName + " assign to Product " + ProductName + " deleted sucessfully";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
                fillGridViewAssignParty();
            }
        }
    }
}