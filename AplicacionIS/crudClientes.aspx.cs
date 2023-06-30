using AplicacionIS.Datos;
using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionIS
{

    public partial class crudClientes : System.Web.UI.Page
    {
        ClienteDatos cliente = new ClienteDatos();
        ClienteModel modelcliente = new ClienteModel();

        //CARGAR REGISTROS EN EL GRIDVIEW
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            lblMensajeE.Visible = false;
            lblMensajeF.Visible = false;
            ListarU();
        }

        private void ListarU()
        {
            tableUsuarios.DataSource = cliente.Listar();
            tableUsuarios.DataBind();

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;

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
            cliente.Eliminar(idUsuario);


            tableUsuarios.DataSource = cliente.Listar();
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
            DropDownList dp = (DropDownList)tableUsuarios.Rows[e.RowIndex].Cells[4].FindControl("listaSexo");
            int idSexo = dp.SelectedIndex+1;
            string Fecha_nac = ((TextBox)tableUsuarios.Rows[e.RowIndex].Cells[5].FindControl("TextBox1")).Text;
            string Fecha_ins = ((TextBox)tableUsuarios.Rows[e.RowIndex].Cells[6].FindControl("TextBox2")).Text;
            string Contra = ((TextBox)tableUsuarios.Rows[e.RowIndex].Cells[7].FindControl("TextBox3")).Text;
            modelcliente.Id = idU;
            modelcliente.IdSexo = idSexo;
            modelcliente.Fecha_nacimiento = Convert.ToDateTime(Fecha_nac);
            modelcliente.Fecha_inscripcion = Convert.ToDateTime(Fecha_ins);
            modelcliente.Password = Contra;
            cliente.Editar(modelcliente);

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
        }

        protected void btnGuardarReg_Click(object sender, EventArgs e)
        {
            modelcliente.Id = int.Parse(listaIdUsuarios.SelectedValue);
            modelcliente.IdSexo = int.Parse(listaSexo.SelectedValue);
            modelcliente.Fecha_nacimiento= Convert.ToDateTime(txtFechaNaci.Text);
            modelcliente.Fecha_inscripcion = Convert.ToDateTime(txtFechaInsc.Text);
            modelcliente.Password = txtPassword.Text;

            txtPassword.Text = "";
            txtFechaInsc.Text = "";
            txtFechaNaci.Text = "";

            cliente.Guardar(modelcliente);
            listaIdUsuarios.DataBind();
            MultiView1.ActiveViewIndex = 0;

            ListarU();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtFechaInsc.Text = "";
            txtFechaNaci.Text = "";
            MultiView1.ActiveViewIndex = 0;
            ListarU();
        }
    }
}