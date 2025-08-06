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
    public class CD_Empleados
    {


        // Método para listar todos los empleados
        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    oconexion.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Empleado", oconexion))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Crear una instancia de Empleado con los datos del registro
                                Empleado empleado = new Empleado
                                {
                                    Id_empleado = Convert.ToInt32(reader["Id_empleado"]),
                                    nombre_empleado = reader["nombre_empleado"].ToString(),
                                    apellido_empleado = reader["apellido_empleado"].ToString(),
                                    correo_empleado = reader["correo_empleado"].ToString(),
                                    telefono_empleado = reader["telefono_empleado"].ToString(),
                                    cargo_empleado = reader["cargo_empleado"].ToString(),
                                    salario_empleado = reader.IsDBNull(reader.GetOrdinal("salario_empleado"))
                                        ? 0 // Valor predeterminado en caso de que sea NULL en la BD
                                        : Convert.ToDecimal(reader["salario_empleado"])
                                };

                                // Agregar a la lista
                                listaEmpleados.Add(empleado);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar el error
                throw new Exception("Error al listar empleados: " + ex.Message);
            }

            return listaEmpleados;
        }



        // Método para insertar un nuevo empleado
        public void InsertarEmpleado(string nombre, string apellido, string correo, string telefono, string cargo, decimal salario)
        {
            {
                using (SqlConnection connection = new SqlConnection(Conexion.cadena)) // Usa tu cadena de conexión
                {
                    // Define el comando para el procedimiento almacenado
                    SqlCommand command = new SqlCommand("InsertarEmpleado", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros al procedimiento almacenado
                    command.Parameters.AddWithValue("@nombre_empleado", nombre);
                    command.Parameters.AddWithValue("@apellido_empleado", apellido);
                    command.Parameters.AddWithValue("@correo_empleado", correo);
                    command.Parameters.AddWithValue("@telefono_empleado", telefono);
                    command.Parameters.AddWithValue("@cargo_empleado", cargo);
                    command.Parameters.AddWithValue("@salario_empleado", salario);

                    // Abrir la conexión y ejecutar el comando
                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }

        }

        public bool EliminarEmpleado(int Id_empleado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("EliminarEmpleado", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Empleado", Id_empleado);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al eliminar el empleado: " + ex.Message);
            }
        }

    }
}



