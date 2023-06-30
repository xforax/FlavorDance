using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionIS.Datos
{
    public class ClaseDatos:Conexion
    {
        public List<ClaseModel> Listar()
        {
            List <ClaseModel> lista = new List<ClaseModel>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_ListarClass", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ClaseModel modelo = new ClaseModel()
                    {
                        Hora = int.Parse(lector[0]+""),
                        Dia = int.Parse(lector[1]+""),
                        NomDia = lector[2] + "",
                        NomProf = lector[3] + "",
                        NomGen = lector[4] + ""
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

        public bool Eliminar(int Hora, int Dia)
        {
            bool rpta;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_EliminarClass", cnn);
                comando.Parameters.AddWithValue("hora", Hora);
                comando.Parameters.AddWithValue("id_dia", Dia);
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
        public bool Editar(ClaseModel oclase)
        {
            bool rpta;

            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_EditarClass", cnn);
                comando.Parameters.AddWithValue("hora", oclase.Hora);
                comando.Parameters.AddWithValue("id_dia", oclase.Dia);
                comando.Parameters.AddWithValue("id_profesor", oclase.Profesor);
                comando.Parameters.AddWithValue("id_genero", oclase.Genero);
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

        public void Guardar(ClaseModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_GuardarClass", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@hora", modelo.Hora));
                comando.Parameters.Add(new SqlParameter("@id_dia", modelo.Dia));
                comando.Parameters.Add(new SqlParameter("@id_profesor", modelo.Profesor));
                comando.Parameters.Add(new SqlParameter("@id_genero", modelo.Genero));

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

        public bool existeClase(int hora, int dia)
        {

            bool clase = false;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT hora,id_dia FROM clase WHERE hora = " + hora + " and id_dia = "+ dia, cnn);
                SqlDataReader dr = comando.ExecuteReader();
                Boolean exist = dr.HasRows;
                if (exist)
                {
                    clase = true;
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                Desconectar();
            }

            return clase;

        }

        public bool usuariosConClase (int hora, int dia)
        {

            bool clase = false;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT hora,id_dia FROM clase WHERE hora = " + hora + " and id_dia = " + dia, cnn);
                SqlDataReader dr = comando.ExecuteReader();
                Boolean exist = dr.HasRows;
                if (exist)
                {
                    clase = true;
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                Desconectar();
            }

            return clase;

        }


    }
}