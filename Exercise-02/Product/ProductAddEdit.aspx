<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProtuctMasterPage.master" AutoEventWireup="true" CodeFile="ProductAddEdit.aspx.cs" Inherits="Product_ProductAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/ProductAddEdit.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <asp:Label ID="lblHeading" runat="server" Text="Add Product" CssClass="heading"></asp:Label>
            <asp:ImageButton ID="imgBtnClose" runat="server" PostBackUrl="~/Product/Product.aspx" CssClass="close-icon" ImageUrl="~/images/close-icon.svg" />
        </div>
        <div class="Add-Edit">
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label><br />
            <br />
            <table class="auto-style8">
                <tr>
                    <td class="auto-style10">Product Name</td>
                    <td class="auto-style11">:</td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtProductName" CssClass="auto-style9 form-control" runat="server" Width="301px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="txtProductName" Display="Dynamic" ErrorMessage="* Enter Product Name" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Rate</td>
                    <td class="auto-style11">:</td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtProductRate" CssClass="auto-style9 form-control" runat="server" Width="301px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        <asp:RequiredFieldValidator ID="rfvProductRate" runat="server" ControlToValidate="txtProductRate" Display="Dynamic" ErrorMessage="* Enter rate" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Date of Rate</td>
                    <td class="auto-style11">:</td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtdateOfRate" runat="server" CssClass="auto-style9 form-control" TextMode="Date" Width="301px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        <asp:RequiredFieldValidator ID="rfvDateOfRate" runat="server" ControlToValidate="txtdateOfRate" Display="Dynamic" ErrorMessage="* Select Date" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
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
                    <td class="auto-style7">&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

