using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Capa_Datos
{
    public class CD_Usuario
    {

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Usar el procedimiento almacenado
                    SqlCommand cmd = new SqlCommand("ListarUsuarios", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                Id_usuario = Convert.ToInt32(dr["Id_usuario"]),
                                carnet = Convert.ToInt32(dr["carnet"]),
                                nombres = dr["nombres"].ToString(),
                                apellidos = dr["apellidos"].ToString(),
                                correo = dr["correo"].ToString(),
                                clave = dr["clave"].ToString(),
                                oRol = new Rol
                                {
                                    Id_rol = Convert.ToInt32(dr["Id_rol"]),
                                    // El procedimiento almacenado no devuelve el nombre del rol, solo el ID
                                },
                                oEmpleado = new Empleado
                                {
                                    Id_empleado = Convert.ToInt32(dr["Id_empleado"]),
                                    // El procedimiento almacenado no devuelve el nombre del empleado, solo el ID
                                }
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }





        // Método para insertar un usuario
        public void InsertarUsuario( int carnet, string nombres, string apellidos, string correo, string clave, int Id_rol, int Id_empleado)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("InsertarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

          
                command.Parameters.AddWithValue("@carnet", carnet);
                command.Parameters.AddWithValue("@nombres", nombres);
                command.Parameters.AddWithValue("@apellidos", apellidos);
                command.Parameters.AddWithValue("@correo", correo);
                command.Parameters.AddWithValue("@clave", clave);
                command.Parameters.AddWithValue("@Id_rol", Id_rol);     
                command.Parameters.AddWithValue("@Id_empleado", Id_empleado);    

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarUsuario(int Id_usuario, int carnet, string nombres, string apellidos, string correo, string clave, int Id_rol, int Id_empleado)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("ActualizarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros necesarios
                command.Parameters.AddWithValue("@Id_usuario", Id_usuario);
                command.Parameters.AddWithValue("@carnet", carnet);
                command.Parameters.AddWithValue("@nombres", nombres);
                command.Parameters.AddWithValue("@apellidos", apellidos);
                command.Parameters.AddWithValue("@correo", correo);
                command.Parameters.AddWithValue("@clave", clave);
                command.Parameters.AddWithValue("@Id_rol", Id_rol);
                command.Parameters.AddWithValue("@Id_empleado", Id_empleado);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para eliminar un usuario por ID
        public void EliminarUsuario(int Id_usuario)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("EliminarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id_usuario", Id_usuario);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para buscar un usuario
        public DataTable BuscarUsuario(int? Id_usuario = null, int? carnet = null, string correo = null)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("BuscarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id_usuario", Id_usuario ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@carnet", carnet ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@correo", correo ?? (object)DBNull.Value);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable result = new DataTable();

                connection.Open();
                adapter.Fill(result);

                return result;
            }
        }
    }
}


  
