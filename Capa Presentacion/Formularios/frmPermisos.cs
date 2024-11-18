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

            try
            {
                
                cl_permiso.InsertarPermiso(nombre_menu);

                MessageBox.Show("Permiso guardado exitosamente.");

                // Limpia el campo de texto después de guardar
                txtNombreM.Clear();

                CargarPermiso();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el Permiso: " + ex.Message);
            }
        }
        private void CargarPermiso()
        {

            try
            {
                // Obtener la lista de Rol desde la capa lógica
                List<Permisos> lista = cl_permiso.ListarPermisos();

                // Asignar la lista de Rol como fuente de datos del DataGridView
                dgvPermisos.DataSource = lista;
           

                dgvPermisos.Columns["Id_permiso"].ReadOnly = true ;
                dgvPermisos.Columns["nombre_menu"].ReadOnly= true;
                dgvPermisos.Columns["fecha_registro"].Visible = false;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar los Permisos: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

      

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            CargarPermiso();
        }





        private void dgvPermisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verifica que se haga clic en la columna correcta (por ejemplo, columna de "Eliminar")
                if (e.ColumnIndex == 1 && e.RowIndex >= 0) // Asegúrate de que ColumnIndex sea la columna de tu botón
                {
                    // Obtener el Id_permiso desde la fila seleccionada
                    int Id_permiso = Convert.ToInt32(dgvPermisos.Rows[e.RowIndex].Cells["Id_permiso"].Value);

                    // Confirmar la eliminación con el usuario
                    DialogResult result = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este permiso?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Llamar a la capa lógica para eliminar el permiso
                        CL_Permisos permisosLogic = new CL_Permisos();
                        bool eliminado = permisosLogic.EliminarPermiso(Id_permiso);

                        if (eliminado)
                        {
                            // Mostrar mensaje de éxito
                            MessageBox.Show(
                                "Permiso eliminado correctamente.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            // Recargar el DataGridView para mostrar los cambios
                            CargarPermiso();
                        }
                        else
                        {
                            MessageBox.Show(
                                "No se pudo eliminar el permiso. Verifica los datos.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show(
                    "Ocurrió un error al intentar eliminar el permiso: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnEliminarP_Click(object sender, EventArgs e)
        {

           try
    {
        // Validar si hay una fila seleccionada
        if (dgvPermisos.SelectedRows.Count > 0)
        {
            // Obtener el ID del permiso seleccionado desde la columna correspondiente
            int Id_permiso = Convert.ToInt32(dgvPermisos.SelectedRows[0].Cells["Id_permiso"].Value);

            // Confirmar la eliminación con el usuario
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este permiso?", 
                                                  "Confirmar eliminación", 
                                                  MessageBoxButtons.YesNo, 
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Llamar a la capa lógica para eliminar el permiso
                CL_Permisos permisosLogic = new CL_Permisos();
                bool eliminado = permisosLogic.EliminarPermiso(Id_permiso);

                if (eliminado)
                {
                    // Mostrar mensaje de éxito
                    MessageBox.Show("Permiso eliminado y IDs reiniciados correctamente.", "Éxito", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar los permisos en el DataGridView
                    CargarPermiso();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el permiso.", "Error", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Selecciona un permiso para eliminar.", "Advertencia", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Ocurrió un error al intentar eliminar el permiso: " + ex.Message, 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

        }

 

        
    }
}
