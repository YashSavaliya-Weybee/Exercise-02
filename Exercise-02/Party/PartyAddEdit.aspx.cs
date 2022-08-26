using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Party_PartyAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                fillControlsParty();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Party_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyName", txtPartyName.Text.ToString());
            cmd.ExecuteNonQuery();
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Party " + txtPartyName.Text + " Added Successfully";
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
            txtPartyName.Text = "";
            txtPartyName.Focus();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Party/Party.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Party_UpdateByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyID", Request.QueryString["ID"]);
            cmd.Parameters.AddWithValue("@PartyName", txtPartyName.Text.ToString());
            cmd.ExecuteNonQuery();
            Response.Redirect("~/Party/Party.aspx", true);
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
    private void fillControlsParty()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Party_SelectByPK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyID", Request.QueryString["ID"]);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            txtPartyName.Text = sdr["Party_Name"].ToString();
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
}