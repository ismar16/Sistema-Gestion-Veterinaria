using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Logica
{
    public class CL_Permisos
    {
        private CD_Permisos objcd_permiso = new CD_Permisos();

        public List<Permisos> ListarPermisos()
        {
            return objcd_permiso.ListarPermisos();

        }
        public void InsertarPermiso(string nombre_menu, int? Parent_id)
        {
            // Puedes agregar validaciones aquí, si es necesario
            if (string.IsNullOrWhiteSpace(nombre_menu))
                throw new ArgumentException("El nombre del permiso no puede estar vacío.");

            objcd_permiso.InsertarPermisos(nombre_menu, Parent_id);

          
        }



        public void EliminarPermiso(int Id_permiso)
        {
            if (Id_permiso <= 0)
            {
                throw new ArgumentException("El ID del permiso debe ser mayor que cero.");
            }

            objcd_permiso.EliminarPermiso(Id_permiso);
        }



    }

}
