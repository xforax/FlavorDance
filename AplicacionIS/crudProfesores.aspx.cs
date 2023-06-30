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
    public partial class crudProfesores : System.Web.UI.Page
    {
        ProfesorDatos datosProfe = new ProfesorDatos();
        ProfesorModel modeloProfe = new ProfesorModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            lblMensajeE.Visible = false;
            lblMensajeF.Visible = false;
            ListarU();
        }

        private void ListarU()
        {
            tableUsuarios.DataSource = datosProfe.Listar();
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

            bool existe = datosProfe.existeProfeClase(idUsuario);

            if(existe == true)
            {
                lblMensajeF.Visible = true;
                lblMensajeF.Text = "DEBE BORRAR LAS CLASES ASOCIADAS AL PROFESOR!";
                tableUsuarios.DataBind();
                ListarU();
            }
            else
            {
                datosProfe.Eliminar(idUsuario);
                tableUsuarios.DataBind();
                ListarU();
            }

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
                                   "que desea eliminar este profesor?')) return;";
                    }
                }
            }
        }

        //METODOS PARA EDITAR PROFESOR
        protected void tableUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ListarU();
            tableUsuarios.EditIndex = e.NewEditIndex;
            tableUsuarios.DataBind();

        }
        
        protected void tableUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblMensajeE.Visible = false;

            int idUsuario = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Value.ToString());
            string expe = ((TextBox)tableUsuarios.Rows[e.RowIndex].Cells[3].Controls[0]).Text; 

            modeloProfe.Id = idUsuario;
            modeloProfe.Experiencia = expe;

            datosProfe.Editar(modeloProfe);

            tableUsuarios.EditIndex = -1;
            tableUsuarios.DataBind();
            ListarU();

            lblMensajeE.Text = "Cambio exitoso!";
            lblMensajeE.Visible = true;
            lblMensajeF.Visible = false;
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
            listaIdUsers.DataBind();
        }

        

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarReg_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            // MultiView1.SetActiveView(View2);
            bool existe = datosProfe.existeProfe(int.Parse(listaIdUsers.SelectedValue));


            if (existe == true)
            {
                txtExperiencia.Text = "EL USUARIO YA EXISTE!!!";
                MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                modeloProfe.Id = int.Parse(listaIdUsers.SelectedValue);
                modeloProfe.Experiencia = txtExperiencia.Text;
               
                txtExperiencia.Text = "";
                lblMensajeE.Text = "Registro guardado!";
                lblMensajeE.Visible = true;
                listaIdUsers.DataBind();
                datosProfe.Guardar(modeloProfe);
                MultiView1.ActiveViewIndex = 0;
                ListarU();
            }
        }
    }
}