using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionIS
{
    public partial class InicioAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] != null)
            {
                lblNombre.Text = Session["nombre"].ToString();
            }

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
           
        }
    }
}