using Capa_Entidad;
using System.Collections.Generic;
using Capa_Datos;


namespace Capa_Logica
{
    public class CL_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();

        }

        public void InsertarUsuario(Usuario usuario)
        {
            // Extraer las propiedades del objeto 'Usuario'
            int carnet = usuario.carnet;
            string nombres = usuario.nombres;
            string apellidos = usuario.apellidos;
            string correo = usuario.correo;
            string clave = usuario.clave;

            // Acceder a las propiedades de los objetos 'oRol' y 'oEmpleado'
            int Id_rol = usuario.oRol.Id_rol;
            int Id_empleado = usuario.oEmpleado.Id_empleado;

            // Llamar al método de la capa de datos pasando los parámetros extraídos del objeto
            objcd_usuario.InsertarUsuario(carnet, nombres, apellidos, correo, clave, Id_rol, Id_empleado);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            // Extraer las propiedades del objeto 'Usuario'
            int Id_usuario = usuario.Id_usuario;          
            int carnet = usuario.carnet;                  
            string nombres = usuario.nombres;             
            string apellidos = usuario.apellidos;        
            string correo = usuario.correo;               
            string clave = usuario.clave;                 

            // Acceder a las propiedades de los objetos 'oRol' y 'oEmpleado'
            int Id_rol = usuario.oRol.Id_rol;              // Propiedad Id_rol de Rol
            int Id_empleado = usuario.oEmpleado.Id_empleado; // Propiedad Id_empleado de Empleado

            // Llamar al método de la capa de datos pasando los parámetros extraídos del objeto
            objcd_usuario.ActualizarUsuario(Id_usuario, carnet, nombres, apellidos, correo, clave, Id_rol, Id_empleado);
       }


        public void EliminarUsuario(int Id_usuario)
        {
            objcd_usuario.EliminarUsuario(Id_usuario); // Llama al método de la capa de datos
        }

    }
}
