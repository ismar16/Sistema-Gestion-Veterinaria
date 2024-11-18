using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using Capa_Datos;
using Capa_Entidad;


namespace Capa_Datos

{
    public class CD_Rol
    {


        public List<Rol> ListarRoles()
        {
            List<Rol> roles = new List<Rol>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {

                try
                {
                    string query = "Select Id_rol, nombre_rol from Rol";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            roles.Add(new Rol()
                            {

                                Id_rol = Convert.ToInt32(dr["Id_rol"]),
                                nombre_rol = dr["nombre_rol"].ToString(),




                            });

                        }

                    }
                }
                catch (Exception e)
                {
                    roles = new List<Rol>();
                }
            }

            return roles;
        }



        public void InsertarRol(string nombre)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("InsertarRol", conexion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre_rol", nombre);


                conexion.Open();
                command.ExecuteNonQuery();
            }
        }
    }

}

