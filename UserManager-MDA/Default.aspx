<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserManager_MDA._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row h-100 justify-content-center align-content-center">
        <div class="col-6">
            
              <div class="form-group row mx-0">
                <label for="DNIinput" class="col-12">Identificación</label>
                <input type="text" id="DNIinput" aria-describedby="IdHelp" placeholder="DNI" class="form-control col-12">
                <small id="IdHelp" class="form-text col-12 text-muted">Introduce tu DNI</small>
              </div>
              <div class="form-group row mx-0">
                <label for="exampleInputPassword1" class="col-12">Password</label>
                <input type="password" id="exampleInputPassword1" placeholder="Password" class="form-control col-12 ">
              </div>
              <button type="submit" class="btn btn-primary">Submit</button>
            
        </div>
    </div>

</asp:Content>
 