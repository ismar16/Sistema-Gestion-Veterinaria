using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   

        public class Compras
        {
            public int Id_compra { get; set; }
            public DateTime fecha_compra { get; set; }
            public Inventario oInventario { get; set; } // Relación con Inventario/Producto
            public int cantidadProducto { get; set; }
            public decimal precioCompra { get; set; }
            public decimal subtotal { get; set; } // Nueva propiedad para la columna calculada
            public decimal totalCompra { get; set; }
            public decimal precio_venta { get; set; }
            public Categoria oCategoria { get; set; } // Relación con Categoría
            public Empleado oEmpleado { get; set; } // Relación con Empleado
        }

    

}

