using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidad;

using Capa_Logica;

namespace Capa_Presentacion.Formularios
{
    public partial class CategoriaProductos : Form
    {
        private CL_Categorias cl_categoria = new CL_Categorias();

        public CategoriaProductos()
        {
            InitializeComponent();
        }





        private void CategoriaProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre_categoria = txtCategoria.Text;

            try
            {
                // Llama al método InsertarRol de la instancia cl_rol creada al inicio
                cl_categoria.InsertarCategorias(nombre_categoria);

                MessageBox.Show("Guardado exitosamente.");

                // Limpia el campo de texto después de guardar
                txtCategoria.Clear();

                CargarCategorias();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la Categoria " + ex.Message);
            }
        }
        private void CargarCategorias()
        {

            try
            {
                // Obtener la lista de Rol desde la capa lógica
                List<Categoria> lista = cl_categoria.ListarCategorias();

                // Asignar la lista de Rol como fuente de datos del DataGridView
                dgvCategorias.DataSource = lista;

                // Asegúrate de que el nombre de la columna coincide con el nombre en tu DataGridView.


                dgvCategorias.Columns["Id_categoria"].ReadOnly = true;
                dgvCategorias.Columns["Id_categoria"].HeaderText = "ID ";
                dgvCategorias.Columns["nombre_categoria"].ReadOnly = true;
                dgvCategorias.Columns["nombre_categoria"].HeaderText = "Categoria";
                dgvCategorias.Columns["fecha_registro"].Visible = false;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar las categorias: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

       
    }
}
