using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionIS.Datos
{
    public class Conexion
    {
        protected SqlConnection cnn;

        protected void Conectar()
        {
            try
            {
                cnn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\forax\\Documents\\UD\\Tesis\\PaginaProyecto\\AplicacionIS\\AplicacionIS\\App_Data\\bdflavor.mdf;Integrated Security=True");
                cnn.Open();

            }catch(Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
        }

        protected void Desconectar()
        {
            try
            {
                cnn.Close();
                cnn.Dispose();

            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}