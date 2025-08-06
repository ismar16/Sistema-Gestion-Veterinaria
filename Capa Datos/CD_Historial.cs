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
   public  class CD_Historial
    {


        public List<Historialclinico> ListarHistorial()
        {
            List<Historialclinico> lista = new List<Historialclinico>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "ListarHistorialClinico"; // Nombre del procedimiento almacenado

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Historialclinico()
                            {
                                Id_historial = Convert.ToInt32(dr["Id_historial"]),
                                fecha = Convert.ToDateTime(dr["Fecha"]),
                                diagnostico = dr["diagnostico"].ToString(),
                                tratamiento = dr["tratamiento"].ToString(),

                                // Relación con la tabla Mascota
                                oMascotas = new Mascotas
                                {
                                    Id_mascota = Convert.ToInt32(dr["Id_mascota"]),
                                    nombre_mascota = dr["Nombre_mascota"].ToString()
                                },

                                // Relación con la tabla Empleado (veterinario)
                                oEmpleado = new Empleado
                                {
                                    Id_empleado = Convert.ToInt32(dr["Id_empleado"]),
                                    nombre_empleado = dr["NombreVeterinario"].ToString()
                                }
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<Historialclinico>(); // Devolver una lista vacía en caso de error
                }
            }
            return lista;
        }



        public bool InsertarHistorial(Historialclinico historial)
        {
            bool resultado = false;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "InsertarHistorial"; // Nombre del procedimiento almacenado

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros del procedimiento almacenado
                    cmd.Parameters.AddWithValue("@fecha_historial", historial.fecha);
                    cmd.Parameters.AddWithValue("@descripcion", historial.descripcion);
                    cmd.Parameters.AddWithValue("@Id_mascota", historial.oMascotas.Id_mascota);
                    cmd.Parameters.AddWithValue("@Id_empleado", historial.oEmpleado.Id_empleado);
                    cmd.Parameters.AddWithValue("@diagnostico", historial.diagnostico);
                    cmd.Parameters.AddWithValue("@tratamiento", historial.tratamiento);
                    cmd.Parameters.AddWithValue("@medicamento", historial.medicamento);

                    oconexion.Open();

                    // Ejecutar el comando
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = filasAfectadas > 0; // True si al menos una fila fue afectada
                }
                catch (Exception)
                {
                    resultado = false; // En caso de error, devolver false
                }
            }

            return resultado;
        }
        // Esto es para cargar solo los veterinarios en el combo de empleado ya que solo los veterinarios pueden ingresar un historial

        public List<Empleado> ObtenerVeterinarios()
        {
            List<Empleado> listaVeterinarios = new List<Empleado>();
            using (SqlConnection oconexion = new  SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "ObtenerVeterinarios";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaVeterinarios.Add(new Empleado()
                            {
                                Id_empleado = Convert.ToInt32(dr["Id_empleado"]),
                                nombre_empleado = dr["NombreCompleto"].ToString()
                            });
                        }
                    }
                }
                catch (Exception )
                {
                    // Manejo de errores
                    listaVeterinarios = new List<Empleado>();
                }
            }
            return listaVeterinarios;
        }


    }
}
