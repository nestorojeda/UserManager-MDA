<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserManager_MDA._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="userNotLoggedMessage" runat="server">
        <p>Es necesario iniciar sesión para poder acceder a la página</p>
    </div>
    <div id="userNotAdminMessage" runat="server">
        <p>Solo los usuarios con rol "Administrador" pueden acceder a la lista de usuarios y editarla</p>
    </div>
</asp:Content>
 