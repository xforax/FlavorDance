using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;
using AplicacionIS.Datos;

namespace AplicacionIS
{
    public partial class DetalleClientes : System.Web.UI.Page
    {
        ReporteCliDatos reportProc = new ReporteCliDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.Refresh();
        }
    }
}