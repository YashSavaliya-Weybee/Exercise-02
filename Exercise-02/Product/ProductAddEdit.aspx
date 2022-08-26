<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProtuctMasterPage.master" AutoEventWireup="true" CodeFile="ProductAddEdit.aspx.cs" Inherits="Product_ProductAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/ProductAddEdit.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style8 {
            width: 568px;
            margin-bottom: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            Add Product
            <br />
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
            <br />
        </div>
        <div class="Add-Edit">
            <table class="auto-style8">
                <tr>
                    <td class="auto-style2">Product Name</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtProductName" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="txtProductName" Display="Dynamic" ErrorMessage="* Enter Product Name" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style7">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-sm" BackColor="#5CB85C" BorderStyle="None" ForeColor="White" Text="Save" OnClick="btnSave_Click" ValidationGroup="submit" />
                        <asp:Button ID="btnUpdate" Visible="false" CssClass="btn btn-sm" runat="server" BackColor="#5CB85C" BorderStyle="None" ForeColor="White" Text="Update" OnClick="btnUpdate_Click" ValidationGroup="submit" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" CssClass="btn btn-sm btn-light" runat="server" BorderStyle="None" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                    <td class="auto-style7">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

