<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProtuctMasterPage.master" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/InvoiceCSS.css" rel="stylesheet" />
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conatiner">
        <div class="heading">
            <div class="invoiceHeading">
                Invoice<br />
            </div>
        </div>
        <div class="invoice">
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <table>
                <tr>
                    <td class="auto-style27">Party Name</td>
                    <td class="auto-style28">:</td>
                    <td class="auto-style29">
                        <asp:DropDownList ID="ddlPartyName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPartyName_SelectedIndexChanged" CssClass="form-select">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style29">
                        <asp:RequiredFieldValidator ID="rfvpartyName" runat="server" ControlToValidate="ddlPartyName" Display="Dynamic" ErrorMessage="* Select Party Name" ForeColor="Red" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Product Name</td>
                    <td class="auto-style25">:</td>
                    <td class="auto-style26">
                        <asp:DropDownList ID="ddlProductName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged" CssClass="form-select">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style26">
                        <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="ddlProductName" Display="Dynamic" ErrorMessage="* Select Product Name" ForeColor="Red" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style21">Rate</td>
                    <td class="auto-style22">:</td>
                    <td class="auto-style23">
                        <asp:TextBox ID="txtRate" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style23">
                        <asp:RequiredFieldValidator ID="rfvRate" runat="server" ControlToValidate="txtRate" Display="Dynamic" ErrorMessage="* Enter rate" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style18">Quantity</td>
                    <td class="auto-style19">:</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style20">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="* Enter Quantity" ForeColor="Red" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15"></td>
                    <td class="auto-style16"></td>
                    <td class="auto-style17">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="Add To Invoice" BackColor="#5CB85C" BorderStyle="None" ForeColor="White" OnClick="btnSubmit_Click" ValidationGroup="submit" />
                        <asp:Button ID="btnCloseInvoice" runat="server" CssClass="btn" BackColor="#D9534F" BorderStyle="None" ForeColor="White" Text="Close Invoice" OnClick="btnCloseInvoice_Click" />
                    </td>
                    <td class="auto-style17">&nbsp;</td>
                </tr>
            </table>
        </div>
        <div class="generatedInvoice">
            <asp:GridView ID="gvInvoice" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="100px" />
                    <asp:BoundField DataField="Party_Name" HeaderText="Party" ItemStyle-Width="200px" />
                    <asp:BoundField DataField="Product_Name" HeaderText="Product" ItemStyle-Width="200px" />
                    <asp:BoundField DataField="Current_Rate" HeaderText="Current Rate" ItemStyle-Width="250px" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-Width="200px" />
                    <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-Width="200px" />
                </Columns>
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
        <div class="Grand-total">
            <asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total : " Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>

