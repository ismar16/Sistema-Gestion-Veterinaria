using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Logica;
using Capa_Entidad;

namespace Capa_Presentacion.Formularios
{
    public partial class frmPermisos : Form
    {
        private CL_Permisos cl_permiso = new CL_Permisos();

        public frmPermisos()
        {
            InitializeComponent();
        }



        private void btnGuardarP_Click(object sender, EventArgs e)
        {
            string nombre_menu = txtNombreM.Text;
            int? parent_id = null;

            // Si seleccionaste un menú principal como padre
            if (cboParentMenu.SelectedItem != null)
            {
                var selectedPermiso = (Permisos)cboParentMenu.SelectedItem; // Asegúrate de que combobox tenga objetos Permisos
                parent_id = selectedPermiso.Id_permiso;
            }

            try
            {
                cl_permiso.InsertarPermiso(nombre_menu, parent_id);
                MessageBox.Show("Permiso guardado exitosamente.");

                // Recargar el DataGridView después de guardar
                CargarPermiso();
                txtNombreM.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el Permiso: " + ex.Message);
            }
        }


        private void CargarPermiso()
        {
            // Configurar las columnas del DataGridView si no existen
            if (dgvPermisos.Columns.Count == 0)
            {
                dgvPermisos.Columns.Add("Id_permiso", "ID");
                dgvPermisos.Columns.Add("nombre_menu", "Nombre del Menú");
                dgvPermisos.Columns.Add("Parent_id", "ID del Padre");
            }

            dgvPermisos.Rows.Clear(); // Limpiar el contenido anterior del DataGridView

            // Obtener permisos de la base de datos
            List<Permisos> permisos = cl_permiso.ListarPermisos();

            // Cargar menús principales
            foreach (var permiso in permisos.Where(p => p.Parent_id == null)) // Menús principales
            {
                dgvPermisos.Rows.Add(permiso.Id_permiso, permiso.nombre_menu, permiso.Parent_id);

                // Submenús relacionados
                foreach (var subPermiso in permisos.Where(p => p.Parent_id == permiso.Id_permiso))
                {
                    int rowIndex = dgvPermisos.Rows.Add(subPermiso.Id_permiso, "   " + subPermiso.nombre_menu, subPermiso.Parent_id);
                    dgvPermisos.Rows[rowIndex].DefaultCellStyle.Padding = new Padding(20, 0, 0, 0); // Sangría para submenús
                }
            }

        }




        private void frmPermisos_Load(object sender, EventArgs e)
        {
            CargarPermiso();
            CargarMenusPrincipales();


        }





        private void dgvPermisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            if (dgvPermisos.SelectedRows.Count > 0)
            {
                int Id_permiso = Convert.ToInt32(dgvPermisos.SelectedRows[0].Cells["Id_permiso"].Value);

                try
                {
                    cl_permiso.EliminarPermiso(Id_permiso);
                    MessageBox.Show("Permiso eliminado exitosamente.");
                    CargarPermiso(); // Recargar los permisos
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el Permiso: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un permiso para eliminar.");
            }
        }


        // Método para cargar los menús principales
        private void CargarMenusPrincipales()
        {
            CL_Permisos cdPermisos = new CL_Permisos();

            // Obtener los menús principales (Parent_id == null)
            var menusPrincipales = cdPermisos.ListarPermisos()
                                              .Where(p => p.Parent_id == null)
                                              .ToList();

            // Agregar una opción inicial para "Menú principal"
            menusPrincipales.Insert(0, new Permisos { Id_permiso = 0, nombre_menu = "Menú principal" });

            // Configurar la fuente de datos del ComboBox
            cboParentMenu.DataSource = menusPrincipales;
            cboParentMenu.DisplayMember = "nombre_menu";
            cboParentMenu.ValueMember = "Id_permiso";
        }


        // Manejo del evento SelectedIndexChanged
        private void cboParentMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí puedes manejar la selección del usuario sin recargar los datos
            if (cboParentMenu.SelectedValue != null && int.TryParse(cboParentMenu.SelectedValue.ToString(), out int idPermisoSeleccionado))
            {
                MessageBox.Show($"ID del permiso seleccionado: {idPermisoSeleccionado}");
            }
            else
            {
                MessageBox.Show("El valor seleccionado no es válido o no puede convertirse a un entero.");
            }

        }



    }

}

