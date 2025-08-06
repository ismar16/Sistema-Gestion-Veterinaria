using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Capa_Entidad;
using static Capa_Entidad.RolPermiso;


namespace Capa_Datos
    {
        public class CD_RolPermiso
        {
        public List<PermisoConRol> ObtenerPermisosPorRol(int idRol)
        {
            List<PermisoConRol> listaPermisos = new List<PermisoConRol>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT p.Id_permiso, p.nombre_menu, ISNULL(rp.Asignado, 0) as Asignado " +
                    "FROM Permisos p LEFT JOIN RolPermiso rp ON p.Id_permiso = rp.Id_permiso AND rp.Id_rol = @Id_rol",
                    conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id_rol", idRol);

                conexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaPermisos.Add(new PermisoConRol
                        {
                            Id_permiso = Convert.ToInt32(dr["Id_permiso"]),
                            nombre_menu = dr["nombre_menu"].ToString(),
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


