using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Mascotas
    {
        public int Id_mascota { get; set; }
        public string nombre_mascota { get; set; }
        public string especie { get; set; }
        public string raza { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public Propietario oPropietario { get; set; }


    }
    }
