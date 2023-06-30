<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUsuarios.aspx.cs" Inherits="AplicacionIS.LoginUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <meta charset="UTF-8">
  <title>Iniciar Sesión</title>
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
  <link rel="stylesheet" href="/login/style.css" runat="server">
</head>
<body>
    <div id="bg"></div>

<form runat="server">

  <div class="form-field">
    <asp:TextBox ID="txtCorreoLog" runat="server" class="form-control" placeholder="Correo"></asp:TextBox>
  </div>
    
  <div class="form-field">
    <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
  </div>
  
  <div class="form-group">
      <asp:DropDownList ID="listaTipoUser" runat="server" class="form-control">
          <asp:ListItem Value="1">Administrador</asp:ListItem>
          <asp:ListItem Value="2">Cliente</asp:ListItem>
      </asp:DropDownList>
  </div>

  <div class="form-check mb-2">
    <input class="form-check-input" type="checkbox" id="autoSizingCheck">
    <label class="form-check-label" for="autoSizingCheck">
    <strong>Recuérdame</strong>
    </label>
  </div>
    
  <div class="form-field">
    <asp:Button ID="btnInicioSesion" runat="server" class="btn" Text="Ingresar" OnClick="btnInicioSesion_Click"></asp:Button>
  </div>
</form>
</body>
</html>
