<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="UserManager_MDA.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row min-vh-100 justify-content-center align-content-center">
        <div class="col-6 py-3"> 
            
              <div class="form-group row mx-0">
                <label for="DNIInput" class="col-12 p-0">Identificación</label>
                <input type="text" id="DNIinput" runat="server" aria-describedby="IdHelp" placeholder="" class="form-control col-12">
                <small id="IdHelp" class="form-text col-12 p-0 text-muted">Introduce tu DNI</small>
              </div>
              <div class="form-group row mx-0">
                <label for="PasswordInput" class="col-12 p-0">Password</label>
                <input type="text" id="PasswordInput" runat="server" aria-describedby="PasswordHelp" placeholder="" class="form-control col-12 ">
                <small id="PasswordHelp" class="form-text col-12 p-0 text-muted">Introduce tu Password</small>
              </div>
              <div class="form-group row mx-0">
                <label for="NameInput" class="col-12 p-0">Nombre</label>
                <input type="text" id="NameInput" runat="server" aria-describedby="NameInputHelp" placeholder="" class="form-control col-12 ">
                <small id="NameInputHelp" class="form-text col-12 p-0 text-muted">Introduce tu nombre</small>
              </div>  
              <div class="form-group row mx-0">
                <label for="SurNameInput" class="col-12 p-0">Apellido</label>
                <input type="text" id="SurNameInput" runat="server" aria-describedby="SurNameInputHelp" placeholder="" class="form-control col-12 ">
                <small id="SurNameInputHelp" class="form-text col-12 p-0 text-muted">Introduce tu apellido</small>
              </div> 
              <div class="form-group row mx-0">
                <label for="CategorySelectInput" class="col-12 p-0">Selecciona la categoria</label>
                <select class="form-control col-12" id="CategorySelectInput" runat="server">
                  <option>Profesor</option>
                  <option>Estudiante</option>
                  <option>PAS</option>
                  <option>Investigador</option>
                  <option>Otro</option>
                </select>
              </div>
              <div class="form-check row mx-0 pb-3">
                  <asp:CheckBox ID="adminCheck" runat="server" Checked="false" class="form-check-input"/>
                  <label class="form-check-label" for="adminCheck">Solicitud de administrador</label>
              </div>  
              <div class="form-group row mx-0">
                <label for="InformationTextarea" class="col-12 p-0">Información</label>
                <textarea class="form-control col-12" id="InformationTextarea" runat="server" rows="3"></textarea>
              </div>
              <div class="custom-file row mx-0">
                <asp:Image ID="previewImage" runat="server"/>
                <asp:FileUpload runat="server" ID="flImage" aria-describedby="Button1" class="col-12" onchange="updateImage" AutoPostBack="true"/>
              </div>
              <asp:Button ID="submitButton" runat="server" Text="Editar usuario" class="UserManagerbtn btn mt-3" OnClick="modifyUser" OnClientClick="return confirm('¿Desea cambiar los datos de este usuario?')" />
              <a href="~/UserList.aspx" id="cancelButton" runat="server" class="UserManagerbtn btn mt-3">Cancelar</a>  
              <div id="fail" class="alert alert-danger" role="alert" runat="server"></div>
        </div>
        
    </div>
</asp:Content>
