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
    public partial class crudClases : System.Web.UI.Page
    {
        ClaseDatos datosClase = new ClaseDatos();
        ClaseModel modeloClase = new ClaseModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            ListarU();
        }

        private void ListarU()
        {
            tableUsuarios.DataSource = datosClase.Listar();
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

            int Hora = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Values[0]);
            int idDia = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Values[1]);
            datosClase.Eliminar(Hora,idDia);

            tableUsuarios.DataBind();
            ListarU();
        }

        //METODO DE CONFIRMACION DE ELIMINACION
        protected void tableUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Visible = false;
            }

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
                                   "que desea eliminar esta clase?')) return;";
                    }
                }
            }

        }

        //METODOS PARA EDITAR CLASE
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
            
            //string persist1 = tableUsuarios.Rows[e.RowIndex].Cells[4].Text;
            string persist2 = tableUsuarios.Rows[e.RowIndex].Cells[5].Text;

            int Hora = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Values[0]);
            int idDia = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Values[1]);
            int idU = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Value.ToString());
            DropDownList dpProfe = (DropDownList)tableUsuarios.Rows[e.RowIndex].Cells[4].FindControl("DropDownList1");
            string idCast1 = dpProfe.SelectedValue.ToString();
            int idProfe = int.Parse(idCast1);
            DropDownList dpGene = (DropDownList)tableUsuarios.Rows[e.RowIndex].Cells[5].FindControl("DropDownList2");
            string idCast2 = dpGene.SelectedValue.ToString();
            int idGene = int.Parse(idCast2);

            modeloClase.Hora = Hora;
            modeloClase.Dia = idDia;
            modeloClase.Profesor = idProfe;
            modeloClase.Genero = idGene;

            datosClase.Editar(modeloClase);

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
            

            modeloClase.Hora = int.Parse(listaHora.SelectedValue);
            modeloClase.Dia = int.Parse(listaDia.SelectedValue);
            modeloClase.Profesor = int.Parse(listaProfesor.SelectedValue);
            modeloClase.Genero = int.Parse(listaGenero.SelectedValue);

            bool existe = datosClase.existeClase(modeloClase.Hora,modeloClase.Dia);

            if(existe == true)
            {
                MultiView1.ActiveViewIndex = 1;
                lblError.Text = "ERROR EN LOS DATOS INGRESADOS";
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
                datosClase.Guardar(modeloClase);
                MultiView1.ActiveViewIndex = 0;

                ListarU();
            }

            //listaIdUsuarios.DataBind();
            
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
           
            MultiView1.ActiveViewIndex = 0;
            ListarU();

        }


    }
}