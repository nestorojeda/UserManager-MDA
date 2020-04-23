<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="UserManager_MDA.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row min-vh-100 justify-content-center align-content-center">
        <div class="col-6 py-3">
            
              <div class="form-group row mx-0">
                <label for="DNIInput" class="col-12 p-0">Identificación</label>
                <input type="text" id="DNIinput" aria-describedby="IdHelp" placeholder="" class="form-control col-12">
                <small id="IdHelp" class="form-text col-12 p-0 text-muted">Introduce tu DNI</small>
              </div>
              <div class="form-group row mx-0">
                <label for="PasswordInput" class="col-12 p-0">Password</label>
                <input type="password" id="PasswordInput" aria-describedby="PasswordHelp" placeholder="" class="form-control col-12 ">
                <small id="PasswordHelp" class="form-text col-12 p-0 text-muted">Introduce tu Password</small>
              </div>
              <div class="form-group row mx-0">
                <label for="RepeatPasswordInput" class="col-12 p-0">Repite tu Password</label>
                <input type="password" id="RepeatPasswordInput" aria-describedby="RepeatPasswordHelp" placeholder="" class="form-control col-12 ">
                <small id="RepeatPasswordHelp" class="form-text col-12 p-0 text-muted">Repite tu Contraseña</small>
              </div>  
              <div class="form-group row mx-0">
                <label for="NameInput" class="col-12 p-0">Nombre</label>
                <input type="text" id="NameInput" aria-describedby="NameInputHelp" placeholder="" class="form-control col-12 ">
                <small id="NameInputHelp" class="form-text col-12 p-0 text-muted">Introduce tu nombre</small>
              </div>  
              <div class="form-group row mx-0">
                <label for="SurNameInput" class="col-12 p-0">Apellido</label>
                <input type="text" id="SurNameInput" aria-describedby="SurNameInputHelp" placeholder="" class="form-control col-12 ">
                <small id="SurNameInputHelp" class="form-text col-12 p-0 text-muted">Introduce tu apellido</small>
              </div> 
              <div class="form-group row mx-0">
                <label for="CategorySelectInput" class="col-12 p-0">Selecciona la categoria</label>
                <select class="form-control col-12" id="CategorySelectInput">
                  <option>1</option>
                  <option>2</option>
                  <option>3</option>
                  <option>4</option>
                  <option>5</option>
                </select>
              </div>
              <div class="form-check row mx-0 pb-3">
                  <input type="checkbox" class="form-check-input" id="adminCheck">
                  <label class="form-check-label" for="adminCheck">Solicitud de administrador</label>
              </div>  
              <div class="form-group row mx-0">
                <label for="InformationTextarea" class="col-12 p-0">Información</label>
                <textarea class="form-control col-12" id="InformationTextarea" rows="3"></textarea>
              </div>
              <div class="custom-file row mx-0">
                <input type="file" class="custom-file-input col-12" id="FileInput" lang="es">
                <label class="custom-file-label col-12" for="FileInput">Seleccionar Archivo</label>
              </div>
              <button type="submit" class="btn btn-primary mt-3">Add User</button>
            
        </div>
    </div>

</asp:Content>
