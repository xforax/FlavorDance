<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/masterCruds.Master" AutoEventWireup="true" CodeBehind="crudAsistencias.aspx.cs" Inherits="AplicacionIS.crudAsistencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h4><strong>Verificar</strong> Asistencias</h4>
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
                DataKeyNames="IdCliente,HoraCla,IdDiaCla,FechaCla"
                OnRowDataBound="tableUsuarios_RowDataBound">
                
                <Columns>  
                        <asp:BoundField DataField ="IdCliente" HeaderText="Id Cliente" ReadOnly="True"/>   
                        <asp:BoundField DataField ="NombreCom" HeaderText="Nombres" ReadOnly="True"/>                      
                        <asp:BoundField DataField="HoraCla" HeaderText="Hora" ReadOnly="True"/>
                        <asp:BoundField DataField="IdDiaCla" HeaderText="Id_Dia" ReadOnly="True"/>
                        <asp:BoundField DataField="DiaCla" HeaderText="Dia" ReadOnly="True"/>
                        <asp:BoundField DataField="FechaCla" HeaderText="Fecha" ReadOnly="True" DataFormatString="{0: dd-MM-yyyy}" />

                        <asp:ButtonField  ButtonType="Button" CommandName="Delete" Text="Eliminar"/>
                </Columns>

            </asp:GridView>

            <asp:Label ID="lblMensajeE" runat="server" ForeColor="#009933" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblMensajeF" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </asp:View>

        <asp:View ID="View2" runat="server">
            <div class="row gtr-uniform">
					
					<div class="col-6 col-12-xsmall">
						<label>Dia</label>
						<asp:DropDownList ID="listaDia" runat="server" DataSourceID="SqlDataSource61" DataTextField="nombre" DataValueField="id_dia" AutoPostBack="True" OnSelectedIndexChanged="listaDia_SelectedIndexChanged"></asp:DropDownList>
					    <asp:SqlDataSource ID="SqlDataSource61" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id_dia], [nombre] FROM [dia]"></asp:SqlDataSource>
					</div>
						
					<div class="col-6 col-12-xsmall">
						
					</div>
					<!-- Break -->
					<div class="col-6 col-12-xsmall">
						<label>Hora</label>
						<asp:DropDownList ID="listaHora" runat="server" DataSourceID="SqlDataSource62" DataTextField="hora" DataValueField="hora" OnSelectedIndexChanged="listaHora_SelectedIndexChanged" OnDataBound="MyListDataBound" AutoPostBack="True"></asp:DropDownList>
					    <asp:SqlDataSource ID="SqlDataSource62" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="sp_ObtenerHoras" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="listaDia" Name="id_dia" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
					</div>

					<!-- Break -->
                    <div class="col-12">
                        <label>Detalles clase</label>
                        <asp:GridView ID="listaTemporal" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="NomGen" HeaderText="Genero" ReadOnly="True" />
                                <asp:BoundField DataField="NomProf" HeaderText="Profesor" ReadOnly="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-6 col-12-xsmall">
                        <label>Asistentes</label>
                        <asp:DropDownList ID="listaAsistentes" runat="server" DataSourceID="SqlDataSource63" DataTextField="nombre_com" DataValueField="id_cliente"></asp:DropDownList>
					    <asp:SqlDataSource ID="SqlDataSource63" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="sp_BuscarAsistentes" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="listaDia" Name="id_dia" PropertyName="SelectedValue" Type="Int32" />
                                <asp:ControlParameter ControlID="listaHora" Name="hora" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
					</div>

                    <div class="col-12">
                        <label>Fecha asistencia</label>
                        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
					</div>
                    
					<!-- Break -->
					<div class="col-12">
						
						<asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="primary" OnClick="btnRegistrar_Click"/>
						<asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
						
					</div>
				</div>

        </asp:View>

    </asp:MultiView>

</asp:Content>
