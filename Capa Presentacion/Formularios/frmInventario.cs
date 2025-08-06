using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Presentacion.Formularios;

using Capa_Logica;
using Capa_Entidad;

namespace Capa_Presentacion
{
    public partial class frmInventario : Form
    {
        private CL_Producto cl_producto = new CL_Producto();
        private CL_Categorias clcategorias = new CL_Categorias();
        private CL_Compras comprascl = new CL_Compras();

        


        public frmInventario()
        {
            InitializeComponent();
        }



        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de compras
            frmCompras  formCompras = new frmCompras();

            // Mostrar el formulario de compras
            formCompras.ShowDialog();
        }


        private void btnRegistarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Configurar el rango máximo de fecha permitido
                dtpFechaVencimiento.MaxDate = DateTime.Now.AddYears(10);

                // Validar que la fecha no sea anterior a hoy
                if (dtpFechaVencimiento.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha de vencimiento no puede ser anterior a la fecha actual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear un nuevo objeto Producto con los datos ingresados
                Inventario nuevoProducto = new Inventario()
                {
                    producto = txtproducto.Text,
                    descripcion_inven = txtdescripcion.Text,
                    fecha_vencimiento = dtpFechaVencimiento.Value,
                    oCategoria = new Categoria { Id_categoria = (int)cboCategoria.SelectedValue }
                };

                // Llamar al método de inserción en la capa lógica
                cl_producto.InsertarProducto(nuevoProducto);

                MessageBox.Show("Producto registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar la lista de productos en el DataGridView
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void CargarProductos()
        {
            try
            {
                // Obtener la lista de productos
                var productos = cl_producto.ListarProductos();

                if (productos != null && productos.Count > 0)
                {
                    // Proyectar los datos para mostrar solo las propiedades necesarias
                    var datosAMostrar = productos.Select(p => new
                    {
                        Id_producto = p.Id_producto,
                        Producto = p.producto,
                        Descripción = p.descripcion_inven,
                        FechaVencimiento = p.fecha_vencimiento.ToShortDateString(),
                        Stock = p.Stock,
                        PrecioVenta = p.precio_venta,
                        Categoría = p.oCategoria.Id_categoria // Mostrar solo el ID de la categoría
                    }).ToList();

                    // Asignar los datos al DataGridView
                    dgvProductos.DataSource = datosAMostrar;

                    // Configurar encabezados personalizados
                    dgvProductos.Columns["Id_producto"].HeaderText = "Id Producto";
                    dgvProductos.Columns["Producto"].HeaderText = "Producto";
                    dgvProductos.Columns["Descripción"].HeaderText = "Descripción";
                    dgvProductos.Columns["FechaVencimiento"].HeaderText = "Fecha de Vencimiento";
                    dgvProductos.Columns["Stock"].HeaderText = "Stock";
                    dgvProductos.Columns["PrecioVenta"].HeaderText = "Precio de Venta";
                    dgvProductos.Columns["Categoría"].HeaderText = "ID Categoría";
                }
                else
                {
                    MessageBox.Show("No se encontraron productos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombo()
        {
            // Cargar datos para el combo box de roles
            var productos = clcategorias.ListarCategorias(); // Suponiendo que obtienes una lista o DataTable
            cboCategoria.DataSource = productos;
            cboCategoria.DisplayMember = "nombre_categoria";  // Nombre de la columna para mostrar
            cboCategoria.ValueMember = "Id_Categoria";       // Nombre de la columna que sirve como valor

        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarProductos();
        }

      

        
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

            if (dgvProductos.SelectedRows.Count > 0)
            {
                // Obtener el ID del usuario seleccionado en el DataGridView
                int Id_producto = (int)dgvProductos.SelectedRows[0].Cells["Id_producto"].Value;

                // Confirmación antes de eliminar
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto de tu inventario?",
                                                      "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar al método de eliminación en la capa lógica
                        cl_producto.EliminarProducto(Id_producto);

                        // Refrescar el DataGridView
                        CargarProductos();
                        MessageBox.Show("Producto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
