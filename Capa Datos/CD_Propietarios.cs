using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Capa_Entidad;

namespace Capa_Datos
{
    public class CD_Propietarios
    {


        public List<Propietario> ListarPropietarios()
        {
            List<Propietario> listapropietarios = new List<Propietario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    oconexion.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Propietario", oconexion))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Crear una instancia de Empleado con los datos del registro
                                Propietario propietario = new Propietario
                                {
                                    Id_propietario = Convert.ToInt32(reader["Id_propietario"]),
                                    nombres_propietario = reader["nombres_propietario"].ToString(),
                                    apellidos_propietario = reader["apellidos_propietario"].ToString(),
                                    correo_propietario = reader["correo_propietario"].ToString(),
                                    telefono_propietario = reader["telefono_propietario"].ToString(),
                                    Direccion_propietario = reader["Direccion"].ToString(),

                                };

                                // Agregar a la lista
                                listapropietarios.Add(propietario);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar el error
                throw new Exception("Error al listar clientes: " + ex.Message);
            }

            return listapropietarios;
        }
        public string RegistrarPropietario(Propietario propietario)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Preparar la consulta para insertar el propietario
                    SqlCommand cmd = new SqlCommand("InsertarPropietario", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@nombres_propietario", propietario.nombres_propietario);
                    cmd.Parameters.AddWithValue("@apellidos_propietario", propietario.apellidos_propietario);
                    cmd.Parameters.AddWithValue("@correo_propietario", propietario.correo_propietario);
                    cmd.Parameters.AddWithValue("@telefono_propietario", propietario.telefono_propietario);
                    cmd.Parameters.AddWithValue("@Direccion", propietario.Direccion_propietario);

                    // Parámetro de salida
                    SqlParameter outputMessage = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                    outputMessage.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputMessage);

                    // Ejecutar la consulta
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener el mensaje de salida
                    return outputMessage.Value.ToString();
                }
                catch (Exception ex)
                {
                    return $"Error al insertar propietario: {ex.Message}";
                }
            }


        }
        public bool EliminarPropietario(int Id_propietario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.cadena))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("EliminarPropietario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id_propietario", Id_propietario);

                        int filasAfectadas = command.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error  al eliminar propietario: " + ex.Message);





            }
        }
    }

}
