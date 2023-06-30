using AplicacionIS.Datos;
using AplicacionIS.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionIS
{
    public partial class Prueba_Horario : System.Web.UI.Page
    {
        int idCliente = 0;
        int idHora = 0;
        ClaseAgDatos datosClAg = new ClaseAgDatos();
        ClaseAgModel claseAg = new ClaseAgModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            
                lblidCliente.Text = "1001426369";
            

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            ListarU();
        }

        private void ListarU()
        {
            idCliente = int.Parse(lblidCliente.Text);
            tableUsuarios.DataSource = datosClAg.Listar(idCliente);
            tableUsuarios.DataBind();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = lblidCliente.Text;
            MultiView1.ActiveViewIndex = 1;
            //SlistaDia.Items.Insert(0, new ListItem("SELECCIONE-UN-DIA", "0"));
        }

        protected void btnGuardarReg_Click(object sender, EventArgs e)
        {
            //PROCEDIMIENTO PARA GUARDAR REGISTRO DE CLASE
            int id_cli = int.Parse(txtIdCliente.Text);
            int hora = int.Parse(listaHoraDia.SelectedValue);
            int id_dia = int.Parse(listaDia.SelectedValue);
            int estado = 200;

            claseAg.Id = id_cli;
            claseAg.Hora = hora;
            claseAg.Dia = id_dia;
            claseAg.IdEstado = estado;

            datosClAg.Guardar(claseAg);
            tableUsuarios.DataBind();
            ListarU();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void listaHoraDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;

            int hora = int.Parse(listaHoraDia.SelectedValue);
            int id_dia = int.Parse(listaDia.SelectedValue);

            listaTemporal.DataSource = datosClAg.ListaAgenda(hora, id_dia);
            listaTemporal.DataBind();
        }

        protected void MyListDataBound(object sender, EventArgs e)
        {
            listaHoraDia.Items.Insert(0, new ListItem("--Seleccione Hora--", ""));
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

            int idU = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Value.ToString());
            int Hora = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Values[1]);
            int idDia = Convert.ToInt32(tableUsuarios.DataKeys[e.RowIndex].Values[2]);


            DropDownList dpEst = (DropDownList)tableUsuarios.Rows[e.RowIndex].Cells[4].FindControl("DropDownList1");
            string idCast2 = dpEst.SelectedValue.ToString();
            int idEstado = int.Parse(idCast2);

            claseAg.IdEstado = idEstado;
            claseAg.Id = idU;
            claseAg.Hora = Hora;
            claseAg.Dia = idDia;

            datosClAg.Editar(claseAg);

            tableUsuarios.EditIndex = -1;
            tableUsuarios.DataBind();
            ListarU();

            lblMensajeE.Text = "Cambio exitoso!";
            lblMensajeE.Visible = true;
            lblMensajeF.Visible = false;
        }

        protected void tableUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
            }
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

    }
}