using AplicacionIS.Datos;
using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AplicacionIS
{
    public partial class LoginUsuarios : System.Web.UI.Page
    {

        UsuarioDatos usuario = new UsuarioDatos();

        UsuarioModel modelUsuario = new UsuarioModel();
        AdminModel modelAdmin = new AdminModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {

            if (!vacioIngreso())
            {
                return;
            }

            int tipoUser = int.Parse(listaTipoUser.SelectedValue.ToString());
            String contraseña = txtPassword.Text, correo = txtCorreoLog.Text;

            

            if (tipoUser == 1)//LOGEO DE ADMINISTRADOR
            {
                bool existe = usuario.existeUsuarioLoginA(correo);

                if (existe == true)
                {

                    bool comprobado = usuario.comprobarDatosAdmin(correo, contraseña);
                    if(comprobado == true)
                    {

                        modelAdmin = usuario.ObtenerA(correo);
                        string name = modelAdmin.Nombre;

                       // MessageBox.Show("Se logeo "+name, "INICIO EXITOSO");
                        Session.Add("nombre",name);
                        Server.Transfer("InicioAdmin.aspx");

                    }
                    else
                    {
                        MessageBox.Show("Error en los datos", "Error al Iniciar Sesión");
                    }
                    // modelUsuario = usuario.Obtener(correo);


                }
                else
                {
                    MessageBox.Show("Error en los datos", "Error al Iniciar Sesión");
                }

            }
            else if(tipoUser == 2)//LOGEO DE CLIENTE
            {
                bool existe = usuario.existeUsuarioLoginC(correo);

                if (existe == true)
                {
                    bool comprobado = usuario.comprobarDatosCli(correo, contraseña);

                    if(comprobado == true)
                    {

                        modelUsuario = usuario.Obtener(correo);
                        string name = modelUsuario.Nombre;
                        int id = modelUsuario.Id;
                        Session.Add("nombre", name);
                        Session.Add("id", id);
                        Server.Transfer("InicioCliente.aspx");

                        //MessageBox.Show("Se logeo "+name, "INICIO EXITOSO");

                    }
                    else
                    {
                        MessageBox.Show("Error en los datos", "Error al Iniciar Sesión");
                    }
                    // modelUsuario = usuario.Obtener(correo);


                }
                else
                {
                    MessageBox.Show("Error en los datos", "Error al Iniciar Sesión");
                }
                
            }

            
        }

        protected bool vacioIngreso()
        {
            if (txtCorreoLog.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Llenar todos los campos", "Error");
                return false;
            }

            return true;
        }
    }
}