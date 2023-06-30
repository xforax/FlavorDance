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
    public partial class crudAsistencias : System.Web.UI.Page
    {
        AsistenciaDatos datosAsist = new AsistenciaDatos();
        AsistenciaModel modeloAsist = new AsistenciaModel();
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
            tableUsuarios.DataSource = datosAsist.Listar();
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
            
            int IdCli = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Values[0]);
            int Hora = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Values[1]);
            int Id_dia = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Values[2]);
            string Fecha = tableUsuarios.DataKeys[e.RowIndex].Values[3].ToString();

            bool confirm  = datosAsist.Eliminar(IdCli,Hora,Id_dia,Fecha);
            if (confirm)
            {
                lblMensajeE.Text = "Registro borrado con exito!";
                lblMensajeE.Visible = true;
            }
            else
            {
                lblMensajeF.Text = "Error al borrar registro owo";
                lblMensajeF.Visible = true;
            }
            tableUsuarios.DataBind();
            ListarU();

        }

        protected void tableUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          /*  if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Visible = false;
            }
            */
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


        protected void btnCrear_Click(object sender, EventArgs e)
        {
            lblMensajeE.Visible = false;
            lblMensajeF.Visible = false;

            MultiView1.ActiveViewIndex = 1;

        }
        protected void listaDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;

        }

        protected void listaHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            int dia = int.Parse(listaDia.SelectedValue);
            int hora = int.Parse(listaHora.SelectedValue);
            listaTemporal.DataSource = datosAsist.ListaClase(hora,dia);
            listaTemporal.DataBind();
        }
        //CARGA OPCION POR DEFECTO DEL DROPDOWNLIST
        protected void MyListDataBound(object sender, EventArgs e)
        {
            listaHora.Items.Insert(0, new ListItem("--Seleccione Hora--", ""));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            //PROCEDIMIENTO PARA GUARDAR REGISTRO DE CLASE
            int id_cli = int.Parse(listaAsistentes.SelectedValue);
            int hora = int.Parse(listaHora.SelectedValue);
            int id_dia = int.Parse(listaDia.SelectedValue);
            

            modeloAsist.IdCliente = id_cli;
            modeloAsist.HoraCla = hora;
            modeloAsist.IdDiaCla = id_dia;
            modeloAsist.FechaCla = DateTime.Parse(txtFecha.Text);

            datosAsist.Guardar(modeloAsist);
            tableUsuarios.DataBind();
            ListarU();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }
    }
}