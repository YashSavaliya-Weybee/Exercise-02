<%@ Page Title="" Language="C#" MasterPageFile="~/PartyProtuctMasterPage.master" AutoEventWireup="true" CodeFile="AssignParty.aspx.cs" Inherits="AssignParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="conatiner">
        <div class="heading">
            Assign Party List<br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="addBtn">
            <asp:Button ID="btnAddAssign" CssClass="btnAdd" runat="server" Text="Add New Assign" PostBackUrl="~/AssignParty/AssignAddEdit.aspx" />
        </div>
        <div class="data">
            <asp:GridView ID="gvAssignParty" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1000px" OnRowCommand="gvAssignParty_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Assign Party ID">
                        <ItemStyle Width="250px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Party_Name" HeaderText="Party Name">
                        <ItemStyle Width="275px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Product_Name" HeaderText="Product ID">
                        <ItemStyle Width="275px"></ItemStyle>
                    </asp:BoundField>
                    <asp:ButtonField CommandName="edi" ButtonType="Button" ItemStyle-Width="100px" ControlStyle-CssClass="btn btn-info btn-sm" HeaderText="Edit" Text="Edit" />
                    <asp:ButtonField CommandName="del" ButtonType="Button" ItemStyle-Width="100px" ControlStyle-CssClass="btn btn-danger btn-sm" HeaderText="Delete" Text="Delete" />
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

