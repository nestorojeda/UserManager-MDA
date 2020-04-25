<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="UserManager_MDA.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="input-group row mx-0 align-items-center">
        <input class="form-control border-secondary py-2" type="search" id="searchWord" placeholder="Buscar" runat="server"/>
        <select class="form-control border-secondary py-2" id="CategorySelectInput" runat="server">
            <option>id</option>
            <option>dni</option>
            <option>name</option>
            <option>surname</option>
            <option>category</option>
            <option>rol</option>
        </select>
        <div class="input-group-append">
            <asp:Button ID="searchButton" class="btn btn-primary" Text="Buscar" runat="server" OnClick="search"/>
            <asp:Button ID="reset" class="btn btn-secondary" Text="Resetear" runat="server" OnClick="resetSearch"/>
        </div>
    </div>
    <div class="row mx-0">
        <asp:GridView CssClass="table thead-light table-hover my-2" ID="GridViewData" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="GridViewData_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="dni" HeaderText="DNI" />
                <asp:BoundField DataField="password" HeaderText="Password" />
                <asp:BoundField DataField="name" HeaderText="Nombre" />
                <asp:BoundField DataField="surname" HeaderText="Apellidos" />
                <asp:BoundField DataField="category" HeaderText="Categoría" />
                <asp:BoundField DataField="rol" HeaderText="Rol" />
                <asp:BoundField DataField="information" HeaderText="Info" />
                <asp:TemplateField HeaderText="Editar" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="btn btn-primary" ID="LinkButtonEdit" runat="server" CommandName="EditUser" CommandArgument='<%#Eval("id") %>'>Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="btn btn-danger" ID="LinkButtonDelete" runat="server" CommandName="DeleteUser" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('¿Desea eliminar este usuario?')">X</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
