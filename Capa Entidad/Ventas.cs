using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Capa_Entidad
{
  public class Ventas
    {
        public int Id_venta { get; set; }
        public DateTime fecha_venta { get; set; }
        public Inventario oInventario { get; set; }
        public Empleado oEmpleado { get; set; }
        public int cantidad { get; set; }
        public decimal precio_venta { get; set; }
        public decimal sub_total { get; set; }
        public decimal total { get; set; }
    }
}
