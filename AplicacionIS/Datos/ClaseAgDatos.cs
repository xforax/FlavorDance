using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionIS.Datos
{
    public class ClaseAgDatos:Conexion
    {
        public List<ClaseAgModel> Horario(int idcliente)
        {
            List<ClaseAgModel> lista = new List<ClaseAgModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_HorarioCliente", cnn);
                comando.Parameters.AddWithValue("id_usuario", idcliente);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ClaseAgModel modelo = new ClaseAgModel()
                    {
                        Id = int.Parse(lector[0] + ""),
                        Hora = int.Parse(lector[1] + ""),
                        NomDia = lector[2] + "",
                        Estado = lector[3] + "",
                        Dia = int.Parse(lector[4] + "")
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
       
        public List<ClaseAgModel> Listar(int idcliente)
        {
            List<ClaseAgModel> lista = new List<ClaseAgModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_ListarClassAg", cnn);
                comando.Parameters.AddWithValue("id_usuario", idcliente);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ClaseAgModel modelo = new ClaseAgModel()
                    {
                        Id = int.Parse(lector[0] + ""),
                        Hora = int.Parse(lector[1] + ""),
                        NomDia = lector[2] + "",
                        Estado = lector[3] + "",
                        Dia = int.Parse(lector[4] + "")
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

        public List<ClaseAgModel> ListaAgenda(int hora, int id_dia)
        {
            List<ClaseAgModel> lista = new List<ClaseAgModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_BuscarDetallesClase", cnn);
                comando.Parameters.AddWithValue("id_dia", id_dia);
                comando.Parameters.AddWithValue("hora", hora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ClaseAgModel modelo = new ClaseAgModel()
                    {
                        NomGenero = lector[2] + "",
                        NomProf = lector[3] + ""
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

        public void Guardar(ClaseAgModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_GuardarClaseAg", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id_cliente", modelo.Id));
                comando.Parameters.Add(new SqlParameter("@hora_clase", modelo.Hora));
                comando.Parameters.Add(new SqlParameter("@id_dia", modelo.Dia));
                comando.Parameters.Add(new SqlParameter("@id_estado", modelo.IdEstado));
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

        public bool Editar(ClaseAgModel oclase)
        {
            bool rpta;

            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_EditarClaseAg", cnn);
                comando.Parameters.AddWithValue("id_cliente", oclase.Id);
                comando.Parameters.AddWithValue("hora_clase", oclase.Hora);
                comando.Parameters.AddWithValue("id_dia", oclase.Dia);
                comando.Parameters.AddWithValue("id_estado", oclase.IdEstado);
                comando.CommandType = CommandType.StoredProcedure;
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


    }
}