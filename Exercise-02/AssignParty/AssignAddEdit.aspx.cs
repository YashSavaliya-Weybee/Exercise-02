using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssignParty_AssignAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillDDLPartyName();
            fillDDLProductName();
            if (Request.QueryString["id"] != null)
            {
                fillControlsAssignParty();
            }
        }
    }
    private void fillDDLPartyName()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_AssignParty_SelectForDropDownListParty", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            ddlPartyName.DataSource = sdr;
            ddlPartyName.DataValueField = "ID";
            ddlPartyName.DataTextField = "Party_Name";
            ddlPartyName.DataBind();
            ddlPartyName.Items.Insert(0, new ListItem("Select Party", "-1"));
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
    private void fillDDLProductName()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_AssignParty_SelectForDropDownListProduct", conn);
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_AssignParty_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyID", Convert.ToString(ddlPartyName.SelectedValue));
            cmd.Parameters.AddWithValue("@ProductID", Convert.ToString(ddlProductName.SelectedValue));
            cmd.ExecuteNonQuery();
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Party " + Convert.ToString(ddlPartyName.SelectedItem.Text) + " assign to Product " + Convert.ToString(ddlProductName.SelectedItem.Text) + " Sucessfully";
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
            ddlPartyName.SelectedIndex = 0;
            ddlProductName.SelectedIndex = 0;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection con = null;
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            SqlCommand cmd = new SqlCommand("PR_AssignParty_UpdateByPK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AssignPartyID", Request.QueryString["id"]);
            cmd.Parameters.AddWithValue("@PartyID", Convert.ToString(ddlPartyName.SelectedValue));
            cmd.Parameters.AddWithValue("@ProductID", Convert.ToString(ddlProductName.SelectedValue));
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("~/AssignParty/AssignParty.aspx", true);
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AssignParty/AssignParty.aspx", true);
    }

    protected void fillControlsAssignParty()
    {
        SqlConnection con = null;
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("PR_AssignParty_SelectByPK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AssignPartyID", Request.QueryString["id"]);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            ddlPartyName.SelectedValue = sdr["Party_ID"].ToString();
            ddlProductName.SelectedValue = sdr["Product_ID"].ToString();
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
        btnSave.Visible = false;
        btnUpdate.Visible = true;
    }
}