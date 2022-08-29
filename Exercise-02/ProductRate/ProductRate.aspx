<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProtuctMasterPage.master" AutoEventWireup="true" CodeFile="ProductRate.aspx.cs" Inherits="ProductRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/ProductRate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conatiner">
        <div class="heading">
            Product Rate List
        </div>
        <div class="addBtn">
            <asp:Label ID="lblMessage" CssClass="lblMessageProductRate" runat="server"></asp:Label>
        </div>
        <div class="data">
            <asp:GridView ID="gvProductRate" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" OnRowCommand="gvProductRate_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" ItemStyle-Width="150px" HeaderText="Product Rate ID" />
                    <asp:BoundField DataField="Product_Name" ItemStyle-Width="250px" HeaderText="Product Name" />
                    <asp:BoundField DataField="Rate" ItemStyle-Width="200px" HeaderText="Rate" />
                    <asp:BoundField DataField="Date_Of_Rate" ItemStyle-Width="200px" HeaderText="Date Of Rate" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:ButtonField ButtonType="Button" CommandName="edi" ItemStyle-Width="100px" ControlStyle-CssClass="btn btn-info btn-sm" Text="Edit" HeaderText="Edit" />
                    <asp:ButtonField ButtonType="Button" CommandName="del" ItemStyle-Width="100px" ControlStyle-CssClass="btn btn-danger btn-sm" Text="Delete" HeaderText="Delete" />
                </Columns>
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
    </div>
</asp:Content>
