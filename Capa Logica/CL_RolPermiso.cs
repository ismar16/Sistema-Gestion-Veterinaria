using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Entidad;
using Capa_Datos;
using static Capa_Entidad.RolPermiso;

namespace Capa_Logica
{
    public class CL_RolPermiso
    {
        private CD_RolPermiso dataLayer = new CD_RolPermiso();

        // AQUÍ ESTÁ EL CAMBIO. El tipo de retorno debe ser List<PermisoConRol>
        // Reemplaza el método existente con este:
        public List<PermisoConRol> ObtenerPermisosPorRol(int idRol)
        {
            return dataLayer.ObtenerPermisosPorRol(idRol);
        }

        public void AsignarPermiso(int idRol, int idPermiso)
        {
            dataLayer.AsignarPermiso(idRol, idPermiso);
        }

        public void QuitarPermiso(int idRol, int idPermiso)
        {
            dataLayer.QuitarPermiso(idRol, idPermiso);
        }
    }
}