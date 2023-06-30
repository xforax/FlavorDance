<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioCliente.aspx.cs" Inherits="AplicacionIS.InicioCliente" %>

<!DOCTYPE html>

<html>
	<head runat="server">
		<title>Flavor Dance</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
		<link rel="stylesheet" href="assets/css/main.css" />
		<link rel="icon" href="images/logofl.ico">
	</head>
<body class="is-preload">
    <form id="form1" runat="server">
        <div id="wrapper">
				<!-- Main -->
					<div id="main">
						<div class="inner">

							<!-- Header -->
								<header id="header">
									<a href="InicioCliente.aspx" class="logo"><strong>Academia</strong> Flavor Dance</a>
									<ul class="icons">
										<asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
										<li><a href="#" class="icon brands fa-whatsapp"><span class="label">Twitter</span></a></li>
										<li><a href="https://www.facebook.com/profile.php?id=100063027560549" class="icon brands fa-facebook-f"><span class="label">Facebook</span></a></li>
										<li><a href="https://instagram.com/flavor.dance?igshid=NTc4MTIwNjQ2YQ==" class="icon brands fa-instagram"><span class="label">Instagram</span></a></li>
										<li><a href="LoginUsuarios.aspx" class="button primary" id="btnCerrarSesion">Cerrar Sesión</a></li>
									</ul>
								</header>

							<!-- Banner -->
								<section id="banner">
									<div class="content">
										<header>
											<h1>Bienvenido</h1>
											<h1><asp:Label ID="lblNombre" runat="server" Text=""></asp:Label></h1>
											<p>ACADEMIA DE DANZA</p>
										</header>
										<p>La danza es un arte que se basa en la expresión corporal, generalmente acompañada de música. Es una de las formas de expresión más ancestrales del ser humano que puede tener fines artísticos, de entretenimiento o religiosos.Es también llamada “el lenguaje del cuerpo” y se vale de una secuencia de movimientos corporales que acompañan de manera rítmica a la música.</p>
										<ul class="actions">
											<li><a href="https://concepto.de/danza/" class="button big">¡Aprende Más!</a></li>
										</ul>
									</div>
									<span class="image object">
										<img src="images/logoSabor.jpg" alt="" />
									</span>
								</section>

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
										<li><asp:LinkButton ID="linkClases" runat="server" OnClick="linkClases_Click">Clases</asp:LinkButton></li>
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
