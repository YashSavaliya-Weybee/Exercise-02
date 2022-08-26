using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Invoice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            fillDDLPartyName();
            ddlProductName.Items.Insert(0, new ListItem("Select Product", "-1"));
        }
    }
    private void fillDDLPartyName()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Party_SelectAll", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            ddlPartyName.DataSource = sdr;
            ddlPartyName.DataValueField = "ID";
            ddlPartyName.DataTextField = "Party_Name";
            ddlPartyName.DataBind();
            ddlPartyName.Items.Insert(0, new ListItem("Select Party", "-1"));
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void ddlPartyName_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Invoice_SelectForDDLProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyID", ddlPartyName.SelectedValue);
            SqlDataReader sdr = cmd.ExecuteReader();
            ddlProductName.DataSource = sdr;
            ddlProductName.DataValueField = "Product_ID";
            ddlProductName.DataTextField = "Product_Name";
            ddlProductName.DataBind();
            ddlProductName.Items.Insert(0, new ListItem("Select Product", "-1"));
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }
    protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ProductName = ddlProductName.SelectedItem.Text;
        SqlConnection conn = null;
        try
        {
            txtRate.Text = "";
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Invoice_SelectForTXTRate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", ddlProductName.SelectedValue);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                txtRate.Text = sdr["Rate"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Invoice_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyID", ddlPartyName.SelectedValue);
            cmd.Parameters.AddWithValue("@ProductID", ddlProductName.SelectedValue);
            cmd.Parameters.AddWithValue("@CurrentRate", txtRate.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@Total", Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtRate.Text));
            cmd.ExecuteNonQuery();

            ShowInvoice();

            GrandTotal();

            ddlPartyName.Enabled = false;
            ddlProductName.SelectedIndex = 0;
            txtRate.Text = "";
            txtQuantity.Text = "";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void btnCloseInvoice_Click(object sender, EventArgs e)
    {
        ddlPartyName.Enabled = true;
        gvInvoice.Visible = false;
        lblGrandTotal.Visible = false;
        ddlPartyName.SelectedIndex = 0;
        ddlProductName.SelectedIndex = 0;
        txtRate.Text = "";
        txtQuantity.Text = "";
    }

    protected void ShowInvoice()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Invoice_SelectByParty", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyID", ddlPartyName.SelectedValue);
            SqlDataReader sdr = cmd.ExecuteReader();
            gvInvoice.DataSource = sdr;
            gvInvoice.DataBind();
            gvInvoice.Visible = true;
            sdr.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void GrandTotal()
    {
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Excersice2"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("PR_Invoice_SelectForGrandTotal", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartyID", ddlPartyName.SelectedValue);
            SqlDataReader sdr1 = cmd.ExecuteReader();
            sdr1.Read();
            lblGrandTotal.Text = "Grand Total : ";
            lblGrandTotal.Text += sdr1["Grand_Total"];
            lblGrandTotal.Visible = true;
            sdr1.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }
}