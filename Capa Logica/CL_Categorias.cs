using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Logica
{
    public class CL_Categorias
    {

        private CD_Categoria objcd_Categoria = new CD_Categoria();

        public List<Categoria> ListarCategorias()
        {
            return objcd_Categoria.ListarCategorias();

        }
        public void InsertarCategorias(string nombre_categoria)
        {
            // Puedes agregar validaciones aquí, si es necesario
            if (string.IsNullOrWhiteSpace(nombre_categoria))
                throw new ArgumentException("El nombre de la categoria no puede estar vacío.");

            objcd_Categoria.InsertarCategorias(nombre_categoria);
        }
    }
}
