using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Entidad;


using Capa_Datos;



namespace Capa_Logica
{

    public class CL_RolPermiso
    {
        private CD_RolPermiso dataLayer = new CD_RolPermiso();

        public List<RolPermiso> ObtenerPermisosPorRol(int idRol)
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

