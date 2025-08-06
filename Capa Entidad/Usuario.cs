using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Usuario
    {
        public int Id_usuario { get; set; }
        public int carnet { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string  correo { get; set; }
        public string clave { get; set; }
        public Rol oRol { get; set; }
        public Empleado oEmpleado { get; set; }

      
    }

}

