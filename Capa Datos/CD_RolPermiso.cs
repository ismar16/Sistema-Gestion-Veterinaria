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
        public class CD_RolPermiso
        {
            // Método para obtener los permisos asignados a un rol
            public List<RolPermiso> ObtenerPermisosPorRol(int Id_rol)
            {
                List<RolPermiso> listaPermisos = new List<RolPermiso>();
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("ObtenerPermisosPorRol", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_rol", Id_rol);

                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaPermisos.Add(new RolPermiso
                            {
                                Id_rol = Id_rol,
                                Id_permiso = Convert.ToInt32(dr["Id_permiso"]),
                                Asignado = Convert.ToBoolean(dr["Asignado"])
                            });
                        }
                    }
                }
                return listaPermisos;
            }

            // Método para asignar un permiso a un rol
            public void AsignarPermiso(int Id_rol, int Id_permiso)
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("AsignarPermisoARol", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_rol", Id_rol);
                    cmd.Parameters.AddWithValue("@Id_permiso", Id_permiso);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Método para quitar un permiso de un rol
            public void QuitarPermiso(int Id_rol, int Id_Permiso)
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("QuitarPermisoDeRol", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_rol", Id_rol);
                    cmd.Parameters.AddWithValue("@Id_permiso", Id_Permiso);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
}


