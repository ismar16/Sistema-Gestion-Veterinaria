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
    public class CD_Permisos
    {

        public List<Permisos> ListarPermisos()
        {
            List<Permisos> permiso = new List<Permisos>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {

                try
                {
                    string query = "Select Id_permiso, nombre_menu, Parent_id from Permisos";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            permiso.Add(new Permisos()
                            {

                                Id_permiso = Convert.ToInt32(dr["Id_permiso"]),
                                nombre_menu = dr["nombre_menu"].ToString(),
                                Parent_id = dr["Parent_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["Parent_id"]),



                            });

                        }

                    }
                }
                catch (Exception )
                {
                    permiso = new List<Permisos>();
                }
            }

            return permiso;
        }



        public void InsertarPermisos(string nombre_menu, int? Parent_id)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("InsertarPermiso", conexion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre_menu", nombre_menu);
                command.Parameters.AddWithValue("@Parent_id", Parent_id ?? (object)DBNull.Value);




                conexion.Open();
                command.ExecuteNonQuery();
            }

        }



        public void EliminarPermiso(int Id_permiso)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("EliminarPermiso", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id_permiso", Id_permiso);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}


