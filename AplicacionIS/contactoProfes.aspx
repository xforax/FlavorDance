<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactoProfes.aspx.cs" Inherits="AplicacionIS.contactoProfes" %>

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
    <h3><strong>Contacto</strong> Profesores<asp:Label ID="lblidCliente" runat="server" Text="Label" Visible="False"></asp:Label>
                            </h3>
    <asp:MultiView ID="MultiView1" runat="server">
       
        <asp:View ID="View1" runat="server">
            <asp:GridView ID="tableUsuarios" runat="server" class="table" 
                AutoGenerateColumns="False">
                <Columns>  
                        <asp:BoundField DataField ="Nombre" HeaderText="Nombre" ReadOnly="True"/>  
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" ReadOnly="True"/>  
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" ReadOnly="True"/>
                        <asp:BoundField DataField="Correo" HeaderText="Correo" ReadOnly="True"/>
                        <asp:BoundField DataField="Experiencia" HeaderText="Experiencia" ReadOnly="True"/>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMensajeE" runat="server" ForeColor="#009933" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblMensajeF" runat="server" ForeColor="Red" Visible="False"></asp:Label>

        </asp:View>

    </asp:MultiView>

							<!-- Section -->
								<section>
									<header class="major">
										<h2>Flavor Dance 2023</h2>
									</header>
									<!-- Footer -->
									<footer id="footer">
									<p class="copyright">&copy; Flavor Dance 2023. Todos los Derechos Reservados.</p>
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
										<li><a href="contactoAcademia.aspx">Contacto</a></li>
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