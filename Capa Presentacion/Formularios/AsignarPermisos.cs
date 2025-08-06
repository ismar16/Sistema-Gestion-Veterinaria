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
        private List<Permisos> todosLosPermisos;
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
                IdRolSeleccionado = (int)cboROL.SelectedValue;
                ActualizarPermisosDeRol(IdRolSeleccionado);
            }
            else
            {
                IdRolSeleccionado = 0;
                dgvROlPermisos.Rows.Clear();
                // Llama a CargarTodosLosPermisos() para restablecer la grilla.
                CargarTodosLosPermisos();
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
            // Carga todos los roles en el ComboBox
            CargarRoles();
            // Carga todos los permisos en la variable global
            CargarTodosLosPermisos();
        }

        private void CargarTodosLosPermisos()
        {
            // Obtener todos los permisos de la base de datos.
            todosLosPermisos = new CL_Permisos().ListarPermisos();

            // Limpiar las filas y columnas existentes del DataGridView
            dgvROlPermisos.Columns.Clear();
            dgvROlPermisos.Rows.Clear();

            // Configurar las columnas
            dgvROlPermisos.Columns.Add("Id_permiso", "ID Permiso");
            dgvROlPermisos.Columns.Add("Nombre_Menu", "Nombre del Permiso");

            // Agregar la columna de checkbox
            DataGridViewCheckBoxColumn colAsignado = new DataGridViewCheckBoxColumn();
            colAsignado.Name = "Asignado";
            colAsignado.HeaderText = "Asignado";
            dgvROlPermisos.Columns.Add(colAsignado);

            // Oculta la columna del ID si no quieres que sea visible
            dgvROlPermisos.Columns["Id_permiso"].Visible = false;

            // Llenar la grilla con todos los permisos
            foreach (var permiso in todosLosPermisos)
            {
                dgvROlPermisos.Rows.Add(permiso.Id_permiso, permiso.nombre_menu, false); // El tercer parámetro es el estado inicial del checkbox
            }
        }
        private void ActualizarPermisosDeRol(int idRol)
        {
            // Obtener los permisos asignados a este rol específico
            List<PermisoConRol> permisosAsignados = RolPermiso.ObtenerPermisosPorRol(idRol);

            // Recorrer todas las filas de la grilla
            foreach (DataGridViewRow row in dgvROlPermisos.Rows)
            {
                if (row.Cells["Id_permiso"].Value != null)
                {
                    int idPermisoEnGrilla = Convert.ToInt32(row.Cells["Id_permiso"].Value);

                    // Buscar si este permiso está en la lista de permisos asignados
                    bool estaAsignado = permisosAsignados.Any(p => p.Id_permiso == idPermisoEnGrilla);

                    // Actualizar el estado del checkbox
                    row.Cells["Asignado"].Value = estaAsignado;
                }
            }
        }
    }
}
