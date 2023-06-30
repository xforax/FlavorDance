using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionIS.Datos
{
    public class ReporteCliDatos:Conexion
    {
        public List<ReporteCliModel> Listar(int idcliente)
        {
            List<ReporteCliModel> lista = new List<ReporteCliModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ObtenerInformacionEstudiante", cnn);
                comando.Parameters.AddWithValue("id_usuario", idcliente);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ReporteCliModel modelo = new ReporteCliModel()
                    {
                        Idcli = int.Parse(lector[0] + ""),
                        Nombre = lector[1] + "",
                        Apellido = lector[2] + "",
                        Edad = int.Parse(lector[3] + ""),
                        Genero = lector[4] + "",
                        Hora = int.Parse(lector[5] + "")
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