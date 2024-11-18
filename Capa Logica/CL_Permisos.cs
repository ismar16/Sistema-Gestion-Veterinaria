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
        public void InsertarPermiso(string nombre)
        {
            // Puedes agregar validaciones aquí, si es necesario
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del permiso no puede estar vacío.");

            objcd_permiso.InsertarPermisos(nombre);

            // Validar si el nombre del menú es válido
            if (!EsMenuValido(nombre))
                throw new ArgumentException("El nombre del menú no es válido.");

        }

        // Método privado para validar si el nombre del menú es válido
        private bool EsMenuValido(string nombre_menu)
        {
            // Lista de menús predefinidos. Esta lista puede ser más dinámica, dependiendo de tu aplicación.
            var menusValidos = new List<string> { "Acceso y Personal", "Usuarios", "Empleados", "Compras", "Registrar compra", "Venta", "Registrar Venta", "Productos", "Inventario", "Categoria de productos", "Citas", "Historial Clinico","Mascotas",
                "Propietarios","Pagor por servicios","Configuración","Roles","Permisos","Asignar Permisos", "Reportes","Acerca de" };

            // Verificar si el nombre del menú está en la lista de menús válidos
            return menusValidos.Contains(nombre_menu);
        }

        public bool EliminarPermiso(int Id_permiso)
        {

            {

                // Llamar al método de la capa de datos para eliminar el permiso


                return objcd_permiso.EliminarPermiso(Id_permiso);
            }
        }

 

    }

}
