<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/masterCruds.Master" AutoEventWireup="true" CodeBehind="crudClases.aspx.cs" Inherits="AplicacionIS.crudClases" UnobtrusiveValidationMode="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h4><strong>CRUD</strong> Clases</h4>
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
                DataKeyNames="Hora,Dia"
                OnRowDataBound="tableUsuarios_RowDataBound"
                OnRowCancelingEdit="tableUsuarios_RowCancelingEdit">
                
                <Columns>  
                        <asp:BoundField DataField ="Hora" HeaderText="Hora" ReadOnly="True"/>   
                        <asp:BoundField DataField ="Dia" HeaderText="Id Dia" ReadOnly="True"/>                      
                        <asp:BoundField DataField="NomDia" HeaderText="Dia" ReadOnly="True"/>
                        <asp:TemplateField HeaderText="Profesor">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="id">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select pro.id_usuario as id, us.nombre from profesor pro JOIN
	usuario us ON(pro.id_usuario=us.id)"></asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("NomProf") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Genero">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="descripcion" DataValueField="id_genero">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id_genero], [descripcion] FROM [genero]"></asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("NomGen") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                  <label>Hora</label>
                    
                </div>
                <div class="form-group col-md-6">
                    <asp:DropDownList ID="listaHora" runat="server">
                        <asp:ListItem Value="16">16:00</asp:ListItem>
                        <asp:ListItem Value="18">18:00</asp:ListItem>
                        <asp:ListItem Value="20">20:00</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                  <label>Dia</label>
                    </div>
            </div>    
            <div class="form-group col-md-6">
                <asp:DropDownList ID="listaDia" runat="server" DataSourceID="SqlDataSource20" DataTextField="nombre" DataValueField="id_dia">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource20" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id_dia], [nombre] FROM [dia]"></asp:SqlDataSource>
                <br />
              <label>Profesor</label>
                <asp:DropDownList ID="listaProfesor" runat="server" DataSourceID="SqlDataSource22" DataTextField="nombre" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource22" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select pro.id_usuario as id, us.nombre from profesor pro JOIN
	usuario us ON(pro.id_usuario=us.id)"></asp:SqlDataSource>
                <br />
            </div>
            <div class="form-group col-md-6">
                <br />
              <label>Genero</label>
                <asp:DropDownList ID="listaGenero" runat="server" DataSourceID="SqlDataSource21" DataTextField="descripcion" DataValueField="id_genero">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource21" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id_genero], [descripcion] FROM [genero]"></asp:SqlDataSource>
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
