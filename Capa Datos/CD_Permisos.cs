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
                    string query = "Select Id_permiso, nombre_menu from Permisos";
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


                               

                            });

                        }

                    }
                }
                catch (Exception e)
                {
                    permiso = new List<Permisos>();
                }
            }

            return permiso;
        }



        public void InsertarPermisos(string nombre_menu)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("InsertarPermiso", conexion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre_menu", nombre_menu);
                


                conexion.Open();
                command.ExecuteNonQuery();
            }
     
        }



        public bool EliminarPermiso(int Id_permiso)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EliminarPermiso", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_permiso", Id_permiso);

                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    // Reiniciar el IDENTITY después de eliminar
                    SqlCommand resetIdent = new SqlCommand("DBCC CHECKIDENT ('Permisos', RESEED, 0)", conexion);
                    resetIdent.ExecuteNonQuery();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


    }

}

