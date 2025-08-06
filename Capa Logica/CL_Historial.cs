using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadHistorialClinico = Capa_Entidad.Historialclinico;



using Capa_Datos;
using Capa_Entidad;

namespace Capa_Logica
{

   public class CL_Historial
    {
        private CD_Historial objcd_historial = new CD_Historial();


      public List<Historialclinico> ListarHistorial()
        {

            return objcd_historial.ListarHistorial();

        }

        public void InsertarHistorial(Historialclinico historial)
        {
            // Extraer las propiedades del objeto 'HistorialClinico'
            DateTime fechaHistorial = historial.fecha;
            string descripcion = historial.descripcion;
            string diagnostico = historial.diagnostico;
            string tratamiento = historial.tratamiento;
            string medicamento = historial.medicamento;

            // Acceder a las propiedades de los objetos relacionados 'Mascota' y 'Veterinario'
            int Id_mascota = historial.oMascotas.Id_mascota;
            int Id_empleado = historial.oEmpleado.Id_empleado;

            // Llamar al método de la capa de datos pasando los parámetros extraídos del objeto
            objcd_historial.InsertarHistorial(historial);
        }

        public List<Empleado> ObtenerVeterinarios()
        {
            return objcd_historial.ObtenerVeterinarios();
        }

    }
}
