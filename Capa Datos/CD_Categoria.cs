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
   public class CD_Categoria
    {

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {

                try
                {
                    string query = "Select Id_categoria, nombre_categoria from Categoria";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            categorias.Add(new Categoria()
                            {

                                Id_categoria = Convert.ToInt32(dr["Id_categoria"]),
                                nombre_categoria = dr["nombre_categoria"].ToString(),




                            });

                        }

                    }
                }
                catch (Exception )
                {
                    categorias = new List<Categoria>();
                }
            }

            return categorias;
        }



        public void InsertarCategorias(string nombre)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("InsertarCategoria", conexion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre_categoria", nombre);


                conexion.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
