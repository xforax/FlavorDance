<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/masterCruds.Master" AutoEventWireup="true" CodeBehind="pruebaCrudUsers.aspx.cs" Inherits="AplicacionIS.pruebaCrudUsers" UnobtrusiveValidationMode="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h4><strong>CRUD</strong> Usuarios</h4>
    <asp:MultiView ID="MultiView1" runat="server">

        <asp:View ID="View1" runat="server">
                    <div class ="card">
                <div class="mb-3">
                    <br />
                    <asp:Button ID="btnCargar" runat="server" OnClick="btnCargar_Click" Text="MOSTRAR DATOS" />
            
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click" Text="CREAR NUEVO" />
            
                </div>
            </div>
            <br />
            <asp:GridView ID="tableUsuarios" runat="server" class="table" 
                AutoGenerateColumns="False" 
                OnRowCommand="tableUsuarios_RowCommand" 
                OnRowDeleting="tableUsuarios_RowDeleting" 
                OnRowEditing="tableUsuarios_RowEditing"
                OnRowUpdating="tableUsuarios_RowUpdating"
                DataKeyNames="Id" 
                OnRowDataBound="tableUsuarios_RowDataBound" OnRowCancelingEdit="tableUsuarios_RowCancelingEdit">
                <Columns>  
                        <asp:BoundField DataField ="Id" HeaderText="ID" ReadOnly="True"/>  
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />  
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                        <asp:ButtonField  ButtonType="Button" CommandName="Delete" Text="Eliminar"/>

                        <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMensajeE" runat="server" ForeColor="#009933" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblMensajeF" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </asp:View>

        <asp:View ID="View2" runat="server">
          <div  id="elementoFormulario">
            <div class="form-row">
                <div class="form-group col-md-6">
                    <br />
                  <label>ID</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtId" ErrorMessage="RequiredFieldValidator" ValidateRequestMode="Enabled" ForeColor="#CC0000">Ingrese un ID!</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtId" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\d+">Ingrese un ID valido!</asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtId" runat="server" class="form-control" placeholder="10000000"></asp:TextBox>
                </div>
                <div class="form-group col-md-6">
                    <br />
                  <label>Correo</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCorreo" ErrorMessage="RequiredFieldValidator" ValidateRequestMode="Enabled" ForeColor="#CC0000">Ingrese un correo!</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCorreo" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidateRequestMode="Enabled" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Ingrese un correo valido!</asp:RegularExpressionValidator>
                  <asp:TextBox ID="txtCorreo" runat="server" class="form-control" placeholder="ejemplo@correo.com"></asp:TextBox>
                </div>
            </div>    
            <div class="form-group col-md-6">
                <br />
              <label>Nombre</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator" ValidateRequestMode="Enabled" ForeColor="#CC0000">Ingrese un nombre!</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Francisco"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <br />
              <label>Apellido</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtApellido" ErrorMessage="RequiredFieldValidator" ValidateRequestMode="Enabled" ForeColor="#CC0000">Ingrese un apellido!</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtApellido" runat="server" class="form-control" placeholder="Oceano"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <br />
              <label>Telefono</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelefono" ErrorMessage="RequiredFieldValidator" ValidateRequestMode="Enabled" ForeColor="#CC0000">Ingrese un telefono!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTelefono" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\d+">Ingrese un Telefono valido!</asp:RegularExpressionValidator>
                <asp:TextBox ID="txtTelefono" runat="server" class="form-control" placeholder="3124557845"></asp:TextBox>
            <div class="form-group col-md-6">
                <br />
              <label>Direccion</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDireccion" ErrorMessage="RequiredFieldValidator" ValidateRequestMode="Enabled" ForeColor="#CC0000">Ingrese una direccion!</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Cll 100 #45-20"></asp:TextBox>
            </div>
            

          </div><!--NO BORRAR ESTE DIV XD-->
          
              <br />
              <asp:Button ID="btnGuardarReg" runat="server" OnClick="btnGuardarReg_Click" Text="GUARDAR" />
              &nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="VOLVER" CausesValidation="false" />
              <br />
        </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
