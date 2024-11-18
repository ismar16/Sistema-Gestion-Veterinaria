using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public  class PagoServicos
    {
        public int Id_pago { get; set; }
        public DateTime fecha_pago { get; set; }
        public string Descripcion { get; set; }
        public Citas oCitas { get; set; }
        public decimal precioservico { get; set; }

    }
}
