using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



using Capa_Datos;
using Capa_Entidad;


namespace Capa_Logica
{
 public    class CL_Producto
    {

        private CD_Productos  objcd_producto = new CD_Productos();

        // Método para listar productos
        public List<Inventario> ListarProductos()
        {
            return objcd_producto.ListarProductos();
        }

        // Método para insertar un producto
        public void InsertarProducto(Inventario producto)
        {
            // Extraer las propiedades del objeto 'Producto'
            string nombreProducto = producto.producto;
            string descripcion = producto.descripcion_inven;
            DateTime fechaVencimiento = producto.fecha_vencimiento;
            int idCategoria = producto.oCategoria.Id_categoria;

            // Llamar al método de la capa de datos pasando los parámetros
            objcd_producto.InsertarProducto(nombreProducto, descripcion, fechaVencimiento, idCategoria);
        }

        public void EliminarProducto(int Id_producto)
        {
            objcd_producto.EliminarProducto(Id_producto); // Llama al método de la capa de datos
        }


    }
}
