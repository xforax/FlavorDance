using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AplicacionIS
{
    public partial class InicioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] != null)
            {
                lblNombre.Text = Session["nombre"].ToString();
                lblId.Text = Session["id"].ToString();
            }
        }

        protected void linkClases_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblId.Text);
            Session.Add("id", id);
            Server.Transfer("claseCliente.aspx");
        }
    }
}