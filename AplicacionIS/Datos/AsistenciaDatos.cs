using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionIS.Datos
{
    public class AsistenciaDatos:Conexion
    {
        public List<AsistenciaModel> Listar()
        {
            List<AsistenciaModel> lista = new List<AsistenciaModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_ListarAsistencia", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    AsistenciaModel modelo = new AsistenciaModel()
                    {
                        IdCliente = int.Parse(lector[0] + ""),
                        NombreCom = lector[1] + "",
                        IdDiaCla = int.Parse(lector[2] + ""),
                        HoraCla = int.Parse(lector[3] + ""),
                        DiaCla = lector[4] + "",
                        FechaCla = DateTime.Parse(lector[5] + "")
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

        public bool Eliminar(int id_cli, int hora, int id_dia, string fexxa)
        {
            bool rpta;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_EliminarAsist", cnn);
                comando.Parameters.AddWithValue("id_cliente", id_cli);
                comando.Parameters.AddWithValue("hora", hora);
                comando.Parameters.AddWithValue("id_dia", id_dia);
                comando.Parameters.AddWithValue("fecha", DateTime.Parse(fexxa));
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.ExecuteNonQuery();

                rpta = true;

            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;

            }
            finally
            {
                Desconectar();
            }

            return rpta;
        }

        public void Guardar(AsistenciaModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_GuardarAsist", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id_cliente", modelo.IdCliente));
                comando.Parameters.Add(new SqlParameter("@hora_clase", modelo.HoraCla));
                comando.Parameters.Add(new SqlParameter("@dia_clase", modelo.IdDiaCla));
                comando.Parameters.Add(new SqlParameter("@fecha", modelo.FechaCla));

                comando.ExecuteNonQuery();
                comando.Dispose();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }

        }

        //METODO PARA COMPROBACION DE CRUDS
        public bool existeUsuario(int iduser,int hora, int dia, string fexxa)
        {

            bool usuario = false;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT id_cliente FROM asistencia WHERE id_cliente = " + iduser + " and " +
                    "hora_clase = "+hora+" and dia_clase = "+dia+" and fecha = '"+fexxa+"'", cnn);
                SqlDataReader dr = comando.ExecuteReader();
                Boolean exist = dr.HasRows;
                if (exist)
                {
                    usuario = true;
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                Desconectar();
            }

            return usuario;

        }
        //METODO PARA TRAER INFO
        public List<AsistenciaModel> ListaClase(int hora, int id_dia)
        {
            List<AsistenciaModel> lista = new List<AsistenciaModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_BuscarDetallesAsis", cnn);
                comando.Parameters.AddWithValue("id_dia", id_dia);
                comando.Parameters.AddWithValue("hora", hora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    AsistenciaModel modelo = new AsistenciaModel()
                    {
                        NomGen = lector[0] + "",
                        NomProf = lector[1] + ""
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