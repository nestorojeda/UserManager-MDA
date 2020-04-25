<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UserManager_MDA.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row min-vh-100 justify-content-center align-content-center">
        <div class="col-6 py-2" style="background-color: rgba(255, 140, 25,.3);">

              <div id="fail" class="alert alert-danger" role="alert" runat="server"></div>
            
              <div class="form-group row mx-0">
                <label for="DNIinput" class="col-12 p-0">Identificación</label>
                  <input type="text" id="DNIinput" aria-describedby="IdHelp" placeholder="DNI" class="form-control col-12" runat="server" required/>
                <small id="IdHelp" class="form-text col-12 p-0 text-muted">Introduce tu DNI</small>
              </div>
              <div class="form-group row mx-0">
                <label for="exampleInputPassword1" class="col-12 p-0">Password</label>
                  <input type="password" id="Passwordinput" placeholder="Password" class="form-control col-12"  runat="server" required/>
              </div>
              <asp:Button CssClass="UserManagerbtn btn" ID="LogInButton" runat="server" onclick="ValidateUser" Text="Iniciar sesión" /> 
            
        </div>
    </div>

</asp:Content>
