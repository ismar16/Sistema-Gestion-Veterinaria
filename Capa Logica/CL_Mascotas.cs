using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Logica
{
   public class CL_Mascotas
    {
        private CD_Mascotas objcd_mascotas = new CD_Mascotas();

        public List<Mascotas> ListarMascotas()
        {
            return objcd_mascotas.ListarMascotas();

        }

        public void InsertarMascotas(Mascotas mascotas)
        {
            // Extraer las propiedades del objeto 'Usuario'
            string nombre_mascota =mascotas.nombre_mascota ;
            string especie = mascotas.especie ;
            string raza = mascotas.raza;
            DateTime fecha_nacimineto =mascotas.fecha_nacimiento;

            int Id_propietario = mascotas.oPropietario.Id_propietario;



            // Llamar al método de la capa de datos pasando los parámetros extraídos del objeto
            objcd_mascotas.InsertarMascota(nombre_mascota, especie, raza, fecha_nacimineto, Id_propietario );
        }

        public void EliminarMascota(int idMascota)
        {
            try
            {
                // Llamar directamente al método estático de la capa de datos
                CD_Mascotas.EliminarMascota(idMascota);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de eliminar mascota: " + ex.Message);
            }
        }



    }
}
