<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProtuctMasterPage.master" AutoEventWireup="true" CodeFile="AssignAddEdit.aspx.cs" Inherits="AssignParty_AssignAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/AssignAddEdit.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <asp:Label ID="lblHeading" runat="server" Text="Add Assign Party" CssClass="heading"></asp:Label>
            <asp:ImageButton ID="imgBtnClose" runat="server" PostBackUrl="~/AssignParty/AssignParty.aspx" CssClass="close-icon" ImageUrl="~/images/close-icon.svg" />
        </div>
        <div class="Add-Edit">
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
            <br />
            <br />
            <table class="auto-style14">
                <tr>
                    <td class="auto-style18">Party Name</td>
                    <td class="auto-style9">:</td>
                    <td class="auto-style15">
                        <asp:DropDownList ID="ddlPartyName" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style10">
                        <asp:RequiredFieldValidator ID="rfvDDLPartyName" runat="server" ControlToValidate="ddlPartyName" Display="Dynamic" ErrorMessage="* Select Party Name" ForeColor="Red" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style19">Product Name</td>
                    <td class="auto-style12">:</td>
                    <td class="auto-style16">
                        <asp:DropDownList ID="ddlProductName" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style13">
                        <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="ddlProductName" Display="Dynamic" ErrorMessage="* Select Product Name" ForeColor="Red" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style17">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-sm" BackColor="#5CB85C" BorderStyle="None" ForeColor="White" Text="Save" OnClick="btnSave_Click" ValidationGroup="submit" />
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-sm" Visible="false" BackColor="#5CB85C" BorderStyle="None" ForeColor="White" Text="Update" OnClick="btnUpdate_Click" Style="height: 24px" ValidationGroup="submit" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" CssClass="btn btn-sm btn-light" runat="server" BorderStyle="None" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>

