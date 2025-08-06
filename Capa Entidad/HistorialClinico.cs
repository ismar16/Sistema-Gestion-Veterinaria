using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
  public   class Historialclinico
    {
        public int Id_historial { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion  { get; set; }
        public Mascotas oMascotas { get; set; }
        public Empleado oEmpleado { get; set; }
        public string diagnostico { get; set; }
        public string tratamiento { get; set; }
        public string  medicamento { get; set; }

    }
}
