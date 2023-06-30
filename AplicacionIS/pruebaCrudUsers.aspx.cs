using AplicacionIS.Datos;
using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionIS
{
    public partial class pruebaCrudUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        UsuarioDatos usuario = new UsuarioDatos();
        UsuarioModel modelusuario = new UsuarioModel();

        //CARGAR REGISTROS EN EL GRIDVIEW
        private void ListarU()
        {
            tableUsuarios.DataSource = usuario.Listar();
            tableUsuarios.DataBind();

        }

        protected void tableUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Update"))
            {

            }
        }

        //METODO PARA ELIMINAR
        protected void tableUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int idUsuario = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Value.ToString());
            usuario.Eliminar(idUsuario);


            tableUsuarios.DataSource = usuario.Listar();
            tableUsuarios.DataBind();
        }

        //METODO DE CONFIRMACION DE ELIMINACION
        protected void tableUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // CICLO QUE INGRESA A TODOS LOS REGISTROS
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    // BUSCAR DENTRO DE LAS CELDAS DE TODOS LOS REGISTROS
                    foreach (Control control in cell.Controls)
                    {
                        Button button = control as Button;
                        if (button != null && button.CommandName == "Delete")
                            // CONFIRMACION DE ELIMINAR
                            button.OnClientClick = "if (!confirm('Esta seguro de " +
                                   "que desea eliminar a este usuario?')) return;";
                    }
                }
            }
        }

        protected void tableUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ListarU();
            tableUsuarios.EditIndex = e.NewEditIndex;
            tableUsuarios.DataBind();

        }

        protected void tableUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblMensajeE.Visible = false;
            //ListarU();
            int idU = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Value.ToString());
            string Nombre = ((TextBox)tableUsuarios.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string Apellido = ((TextBox)tableUsuarios.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string Telefono = ((TextBox)tableUsuarios.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string Direccion = ((TextBox)tableUsuarios.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string Correo = ((TextBox)tableUsuarios.Rows[e.RowIndex].Cells[5].Controls[0]).Text;

            modelusuario.Id = idU;
            modelusuario.Nombre = Nombre;
            modelusuario.Apellido = Apellido;
            modelusuario.Telefono = Telefono;
            modelusuario.Direccion = Direccion;
            modelusuario.Correo = Correo;

            usuario.Editar(modelusuario);

            tableUsuarios.EditIndex = -1;
            tableUsuarios.DataBind();
            ListarU();

            lblMensajeE.Text = "Cambio exitoso!";
            lblMensajeE.Visible = true;
            lblMensajeF.Visible = false;
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            lblMensajeE.Visible = false;
            lblMensajeF.Visible = false;
            ListarU();
        }

        protected void tableUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            tableUsuarios.EditIndex = -1;
            tableUsuarios.DataBind();
            ListarU();

            lblMensajeE.Visible = false;
            lblMensajeF.Text = "Operacion Cancelada!";
            lblMensajeF.Visible = true;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            //RegularExpressionValidator1.Text = "EL USUARIO YA EXISTE!!!!";
        }

        protected void btnGuardarReg_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
           // MultiView1.SetActiveView(View2);
            bool existe = usuario.existeUsuario(int.Parse(txtId.Text));
            
            
            if(existe == true)
            {
                txtId.Text = "EL USUARIO YA EXISTE!!!";
                MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                modelusuario.Id = int.Parse(txtId.Text);
                modelusuario.Nombre = txtNombre.Text;
                modelusuario.Apellido = txtApellido.Text;
                modelusuario.Telefono = txtTelefono.Text;
                modelusuario.Direccion = txtDireccion.Text;
                modelusuario.Correo = txtCorreo.Text;

                txtId.Text = "";
                txtNombre.Text="";
                txtApellido.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                txtCorreo.Text = "";

                usuario.Guardar(modelusuario);
                MultiView1.ActiveViewIndex = 0;
                ListarU();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";

            MultiView1.ActiveViewIndex = 0;
            ListarU();

        }
    }
}