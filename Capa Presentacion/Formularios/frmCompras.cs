using Capa_Entidad;
using Capa_Logica;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

using System.Data;

namespace Capa_Presentacion.Formularios
{

    public partial class frmCompras : Form
    {

        private CL_Compras clcompras = new CL_Compras();
        private CL_Producto clproducto = new CL_Producto();
        private CL_Categorias clcategorias = new CL_Categorias();
        private CL_Empleado clempleado = new CL_Empleado();

        public frmCompras()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCompras_Load(object sender, EventArgs e)
        {

            CargarDatos();
            CargarCombos();

            // Configurar el formato del DateTimePicker para la fecha de compra
            dtpkFechaCompra.Format = DateTimePickerFormat.Custom;  // Usar formato personalizado
            dtpkFechaCompra.CustomFormat = "dd/MM/yyyy";  // Ajusta el formato según tus necesidades (puede ser "MM/dd/yyyy" o el que prefieras)


        }

        private void btnGuardar_Click(object sender, EventArgs e)

        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtPreciocompra.Text) ||
                    string.IsNullOrEmpty(txtprecioVenta.Text) || cboProducto.SelectedIndex == -1 ||
                    cboCategoria.SelectedIndex == -1 || cboEmpleado.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir si algún campo está vacío
                }

                // Crear un objeto Compra con los datos del formulario
                Compras nuevaCompra = new Compras()
                {
                    fecha_compra = dtpkFechaCompra.Value, // DateTimePicker para la fecha de compra
                    cantidadProducto = Convert.ToInt32(txtCantidad.Text), // TextBox para la cantidad
                    precioCompra = Convert.ToDecimal(txtPreciocompra.Text), // TextBox para el precio de compra
                    precio_venta = Convert.ToDecimal(txtprecioVenta.Text), // TextBox para el precio de venta
                };

                // Calcular el subtotal para esta compra
                decimal subtotal = nuevaCompra.cantidadProducto * nuevaCompra.precioCompra;

                // Obtener el totalCompra acumulado de todas las compras previas
                List<Compras> listaCompras = clcompras.ListarCompras(); // Obtener las compras previas
                decimal totalCompra = listaCompras.Sum(c => c.totalCompra); // Sumar el total de todas las compras previas

                // Agregar el subtotal de la nueva compra al total acumulado
                totalCompra += subtotal;

                // Mostrar el total acumulado en lblTotalCompra
                lblTotalCompra.Text = $"Total: {totalCompra:C}"; // Formatear el total como moneda

                // Insertar la compra utilizando solo los ID de los objetos relacionados

                clcompras.InsertarCompra(
                  nuevaCompra.fecha_compra,
                 Convert.ToInt32(cboProducto.SelectedValue), // ID del producto
                   nuevaCompra.cantidadProducto,
                     nuevaCompra.precioCompra,
                   subtotal, // Guardar el subtotal calculado
                   nuevaCompra.precio_venta,
                   Convert.ToInt32(cboCategoria.SelectedValue), // ID de la categoría
                 Convert.ToInt32(cboEmpleado.SelectedValue) // ID del empleado
);





                limpiar();

                // Volver a cargar los datos en el DataGridView, sin incluir el totalCompra
                CargarDatos();

                // Mostrar mensaje de éxito
                MessageBox.Show("Compra insertada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Formato de entrada incorrecto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarDatos()
        {
            try
            {
                // Obtener los datos de compras como una lista de objetos
                List<Compras> listaCompras = clcompras.ListarCompras(); // Este método ya devuelve una lista

                // Crear una lista de objetos anónimos para los datos del DataGridView
                var comprasDetalles = listaCompras.Select(c => new
                {
                    c.Id_compra,
                    c.fecha_compra,
                    Producto = c.oInventario.producto,          // Nombre del producto
                    c.cantidadProducto,
                    c.precioCompra,
                    c.subtotal,
                    c.precio_venta,
                    Categoria = c.oCategoria.nombre_categoria, // Nombre de la categoría
                    Empleado = c.oEmpleado.nombre_empleado     // Nombre del empleado
                }).ToList();

                // Asignar los datos al DataGridView
                dgvCompras.DataSource = comprasDetalles;

                // Configurar las columnas del DataGridView
                dgvCompras.Columns["Id_compra"].HeaderText = "ID Compra";
                dgvCompras.Columns["fecha_compra"].HeaderText = "Fecha de Compra";
                dgvCompras.Columns["Producto"].HeaderText = "Producto";
                dgvCompras.Columns["cantidadProducto"].HeaderText = "Cantidad";
                dgvCompras.Columns["precioCompra"].HeaderText = "Precio Compra";
                dgvCompras.Columns["subtotal"].HeaderText = "Subtotal";
                dgvCompras.Columns["precio_venta"].HeaderText = "Precio Venta";
                dgvCompras.Columns["Categoria"].HeaderText = "Categoría";
                dgvCompras.Columns["Empleado"].HeaderText = "Empleado";

                dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Calcular el totalCompra acumulado
                decimal totalCompra = listaCompras.Sum(c => c.totalCompra);

                // Mostrar el total acumulado en lblTotalCompra
                lblTotalCompra.Text = $"Total: {totalCompra:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void CargarCombos()
        {
            cboProducto.DataSource = clproducto.ListarProductos(); // Usar la instancia existente
            cboProducto.DisplayMember = "producto";
            cboProducto.ValueMember = "Id_producto";

            cboCategoria.DataSource = clcategorias.ListarCategorias();
            cboCategoria.DisplayMember = "nombre_categoria";
            cboCategoria.ValueMember = "Id_categoria";

            cboEmpleado.DataSource = clempleado.ListarEmpleados();
            cboEmpleado.DisplayMember = "nombre_empleado";
            cboEmpleado.ValueMember = "Id_empleado";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCompras.SelectedRows.Count > 0) // Verifica si se ha seleccionado una fila
            {
                int idCompra = Convert.ToInt32(dgvCompras.SelectedRows[0].Cells["Id_compra"].Value); // Obtener el ID de la compra seleccionada

                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta compra?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        clcompras.EliminarCompra(idCompra); // Llamar al método para eliminar la compra
                        CargarDatos(); // Recargar los datos en el DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una compra para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                // Crear un objeto Compra con los datos del formulario
                Compras compra = new Compras
                {
                    fecha_compra = dtpkFechaCompra.Value,

                    // Asignar la instancia completa de Inventario
                    oInventario = new Inventario
                    {
                        Id_producto = Convert.ToInt32(cboProducto.SelectedValue),
                        producto = cboProducto.Text // Suponiendo que el nombre del producto está en el combo
                    },

                    cantidadProducto = Convert.ToInt32(txtCantidad.Text),
                    precioCompra = Convert.ToDecimal(txtPreciocompra.Text),
                    precio_venta = Convert.ToDecimal(txtprecioVenta.Text),

                    // Asignar la instancia completa de Categoria
                    oCategoria = new Categoria
                    {
                        Id_categoria = Convert.ToInt32(cboCategoria.SelectedValue),
                        nombre_categoria = cboCategoria.Text // Suponiendo que el nombre de la categoría está en el combo
                    },

                    // Asignar la instancia completa de Empleado
                    oEmpleado = new Empleado
                    {
                        Id_empleado = Convert.ToInt32(cboEmpleado.SelectedValue),
                        nombre_empleado = cboEmpleado.Text // Suponiendo que el nombre del empleado está en el combo
                    }
                };

                // Llamar al método de la capa lógica
                CL_Compras clCompras = new CL_Compras();
                clCompras.ActualizarCompra(compra);

                MessageBox.Show("Compra actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar los datos en el DataGridView
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void limpiar()
        {
            txtCantidad.Text = " ";
            txtPreciocompra.Text = " ";
            txtprecioVenta.Text = " ";
        }
    }
}