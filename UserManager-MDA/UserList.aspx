<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="UserManager_MDA.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView CssClass="table thead-light table-hover m-2" ID="GridViewData" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="GridViewData_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="dni" HeaderText="DNI" />
            <asp:BoundField DataField="password" HeaderText="Password" />
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:BoundField DataField="surname" HeaderText="Surname" />
            <asp:BoundField DataField="category" HeaderText="Category" />
            <asp:BoundField DataField="rol" HeaderText="Rol" />
            <asp:BoundField DataField="information" HeaderText="Info" />
            <asp:TemplateField HeaderText="Edit" SortExpression="">
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-primary" ID="LinkButtonEdit" runat="server" CommandName="EditUser" CommandArgument='<%#Eval("id") %>'>Edit</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" SortExpression="">
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-danger" ID="LinkButtonDelete" runat="server" CommandName="DeleteUser" CommandArgument='<%#Eval("id") %>'>X</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
