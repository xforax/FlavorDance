using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionIS.Datos
{
    public class ProfesorDatos:Conexion
    {
        public List<ProfesorModel> Listar()
        {
            List<ProfesorModel> lista = new List<ProfesorModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_ListarProf", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ProfesorModel modelo = new ProfesorModel()
                    {
                        Id = int.Parse(lector[0] + ""),
                        Nombre = lector[1] + "",
                        Apellido = lector[2] + "",
                        Experiencia = lector[3] + ""
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

        public bool Eliminar(int idProfe)
        {
            bool rpta;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_EliminarProf", cnn);
                comando.Parameters.AddWithValue("id_usuario", idProfe);
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

        public bool existeProfeClase(int iduser)
        {

            bool usuario = false;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("select cla.id_profesor from clase cla JOIN profesor pro ON(pro.id_usuario = cla.id_profesor) WHERE pro.id_usuario = "+ iduser, cnn);
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

        public bool existeProfe(int iduser)
        {

            bool usuario = false;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT id_usuario FROM profesor WHERE id_usuario = " + iduser, cnn);
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

        public bool Editar(ProfesorModel oprofe)
        {
            bool rpta;

            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_EditarProf", cnn);
                comando.Parameters.AddWithValue("id_usuario", oprofe.Id);
                comando.Parameters.AddWithValue("experiencia", oprofe.Experiencia);
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

        public void Guardar(ProfesorModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_GuardarProf", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id_usuario", modelo.Id));
                comando.Parameters.Add(new SqlParameter("@experiencia", modelo.Experiencia));

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


    }
}