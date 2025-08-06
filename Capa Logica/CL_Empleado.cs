using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Logica
{ 
  

   public  class CL_Empleado
    { 
          private CD_Empleados objcd_Empleado = new CD_Empleados();
    
        public List<Empleado> ListarEmpleados()
        {
            return objcd_Empleado.ListarEmpleados();

        }

        public void InsertarEmpleado(Empleado empleado)
        {
            // Extraer las propiedades del objeto 'Empleado'
            string nombre = empleado.nombre_empleado;
            string apellido = empleado.apellido_empleado;
            string correo = empleado.correo_empleado;
            string telefono = empleado.telefono_empleado;
            string cargo = empleado.cargo_empleado;
            decimal salario = empleado.salario_empleado;

            // Llamar al método de la capa de datos pasando los parámetros extraídos del objeto
            objcd_Empleado.InsertarEmpleado(nombre, apellido, correo, telefono, cargo, salario);
        }

        public bool EliminarEmpleado(int Id_empleado)
        {
            if (Id_empleado <= 0)
                throw new ArgumentException("El ID del empleado no es válido.");

            CD_Empleados clempleados = new CD_Empleados();
            return clempleados.EliminarEmpleado(Id_empleado);
        }

    }

}

