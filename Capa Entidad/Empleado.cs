using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Empleado
    {
        public int Id_empleado { get; set; }
        public string nombre_empleado { get; set; }
        public string apellido_empleado { get; set; }
        public string correo_empleado { get; set; }
        public string  telefono_empleado { get; set; }
        public string cargo_empleado { get; set; }
        public decimal salario_empleado { get; set; }
    }
}
