using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Logica
{
    public class CL_Rol
    {
        private CD_Rol objcd_rol = new CD_Rol();

        public List<Rol> ListarRoles()
        {
            return objcd_rol.ListarRoles();

        }
        public void InsertarRol(string nombre)
        {
            // Puedes agregar validaciones aquí, si es necesario
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del rol no puede estar vacío.");

            objcd_rol.InsertarRol(nombre);
        }
    }

    
}
