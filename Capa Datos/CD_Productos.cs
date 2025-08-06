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
   public class CD_Productos
    {
        public List<Inventario> ListarProductos()
        {
            List<Inventario> lista = new List<Inventario>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "ListarProductos"; // Procedimiento almacenado para listar productos

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Inventario()
                            {
                                Id_producto = Convert.ToInt32(dr["Id_producto"]),
                                producto = dr["Producto"].ToString(),
                                descripcion_inven = dr["Descripcion_inven"].ToString(),
                                fecha_vencimiento = Convert.ToDateTime(dr["Fecha_vencimiento"]),
                                Stock = dr["Stock"] != DBNull.Value ? Convert.ToInt32(dr["Stock"]) : 0,
                                precio_venta = dr["Precio_venta"] != DBNull.Value ? Convert.ToDecimal(dr["Precio_venta"]) : 0,
                                oCategoria = new Categoria
                                {
                                    Id_categoria = Convert.ToInt32(dr["Id_categoria"]),
                                    nombre_categoria = dr["nombre_categoria"].ToString()
                                }
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<Inventario>();
                }
            }
            return lista;
        }

        // Método para insertar un producto
        public void InsertarProducto(string producto, string descripcion, DateTime fechaVencimiento, int idCategoria)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("RegistrarProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@producto", producto);
                command.Parameters.AddWithValue("@descripcion_inven", descripcion);
                command.Parameters.AddWithValue("@fecha_vencimiento", fechaVencimiento);
                command.Parameters.AddWithValue("@Id_categoria", idCategoria);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }



        public void EliminarProducto(int Id_producto)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                SqlCommand command = new SqlCommand("EliminarProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id_producto", Id_producto);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        
    }

}


