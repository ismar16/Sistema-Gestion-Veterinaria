using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;



using Capa_Entidad;

namespace Capa_Datos
{
    public class CD_Compras
    {
        public List<Compras> ListarCompras()
        {
            List<Compras> lista = new List<Compras>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "ListarCompras"; // Procedimiento almacenado para listar compras

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // Leer los datos de la primera consulta (detalles de las compras)
                        while (dr.Read())
                        {
                            lista.Add(new Compras()
                            {
                                Id_compra = Convert.ToInt32(dr["Id_compra"]),
                                fecha_compra = Convert.ToDateTime(dr["fecha_compra"]),
                                cantidadProducto = Convert.ToInt32(dr["cantidadProducto"]),
                                precioCompra = Convert.ToDecimal(dr["precioCompra"]),
                                subtotal = Convert.ToDecimal(dr["subtotal"]),
                                totalCompra = Convert.ToDecimal(dr["totalCompra"]),
                                precio_venta = Convert.ToDecimal(dr["precio_venta"]),
                                oInventario = new Inventario
                                {
                                    Id_producto = Convert.ToInt32(dr["Id_producto"]),
                                    producto = dr["producto"].ToString()
                                },
                                oCategoria = new Categoria
                                {
                                    Id_categoria = Convert.ToInt32(dr["Id_categoria"]),
                                    nombre_categoria = dr["nombre_categoria"].ToString()
                                },
                                oEmpleado = new Empleado
                                {
                                    Id_empleado = Convert.ToInt32(dr["Id_empleado"]),
                                    nombre_empleado = dr["nombre_empleado"].ToString()
                                }
                            });
                        }

                        // Mover al siguiente conjunto de resultados (totalCompra)
                        if (dr.NextResult() && dr.Read())
                        {
                            decimal totalCompra = Convert.ToDecimal(dr["totalCompra"]);

                        }
                    }

                }
                catch (Exception)
                {
                    lista = new List<Compras>();
                }
            }
            return lista;
        }

        public string InsertarCompra(DateTime fechaCompra, int Id_producto,
                                       int cantidadProducto, decimal precioCompra,
                                       decimal totalCompra, decimal precioVenta,
                                       int Id_categoria, int Id_empleado)
        {
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);

            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("InsertarCompra", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros
                cmd.Parameters.AddWithValue("@fecha_compra", fechaCompra);
                cmd.Parameters.AddWithValue("@Id_producto", Id_producto);
                cmd.Parameters.AddWithValue("@cantidadProducto", cantidadProducto);
                cmd.Parameters.AddWithValue("@precioCompra", precioCompra);
                cmd.Parameters.AddWithValue("@totalCompra", totalCompra);
                cmd.Parameters.AddWithValue("@precio_venta", precioVenta);
                cmd.Parameters.AddWithValue("@Id_categoria", Id_categoria);
                cmd.Parameters.AddWithValue("@Id_empleado", Id_empleado);

                cmd.ExecuteNonQuery();
                return "Compra registrada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                SqlCon.Close();
            }
        }

        public void ActualizarCompra(Compras compra)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "ActualizarCompra";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_compra", compra.Id_compra);
                    cmd.Parameters.AddWithValue("@fecha_compra", compra.fecha_compra);
                    cmd.Parameters.AddWithValue("@Id_producto", compra.oInventario.Id_producto);
                    cmd.Parameters.AddWithValue("@cantidadProducto", compra.cantidadProducto);
                    cmd.Parameters.AddWithValue("@precioCompra", compra.precioCompra);
                    cmd.Parameters.AddWithValue("@precio_venta", compra.precio_venta);
                    cmd.Parameters.AddWithValue("@Id_categoria", compra.oCategoria.Id_categoria);
                    cmd.Parameters.AddWithValue("@Id_empleado", compra.oEmpleado.Id_empleado);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar la compra: " + ex.Message);
                }
            }
        }


        public void EliminarCompra(int idCompra)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "EliminarCompra"; // Nombre del procedimiento almacenado

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_compra", idCompra); // Agregar el parámetro

                    conexion.Open();
                    cmd.ExecuteNonQuery(); // Ejecutar el procedimiento almacenado
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la compra: " + ex.Message);
                }

            }

        }
    }
}
