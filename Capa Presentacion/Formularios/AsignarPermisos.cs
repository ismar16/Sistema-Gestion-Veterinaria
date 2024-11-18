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
    public partial class AsignarPermisos : Form
    {

        private CL_RolPermiso RolPermiso = new CL_RolPermiso();
        private int IdRolSeleccionado;

        public AsignarPermisos()
        {
            InitializeComponent();
            CargarRoles();
        }

        private void CargarRoles()
        {

            // Asume que tienes un método en la capa lógica para obtener los roles
            var roles = new CL_Rol().ListarRoles(); // Devuelve una lista de objetos Rol
            cboROL.DataSource = roles;             // Asignar la lista al ComboBox
            cboROL.DisplayMember = "nombre_rol";   // Propiedad de visualización
            cboROL.ValueMember = "Id_rol";         // Propiedad del valor

        }



        private void CargarPermisosPorRol(int Id_rol)
        {
            var permisos = RolPermiso.ObtenerPermisosPorRol(Id_rol);
            dgvROlPermisos.Rows.Clear();

            foreach (var permiso in permisos)
            {
                dgvROlPermisos.Rows.Add(permiso.Id_permiso, permiso.Asignado);
            }
        }

        private void cboROL_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboROL.SelectedValue != null && cboROL.SelectedValue is int)
            {
                IdRolSeleccionado = (int)cboROL.SelectedValue; // Convertimos correctamente a entero
                CargarPermisosPorRol(IdRolSeleccionado);
            }
            else
            {
                IdRolSeleccionado = 0; // En caso de que no haya un valor seleccionado válido
            }

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Validar que haya un rol seleccionado
            if (IdRolSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un rol antes de guardar los cambios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recorrer las filas de la grilla para verificar los permisos
            foreach (DataGridViewRow row in dgvROlPermisos.Rows)
            {
                if (row.Cells["Id_permiso"].Value != null && row.Cells["Asignado"].Value != null)
                {
                    int Id_permiso = Convert.ToInt32(row.Cells["Id_permiso"].Value);
                    bool asignado = Convert.ToBoolean(row.Cells["Asignado"].Value);

                    if (asignado)
                    {
                        // Si el permiso está asignado, llamar al método AsignarPermiso
                        RolPermiso.AsignarPermiso(IdRolSeleccionado, Id_permiso);
                    }
                    else
                    {
                        // Si no está asignado, llamar al método QuitarPermiso
                        RolPermiso.QuitarPermiso(IdRolSeleccionado, Id_permiso);
                    }
                }
            }

            // Mostrar un mensaje de confirmación
            MessageBox.Show("Los cambios han sido guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Recargar los permisos para el rol seleccionado
            CargarPermisosPorRol(IdRolSeleccionado);

        }

        private void AsignarPermisos_Load(object sender, EventArgs e)
        {
            dgvROlPermisos.Columns.Clear();

            // Columna Id_permiso
            DataGridViewTextBoxColumn colId_permiso = new DataGridViewTextBoxColumn();
            colId_permiso.Name = "Id_permiso";
            colId_permiso.HeaderText = "ID Permiso";
            colId_permiso.Visible = true; // Oculta esta columna
            dgvROlPermisos.Columns.Add(colId_permiso);

            // Columna Asignado (checkbox)
            DataGridViewCheckBoxColumn colAsignado = new DataGridViewCheckBoxColumn();
            colAsignado.Name = "Asignado";
            colAsignado.HeaderText = "Asignado";
            dgvROlPermisos.Columns.Add(colAsignado);

            

        }
    }
}
