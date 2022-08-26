<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProtuctMasterPage.master" AutoEventWireup="true" CodeFile="PartyAddEdit.aspx.cs" Inherits="Party_PartyAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/PartyAddEdit.css" rel="stylesheet" />
<style type="text/css">
    .auto-style8 {
        width: 569px;
        margin-bottom: 34px;
    }
    .auto-style9 {
        height: 37px;
        width: 204px;
    }
    .auto-style10 {
        height: 63px;
        width: 204px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            Add Party
            <br />
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
            <br />
        </div>
        <div class="Add-Edit">

            <table class="auto-style8">
                <tr>
                    <td class="auto-style2">Party Name</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtPartyName" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="rfvPartyName" runat="server" ControlToValidate="txtPartyName" Display="Dynamic" ErrorMessage="* Enter Party Name" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style10">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-sm" BackColor="#5CB85C" BorderStyle="None" ForeColor="White" Text="Save" OnClick="btnSave_Click" ValidationGroup="submit" />
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-sm" Visible="false" BackColor="#5CB85C" BorderStyle="None" ForeColor="White" Text="Update" OnClick="btnUpdate_Click" ValidationGroup="submit" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-sm btn-light" BorderStyle="None" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                    <td class="auto-style7">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

