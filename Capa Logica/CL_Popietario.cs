using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;


namespace Capa_Logica
{
  public  class CL_Popietario
    {
       private CD_Propietarios objcd_propietarios = new CD_Propietarios();

        public List<Propietario> ListarPropietario()
        {
            return objcd_propietarios.ListarPropietarios();

        }
       	public string RegistrarPropietario(Propietario propietario)
	{
	    // Validaciones
	    if (string.IsNullOrWhiteSpace(propietario.nombres_propietario) || string.IsNullOrWhiteSpace(propietario.apellidos_propietario))
	        return "El nombre y apellido son obligatorios.";
	
	    if (string.IsNullOrWhiteSpace(propietario.correo_propietario) || !propietario.correo_propietario.Contains("@gmail.com"))
	        return "Correo no válido.";
	
	    if (string.IsNullOrWhiteSpace(propietario.telefono_propietario) || string.IsNullOrWhiteSpace(propietario.Direccion_propietario))
	        return "El teléfono y la dirección son obligatorios.";
	
	    // Llamar a la capa de datos con el objeto propietario completo
	    return objcd_propietarios.RegistrarPropietario(propietario);
	}

		public bool EliminarPropietario(int Id_propietario)
		{
			if (Id_propietario <= 0)
			{
				throw new ArgumentException("El ID del propietario no es válido.");
			}

			CD_Propietarios datos = new CD_Propietarios();
			return datos.EliminarPropietario(Id_propietario);
		}

	}
}
