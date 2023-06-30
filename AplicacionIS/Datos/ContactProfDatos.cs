using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionIS.Datos
{
    public class ContactProfDatos:Conexion
    {
        public List<ContactoProfModel> Listar()
        {
            List<ContactoProfModel> lista = new List<ContactoProfModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_ContactoProfesores", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ContactoProfModel modelo = new ContactoProfModel()
                    {
                        Nombre = lector[0] + "",
                        Apellido = lector[1] + "",
                        Telefono = lector[2] + "",
                        Correo = lector[3] + "",
                        Experiencia = lector[4] + ""
                    };
                    lista.Add(modelo);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return lista;
        }
    }
}