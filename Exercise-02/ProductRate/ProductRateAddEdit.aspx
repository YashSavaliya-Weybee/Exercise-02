<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProtuctMasterPage.master" AutoEventWireup="true" CodeFile="ProductRateAddEdit.aspx.cs" Inherits="ProductRate_ProductAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/ProductRateAddEdit.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <asp:Label ID="lblHeading" runat="server" Text="Add Product Rate" CssClass="heading"></asp:Label>
            <asp:ImageButton ID="imgBtnClose" runat="server" PostBackUrl="~/ProductRate/ProductRate.aspx" CssClass="close-icon" ImageUrl="~/images/close-icon.svg" />
        </div>
        <div class="Add-Edit">
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style23">Product Name</td>
                    <td class="auto-style26">:</td>
                    <td class="auto-style29">
                        <asp:DropDownList ID="ddlProductName" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style29">
                        <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="ddlProductName" Display="Dynamic" ErrorMessage="* Select Product" ForeColor="Red" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style23">Product Rate</td>
                    <td class="auto-style26">:</td>
                    <td class="auto-style29">
                        <asp:TextBox ID="txtProductRate" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style29">
                        <asp:RequiredFieldValidator ID="rfvProductRate" runat="server" ControlToValidate="txtProductRate" Display="Dynamic" ErrorMessage="* Enter Rate" ForeColor="#FF3300" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Date of Rate</td>
                    <td class="auto-style27">:</td>
                    <td class="auto-style30">
                        <asp:TextBox ID="txtDateOfRate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </td>
                    <td class="auto-style30">
                        <asp:RequiredFieldValidator ID="rfvDateOfRate" runat="server" ControlToValidate="txtDateOfRate" ErrorMessage="* Enter date of Rate" ForeColor="#FF3300" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style25"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style31">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-sm" BackColor="#5CB85C" BorderStyle="None" ForeColor="White" Text="Save" OnClick="btnSave_Click" ValidationGroup="submit" />
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-sm" Visible="false" BackColor="#5CB85C" BorderStyle="None" ForeColor="White" Text="Update" OnClick="btnUpdate_Click" ValidationGroup="submit" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" CssClass="btn btn-sm btn-light" runat="server" BorderStyle="None" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                    <td class="auto-style31">&nbsp;</td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>

