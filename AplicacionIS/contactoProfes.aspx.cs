using AplicacionIS.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionIS
{
    public partial class contactoProfes : System.Web.UI.Page
    {
        ContactProfDatos procesos = new ContactProfDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            tableUsuarios.DataSource = procesos.Listar();
            tableUsuarios.DataBind();
        }
    }
}