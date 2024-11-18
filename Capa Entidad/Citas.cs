using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Citas
    {
        public int Id_citas { get; set; }
        public DateTime fecha_cita { get; set; }
        public DateTime Hora_cita { get; set; }
        public string Motico_consulta { get; set; }
        public Mascotas oMascotas { get; set; }
        public Empleado oEmpleado    { get; set; }



    }
}
