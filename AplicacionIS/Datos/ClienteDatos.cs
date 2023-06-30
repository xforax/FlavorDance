using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AplicacionIS.Datos
{
    public class ClienteDatos:Conexion
    {
        public List<ClienteModel> Listar()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_ListarCli", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ClienteModel modelo = new ClienteModel()
                    {
                        Id = int.Parse(lector[0] + ""),
                        Nombre = lector[1] + "",
                        Apellido = lector[2] + "",
                        Sexo = lector[3] + "",
                        Fecha_nacimiento = Convert.ToDateTime(lector[4] + ""),
                        Fecha_inscripcion = Convert.ToDateTime(lector[5] + ""),
                        Password = lector[6] + ""
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

        public void Guardar(ClienteModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_GuardarCli", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id_usuario", modelo.Id));
                comando.Parameters.Add(new SqlParameter("@id_sexo", modelo.IdSexo));
                comando.Parameters.Add(new SqlParameter("@fecha_nacimiento", modelo.Fecha_nacimiento));
                comando.Parameters.Add(new SqlParameter("@fecha_inscripcion", modelo.Fecha_inscripcion));
                comando.Parameters.Add(new SqlParameter("@contraseña", modelo.Password));

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

        public bool Editar(ClienteModel ousuario)
        {
            bool rpta;

            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_EditarCli", cnn);
                comando.Parameters.AddWithValue("id_usuario", ousuario.Id);
                comando.Parameters.AddWithValue("id_sexo", ousuario.IdSexo);
                comando.Parameters.AddWithValue("fecha_nacimiento", ousuario.Fecha_nacimiento);
                comando.Parameters.AddWithValue("fecha_inscripcion", ousuario.Fecha_inscripcion);
                comando.Parameters.AddWithValue("contraseña", ousuario.Password);
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

        public bool Eliminar(int Idu)
        {
            bool rpta;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_EliminarCli", cnn);
                comando.Parameters.AddWithValue("id", Idu);
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
        /*
        public bool existeCliente(int iduser)
        {

            var cn = new Conexion();
            bool usuario = false;
            SqlCommand cmd;
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                try
                {
                    conexion.Open();
                    String sql = "SELECT id FROM usuario WHERE id = " + iduser;
                    cmd = new SqlCommand(sql, conexion);
                    SqlDataReader dr = cmd.ExecuteReader();
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
                    conexion.Close();
                }

            return usuario;
        }*/
    }
}
