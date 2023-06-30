using AplicacionIS.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AplicacionIS.Datos
{
    public class UsuarioDatos:Conexion
    {
        public void Guardar(UsuarioModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_GuardarU",cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id", modelo.Id));
                comando.Parameters.Add(new SqlParameter("@nombre", modelo.Nombre));
                comando.Parameters.Add(new SqlParameter("@apellido", modelo.Apellido));
                comando.Parameters.Add(new SqlParameter("@telefono", modelo.Telefono));
                comando.Parameters.Add(new SqlParameter("@direccion", modelo.Direccion));
                comando.Parameters.Add(new SqlParameter("@correo", modelo.Correo));

                comando.ExecuteNonQuery();
                comando.Dispose();

            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }

        }

        public List<UsuarioModel> Listar()
        {
            List<UsuarioModel> lista = new List<UsuarioModel>(); 
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_ListarU", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    UsuarioModel modelo = new UsuarioModel()
                    {
                        Id = int.Parse(lector[0] + ""),
                        Nombre = lector[1]+"",
                        Apellido = lector[2]+"",
                        Telefono = lector[3]+"",
                        Direccion = lector[4]+"",
                        Correo = lector[5]+""
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

        public bool Editar(UsuarioModel ousuario)
        {
            bool rpta;

            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_EditarU", cnn);
                comando.Parameters.AddWithValue("id", ousuario.Id);
                comando.Parameters.AddWithValue("nombre", ousuario.Nombre);
                comando.Parameters.AddWithValue("apellido", ousuario.Apellido);
                comando.Parameters.AddWithValue("telefono", ousuario.Telefono);
                comando.Parameters.AddWithValue("direccion", ousuario.Direccion);
                comando.Parameters.AddWithValue("correo", ousuario.Correo);
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
                SqlCommand comando = new SqlCommand("sp_EliminarU", cnn);
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

        public UsuarioModel Obtener(string correoU)
        {
            var oUsuario = new UsuarioModel();

            Conectar();
            {

                SqlCommand comando = new SqlCommand("sp_ObtenerU", cnn);
                comando.Parameters.AddWithValue("correo", correoU);
                comando.CommandType = CommandType.StoredProcedure;

                using (var dr = comando.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oUsuario.Id = Convert.ToInt32(dr["id"]);
                        oUsuario.Nombre = dr["nombre"].ToString();
                        oUsuario.Apellido = dr["apellido"].ToString();
                        oUsuario.Telefono = dr["telefono"].ToString();
                        oUsuario.Direccion = dr["direccion"].ToString();
                        oUsuario.Correo = dr["correo"].ToString();
                    }
                }
            }

            return oUsuario;
        }

        public AdminModel ObtenerA(string correoU)
        {
            var oUsuario = new AdminModel();

            Conectar();
            {

                SqlCommand comando = new SqlCommand("sp_ObtenerA", cnn);
                comando.Parameters.AddWithValue("correo", correoU);
                comando.CommandType = CommandType.StoredProcedure;

                using (var dr = comando.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oUsuario.Correo = dr["correo"].ToString();
                        oUsuario.Nombre = dr["nombre"].ToString();
                        oUsuario.Password = dr["contraseña"].ToString();
                    }
                }
            }

            return oUsuario;
        }

        //METODO PARA COMPROBACION DE CRUDS
        public bool existeUsuario(int iduser)
        {

            bool usuario = false;
            Conectar();
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT id FROM usuario WHERE id = " + iduser,cnn);
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

        //METODO DE COMPROBACION DE ADMINISTRADOR PARA LOGIN
        public bool existeUsuarioLoginA(string correou)
        {
            bool usuario = false;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT correo FROM administrador WHERE correo = '" + correou + "'", cnn);
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

        //METODO DE COMPROBACION DE CLIENTE PARA LOGIN
        public bool existeUsuarioLoginC(string correou)
        {
            bool usuario = false;
            Conectar();
            try
            {

                SqlCommand comando = new SqlCommand("SELECT correo FROM usuario WHERE correo = '" + correou + "'", cnn);
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

        //METODO QUE COMPRUEBA CORREO Y PASSWORD DE ADMINISTRADOR
        public bool comprobarDatosAdmin(string correou, string password)
        {

            bool usuario = false;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT correo FROM administrador WHERE correo = '" + correou + "' and contraseña = '" + password + "'",cnn);
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

        //METODO QUE COMPRUEBA CORREO Y PASSWORD DE CLIENTE
        public bool comprobarDatosCli(string correou, string password)
        {

            bool usuario = false;
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT us.correo FROM usuario us JOIN" +
                    " cliente cli ON (cli.id_usuario = us.id)" +
                    "               WHERE us.correo = '"+correou+"' AND cli.contraseña = '"+password+"'", cnn);
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

    }
}