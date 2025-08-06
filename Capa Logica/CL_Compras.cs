using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Logica


{
    public class CL_Compras
    {
        private CD_Compras clcompras = new CD_Compras();

        public List<Compras> ListarCompras()
        {
            return clcompras.ListarCompras();
        }

        public string InsertarCompra(DateTime fechaCompra, int Id_producto, int cantidadProducto,
                                      decimal precioCompra, decimal totalCompra, decimal precioVenta,
                                      int Id_categoria, int Id_empleado)
        {
            return clcompras.InsertarCompra(fechaCompra, Id_producto, cantidadProducto,
                                             precioCompra, totalCompra, precioVenta, Id_categoria, Id_empleado);
        }

        public void ActualizarCompra(Compras compra)
        {
            try
            {
                // Lista para almacenar mensajes de error
                List<string> errores = new List<string>();

                // Validaciones unificadas
                if (compra == null)
                    errores.Add("La información de la compra no puede ser nula.");

                if (compra.cantidadProducto <= 0)
                    errores.Add("La cantidad del producto debe ser mayor a 0.");

                if (compra.precioCompra <= 0)
                    errores.Add("El precio de compra debe ser mayor a 0.");

                if (compra.precio_venta <= 0)
                    errores.Add("El precio de venta debe ser mayor a 0.");

                // Verificar si hubo errores
                if (errores.Count > 0)
                {
                    // Lanzar excepción con todos los errores concatenados
                    throw new ArgumentException("Errores de validación:\n" + string.Join("\n", errores));
                }

                // Llamar al método de la Capa Datos
                CD_Compras cdCompras = new CD_Compras();
                 cdCompras.ActualizarCompra(compra); // Este método retorna un booleano indicando éxito o fallo
            }
            catch (Exception ex)
            {
                // Propagar el error a la capa superior
                throw new Exception("Error en la lógica al actualizar la compra: " + ex.Message);
            }
        }


        public void EliminarCompra(int Id_compra)
        {
             clcompras.EliminarCompra(Id_compra);
        }
    }
}
