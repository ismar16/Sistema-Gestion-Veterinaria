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

namespace Capa_Presentacion
{
    public partial class frmUsuarios : Form
    {
        private CL_Usuario cl_usuario = new CL_Usuario();

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un nuevo objeto Usuario con los datos ingresados
                Usuario nuevoUsuario = new Usuario
                {
                    carnet = int.Parse(txtCarnet.Text),
                    nombres = txtnombre.Text,
                    apellidos = txtApellido.Text,
                    correo = txtCorreo.Text,
                    clave = txtClave.Text,
                    oRol = new Rol { Id_rol = (int)cboRol.SelectedValue },
                    oEmpleado = new Empleado { Id_empleado = (int)cboEmpleado.SelectedValue }
                };

                // Llamar al método de inserción en la capa lógica
                cl_usuario.InsertarUsuario(nuevoUsuario);

                MessageBox.Show("Usuario insertado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar la lista de usuarios en el DataGridView
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

private void CargarUsuarios()
        {
            try
            {
                // Obtener la lista de usuarios desde la capa lógica
                List<Usuario> lista = cl_usuario.Listar();

                // Asignar la lista de usuarios como fuente de datos del DataGridView
                dgvUsuario.DataSource = lista;


                dgvUsuario.Columns["Id_usuario"].HeaderText = "ID Usuario";
                dgvUsuario.Columns["carnet"].HeaderText = "Carnet";
                dgvUsuario.Columns["nombres"].HeaderText = "Nombres";
                dgvUsuario.Columns["apellidos"].HeaderText = "Apellidos";
                dgvUsuario.Columns["correo"].HeaderText = "Correo";
                dgvUsuario.Columns["clave"].HeaderText = "Clave";
                dgvUsuario.Columns["oRol"].HeaderText = "Rol";
                dgvUsuario.Columns["oEmpleado"].HeaderText = "Empleado";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();

          
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuario.CurrentRow != null)
                {
                    // Crear un nuevo objeto Usuario con los datos editados
                    Usuario usuarioActualizado = new Usuario
                    {
                        Id_usuario = Convert.ToInt32(dgvUsuario.CurrentRow.Cells["Id_usuario"].Value),
                        carnet = int.Parse(txtCarnet.Text),
                        nombres = txtnombre.Text,
                        apellidos = txtApellido.Text,
                        correo = txtCorreo.Text,
                        clave = txtClave.Text,
                        oRol = new Rol { Id_rol = (int)cboRol.SelectedValue },
                        oEmpleado = new Empleado { Id_empleado = (int)cboEmpleado.SelectedValue }
                    };

                    // Llamar al método de actualización en la capa lógica
                    cl_usuario.ActualizarUsuario(usuarioActualizado);

                    MessageBox.Show("Usuario actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refrescar la lista de usuarios en el DataGridView
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para actualizar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
           
            
                if (dgvUsuario.SelectedRows.Count > 0)
                {
                    // Obtener el ID del usuario seleccionado en el DataGridView
                    int Id_usuario = (int)dgvUsuario.SelectedRows[0].Cells["Id_usuario"].Value;

                    // Confirmación antes de eliminar
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?",
                                                          "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Llamar al método de eliminación en la capa lógica
                            cl_usuario.EliminarUsuario(Id_usuario);

                            // Refrescar el DataGridView
                            CargarUsuarios();
                            MessageBox.Show("Usuario eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un usuario para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            

        }
    }


   
}
