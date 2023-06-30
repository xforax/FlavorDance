<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/masterCruds.Master" AutoEventWireup="true" CodeBehind="crudClientes.aspx.cs" Inherits="AplicacionIS.crudClientes" EnableEventValidation="false" UnobtrusiveValidationMode="None"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h4><strong>CRUD</strong> Clientes</h4>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
                <div class ="card">
            <div class="mb-3">
                <br />
                <asp:Button ID="btnCargar" runat="server" OnClick="btnCargar_Click" Text="MOSTRAR DATOS" />
                &nbsp;&nbsp;
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
            OnRowDataBound="tableUsuarios_RowDataBound" 
            OnRowCancelingEdit="tableUsuarios_RowCancelingEdit">
            <Columns>  
                    <asp:BoundField DataField ="Id" HeaderText="Id" ReadOnly="True"/>  
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True"/>  
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" ReadOnly="True"/>
                    <asp:TemplateField HeaderText="Sexo">
                        <EditItemTemplate>
                            <asp:DropDownList ID="listaSexo" runat="server">
                                <asp:ListItem Value="1">Masculino</asp:ListItem>
                                <asp:ListItem Value="2">Femenino</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha_nacimiento">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Fecha_nacimiento") %>' TextMode="Date"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Fecha_nacimiento", "{0:dd-MM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha_inscripcion">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Fecha_inscripcion") %>' TextMode="Date"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Fecha_inscripcion", "{0:dd-MM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contraseña">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:ButtonField  ButtonType="Button" CommandName="Delete" Text="Eliminar"/>

                    <asp:CommandField ButtonType="Button" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMensajeE" runat="server" ForeColor="#009933" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblMensajeF" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        <br />
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div  id="elementoFormulario">
            <div class="form-row">
                <div class="form-group col-md-6">
                    <br />
                  <label>ID</label>
                    
                </div>
                <div class="form-group col-md-6">
                    <asp:DropDownList ID="listaIdUsuarios" runat="server" DataSourceID="SqlDataSource1" DataTextField="id_usuario" DataValueField="id_usuario">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT u.id as id_usuario
FROM usuario u
LEFT JOIN profesor p ON u.id = p.id_usuario
LEFT JOIN cliente c ON u.id = c.id_usuario
WHERE p.id_usuario IS NULL AND c.id_usuario IS NULL;"></asp:SqlDataSource>
                    <br />
                  <label>Sexo</label>
                    </div>
            </div>    
            <div class="form-group col-md-6">
                <asp:DropDownList ID="listaSexo" runat="server">
                    <asp:ListItem Value="1">Masculino</asp:ListItem>
                    <asp:ListItem Value="2">Femenino</asp:ListItem>
                </asp:DropDownList>
                <br />
              <label>Fecha Nacimiento</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaNaci" ErrorMessage="RequiredFieldValidator" ValidateRequestMode="Enabled" ForeColor="#CC0000">Ingrese una fecha!</asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtFechaNaci" runat="server" class="form-control" placeholder="15/06/2001" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <br />
              <label>Fecha Inscripcion</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFechaInsc" ErrorMessage="RequiredFieldValidator" ValidateRequestMode="Enabled" ForeColor="#CC0000">Ingrese una fecha!</asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtFechaInsc" runat="server" class="form-control" placeholder="Oceano" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <br />
              <label>Contraseña</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" ErrorMessage="RequiredFieldValidator" ValidateRequestMode="Enabled" ForeColor="#CC0000">Ingrese una contraseña!</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="*******"></asp:TextBox>
            
            

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
