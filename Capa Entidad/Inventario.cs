using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class Inventario
    {
        public int Id_producto { get; set; }
        public string producto { get; set; }
        public string descripcion_inven { get; set; }
        public int Stock { get; set; }
        public decimal precio_venta { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public Categoria oCategoria { get; set; }
    }
}
