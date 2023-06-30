<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactoGlobal.aspx.cs" Inherits="AplicacionIS.contactoGlobal" %>

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
									<a href="InicioPagina.aspx" class="logo"><strong>Academia</strong> Flavor Dance</a>
									<ul class="icons">
										<li><a href="#" class="icon brands fa-whatsapp"><span class="label">Twitter</span></a></li>
										<li><a href="https://www.facebook.com/profile.php?id=100063027560549" class="icon brands fa-facebook-f"><span class="label">Facebook</span></a></li>
										<li><a href="https://instagram.com/flavor.dance?igshid=NTc4MTIwNjQ2YQ==" class="icon brands fa-instagram"><span class="label">Instagram</span></a></li>
										<li><a href="LoginUsuarios.aspx" class="button primary" id="btnInicioSesion">Iniciar Sesión</a></li>
									</ul>
								</header>

							<!-- Banner -->
								<!-- Banner ACA VA TODO EL CONTENIDO DEL CRUD (TABLAS,TITULOS,ETC) -->
							 <br />
    <h3><strong>Contacto</strong> Academia<asp:Label ID="lblidCliente" runat="server" Text="Label" Visible="False"></asp:Label>
                            </h3>
							<div class="row gtr-uniform">
								<div class="col-6 col-12-xsmall">
									<input type="text" name="demo-name" id="demo-name" value="" placeholder="Nombres" />
								</div>
								<div class="col-6 col-12-xsmall">
									<input type="email" name="demo-email" id="demo-email" value="" placeholder="Correo" />
								</div>
								<div class="col-6 col-12-xsmall">
									<input type="text" name="demo-email" id="demo-tel1" value="" placeholder="Telefono 1" />
								</div>
								<div class="col-6 col-12-xsmall">
									<input type="text" name="demo-email" id="demo-tel2" value="" placeholder="Telefono 2" />
								</div>
								<!-- Break -->
								<div class="col-12">
									<textarea name="demo-message" id="demo-message" placeholder="¿Que deseas saber?" rows="2"></textarea>
								</div>
								<!-- Break -->
								<div class="col-12">
									<ul class="actions">
										<li><input type="submit" value="Enviar" class="primary" /></li>
										<li><input type="reset" value="Borrar" /></li>
									</ul>
								</div>
							</div>	
							<div style="text-align:center">
								<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2425.973127763986!2d-74.15307092234586!3d4.6234473557921865!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8e3f9e995264c913%3A0x6c6999d5dee1d646!2sCl.%2037%20Sur%20%2378h-14%2C%20Bogot%C3%A1!5e1!3m2!1ses-419!2sco!4v1684780380330!5m2!1ses-419!2sco" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
							</div>

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
										<h2>Menu</h2>
									</header>
									<ul>
										<li><a href="InicioPagina.aspx">Inicio</a></li>
										<li><a href="contactoGlobal.aspx">Contacto</a></li>
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
</html>
