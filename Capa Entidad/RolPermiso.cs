using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class RolPermiso
    {
        public int Id_rol { get; set; }       // Representa el ID del rol
        public int Id_permiso { get; set; }    // Representa el ID del permiso
        public bool Asignado { get; set; }      // Indica si el permiso está activo o no

        public RolPermiso(int Id_rol, int Id_permiso, bool Asignado)
        {
            this.Id_rol = Id_rol;
            this.Id_permiso = Id_permiso;
            this.Asignado = Asignado;
        }

        public RolPermiso() { }
    }
}