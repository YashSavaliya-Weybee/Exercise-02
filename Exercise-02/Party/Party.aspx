<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProtuctMasterPage.master" AutoEventWireup="true" CodeFile="Party.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conatiner">
        <div class="heading">
            Party List<br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="addBtn">
            <asp:Button ID="btnAddParty" CssClass="btnAdd" runat="server" Text="Add New Party" PostBackUrl="~/Party/PartyAddEdit.aspx" />
        </div>
        <div class="data">

            <asp:GridView ID="gvParty" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" OnRowCommand="gvParty_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" ItemStyle-Width="150px" HeaderText="Party ID" />
                    <asp:BoundField DataField="Party_Name" ItemStyle-Width="650px" HeaderText="Party Name" />
                    <asp:ButtonField CommandName="edi" ButtonType="Button" ControlStyle-CssClass="btn btn-info btn-sm" ItemStyle-Width="100px" HeaderText="Edit" Text="Edit" />
                    <asp:ButtonField CommandName="del" ButtonType="Button" ControlStyle-CssClass="btn btn-danger btn-sm" ItemStyle-Width="100px" HeaderText="Delete" Text="Delete" />
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


