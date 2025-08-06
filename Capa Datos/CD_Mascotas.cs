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
   public  class CD_Mascotas
    {
        public List<Mascotas> ListarMascotas()
        {
            List<Mascotas> lista = new List<Mascotas>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "ListarMascotas";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Mascotas()
                            {
                                Id_mascota = Convert.ToInt32(dr["Id_mascota"]),
                                nombre_mascota = dr["nombre_mascota"].ToString(),
                                especie = dr["especie"].ToString(),
                                raza = dr["raza"].ToString(),
                                fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]),


                                oPropietario = new Propietario
                                {
                                    Id_propietario = Convert.ToInt32(dr["Id_propietario"]),

                                },
                               

                            });
                        }
                    }
                }
                catch (Exception)
                {

                    lista = new List<Mascotas>();
                }
            }
            return lista;
        }

        public void InsertarMascota(string nombre_mascota, string especie,string raza ,DateTime fecha_nacimiento, int Id_propietario)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("sp_InsertarMascota", oconexion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre_mascota", nombre_mascota);
                command.Parameters.AddWithValue("@especie", especie);
                command.Parameters.AddWithValue("@raza",raza );
                command.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);
                command.Parameters.AddWithValue("@Id_propietario", Id_propietario);

                oconexion.Open();
                command.ExecuteNonQuery();
            }
        }
        public static void EliminarMascota(int Id_mascota)
        {
            using (SqlConnection conn = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("EliminarMascota", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_mascota", Id_mascota);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la mascota: " + ex.Message);
                }
            }
        }

    }
}
