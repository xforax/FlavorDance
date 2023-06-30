<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/masterCruds.Master" AutoEventWireup="true" CodeBehind="crudProfesores.aspx.cs" Inherits="AplicacionIS.crudProfesores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h4><strong>CRUD</strong> Profesores</h4>

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
                OnRowDataBound="tableUsuarios_RowDataBound"
                OnRowCancelingEdit="tableUsuarios_RowCancelingEdit">
                
                <Columns>  
                        <asp:BoundField DataField ="Id" HeaderText="ID" ReadOnly="True"/>   
                        <asp:BoundField DataField ="Nombre" HeaderText="Nombre" ReadOnly="True"/>                      
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" ReadOnly="True"/>
                        <asp:BoundField DataField="Experiencia" HeaderText="Experiencia"/>
                        
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
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    <br />
                  <label>ID</label>
                    
                </div>
                <div class="form-group col-md-6">
                    <asp:DropDownList ID="listaIdUsers" runat="server" DataSourceID="SqlDataSource30" DataTextField="id_usuario" DataValueField="id_usuario">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource30" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT u.id as id_usuario
FROM usuario u
LEFT JOIN profesor p ON u.id = p.id_usuario
LEFT JOIN cliente c ON u.id = c.id_usuario
WHERE p.id_usuario IS NULL AND c.id_usuario IS NULL;"></asp:SqlDataSource>
                    <br />
                  <label>Experiencia</label>
                    </div>
            </div>    
            <div class="form-group col-md-6">
                <asp:TextBox ID="txtExperiencia" runat="server"></asp:TextBox>
                <br />
                
            </div>
            
            <div class="form-group col-md-6">
                <br />
                
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
