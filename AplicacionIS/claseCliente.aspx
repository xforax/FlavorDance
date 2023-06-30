<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="claseCliente.aspx.cs" Inherits="AplicacionIS.claseCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<title>Flavor Dance</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
		<link rel="stylesheet" href="../assets/css/main.css" />
		<link rel="icon" href="~/images/logofl.ico">
</head>
<body>
<form id="form1" runat="server">
	
        <div id="wrapper">
				<!-- Main -->
					<div id="main">
						<div class="inner">

							<!-- Header -->
								<header id="header">
									<a href="InicioCliente.aspx" class="logo"><strong>Academia</strong> Flavor Dance</a>
									<ul class="icons">
										<li><a href="#" class="icon brands fa-whatsapp"><span class="label">Twitter</span></a></li>
										<li><a href="https://www.facebook.com/profile.php?id=100063027560549" class="icon brands fa-facebook-f"><span class="label">Facebook</span></a></li>
										<li><a href="https://instagram.com/flavor.dance?igshid=NTc4MTIwNjQ2YQ==" class="icon brands fa-instagram"><span class="label">Instagram</span></a></li>
										<li><a href="LoginUsuarios.aspx" class="button primary" id="btnCerrarSesion">Cerrar Sesión</a></li>
									</ul>
								</header>

							<!-- Banner ACA VA TODO EL CONTENIDO DEL CRUD (TABLAS,TITULOS,ETC) -->
							 <br />
    <h4><strong>Clases</strong> Cliente<asp:Label ID="lblidCliente" runat="server" Text="Label" Visible="False"></asp:Label>
                            </h4>
    <asp:MultiView ID="MultiView1" runat="server">
       
        <asp:View ID="View1" runat="server">

            <div class ="card">
                <div class="mb-3">
                    <br />
                    <asp:Button ID="btnCargar" runat="server" OnClick="btnCargar_Click" Text="MOSTRAR DATOS" />
            
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click" Text="AGENDAR" />
            
                </div>
            </div>
            <br />
            <asp:GridView ID="tableUsuarios" runat="server" class="table" 
                AutoGenerateColumns="False" 
                OnRowEditing="tableUsuarios_RowEditing"
                OnRowUpdating="tableUsuarios_RowUpdating"
                DataKeyNames="Id,Hora,Dia" 
                OnRowDataBound="tableUsuarios_RowDataBound"
                OnRowCancelingEdit="tableUsuarios_RowCancelingEdit">
                <Columns>  
                        <asp:BoundField DataField ="Id" HeaderText="ID Cliente" ReadOnly="True"/>  
                        <asp:BoundField DataField="Hora" HeaderText="Hora clase" ReadOnly="True"/>  
                        <asp:BoundField DataField="Dia" HeaderText="IdDia" ReadOnly="True"/>
                        <asp:BoundField DataField="NomDia" HeaderText="Dia" ReadOnly="True"/>
                        <asp:TemplateField HeaderText="Estado">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="200">AGENDADO</asp:ListItem>
                                    <asp:ListItem Value="201">CANCELADO</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

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
                  <label>ID Cliente</label>
                    
                </div>
                <div class="form-group col-md-6">
                    <asp:TextBox ID="txtIdCliente" runat="server" Enabled="False" ReadOnly="true"></asp:TextBox>
                    <br />
                  <label>Dia</label>
                    </div>
            </div>    
            <div class="form-group col-md-6">
                <asp:DropDownList ID="listaDia" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource41" DataTextField="nombre" DataValueField="id_dia" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource41" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id_dia], [nombre] FROM [dia]"></asp:SqlDataSource>
                <br />
              <label>Hora clase</label>
                <asp:DropDownList ID="listaHoraDia" runat="server" DataSourceID="SqlDataSource42" DataTextField="hora" DataValueField="hora" OnSelectedIndexChanged="listaHoraDia_SelectedIndexChanged" AutoPostBack="True" OnDataBound="MyListDataBound">
                    <asp:ListItem Value="0">SELECCIONE HORA</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource42" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="sp_ObtenerHoras" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="listaDia" DefaultValue="0" Name="id_dia" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
            </div>
            
            <div class="form-group col-md-6">
                <label>Detalles de Clase</label>
                <asp:GridView ID="listaTemporal" runat="server" 
                    AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField DataField="NomGenero" HeaderText="Genero" ReadOnly="True" />
                        <asp:BoundField DataField="NomProf" HeaderText="Profesor" ReadOnly="True" />
                    </Columns>
                </asp:GridView>
                
          </div><!--NO BORRAR ESTE DIV XD-->
          
              <asp:Button ID="btnGuardarReg" runat="server" OnClick="btnGuardarReg_Click" Text="GUARDAR" />
              &nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="VOLVER" CausesValidation="false" />
              <br />
        </div>

        </asp:View>

    </asp:MultiView>



							<!-- Section -->
								<section>
									<header class="major">
										<h2>Flavor Dance 2023</h2>
									</header>
									<!-- Footer -->
									<footer id="footer">
									<p class="copyright">&copy; Flavor Dance 2023. Todos los Derechos Reservados. Demo Images: <a href="https://unsplash.com">Unsplash</a>. Design: <a href="https://html5up.net">HTML5 UP</a>.</p>
								</footer>
								</section>

						</div>
					</div>

				<!-- Sidebar -->
					<div id="sidebar">
						<div class="inner">

							<!-- Search -->
							<!-- BARRA DE BUSQUEDA COMENTARIADA -->
							<!--	<section id="search" class="alt">
									<form method="post" action="#">
										<input type="text" name="query" id="query" placeholder="Search" />
									</form>
								</section>  -->

							<!-- Menu -->
								<nav id="menu">
									<header class="major">
										<h2>Menu Cliente</h2>
									</header>
									<ul>
										<li><a href="InicioCliente.aspx">Inicio</a></li>
										<li><a href="claseCliente.aspx">Clases</a></li>
										<li><a href="contactoProfes.aspx">Profesores</a></li>
										<li><a href="#">Contacto</a></li>
									</ul>
								</nav>

							<!-- Section -->
								<section>
									<header class="major">
										<h2>Contáctanos</h2>
									</header>
									<p>Encuentra mas información de nuestra academia en los respectivos canales de comunicación diseñados para ti!</p>
									<ul class="contact">
										<li class="icon solid fa-envelope"><a href="#">johankmilo_0816@hotmail.com</a></li>
										<li class="icon solid fa-phone">+57 314-4526124</li>
										<li class="icon solid fa-home">Bogota - Kennedy Central<br />
										Cll 37Sur N°78h-14</li>
									</ul>
								</section>
						</div>			
					</div>
			</div>

		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/browser.min.js"></script>
			<script src="assets/js/breakpoints.min.js"></script>
			<script src="assets/js/util.js"></script>
			<script src="assets/js/main.js"></script>
    </form>
</body>
</html>