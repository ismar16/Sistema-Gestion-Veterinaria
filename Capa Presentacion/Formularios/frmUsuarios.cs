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
        private CL_Rol clrol = new CL_Rol();
        private CL_Empleado clempleado = new CL_Empleado();

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
                // Obtener la lista de usuarios
                var usuarios = cl_usuario.Listar();

                if (usuarios != null && usuarios.Count > 0)
                {
                    // Proyectar los datos para mostrar solo las propiedades necesarias
                    var datosAMostrar = usuarios.Select(u => new
                    {
                        Id_usuario = u.Id_usuario,
                        Carnet = u.carnet,
                        Nombres = u.nombres,
                        Apellidos = u.apellidos,
                        Correo = u.correo,
                        Clave = u.clave,
                        Rol = u.oRol.Id_rol,        // Mostrar solo el ID del Rol
                        Empleado = u.oEmpleado.Id_empleado // Mostrar solo el ID del Empleado
                    }).ToList();

                    // Asignar los datos al DataGridView
                    dgvUsuario.DataSource = datosAMostrar;

                    // Configurar encabezados personalizados
                    dgvUsuario.Columns["Id_usuario"].HeaderText = "ID Usuario";
                    dgvUsuario.Columns["Carnet"].HeaderText = "Carnet";
                    dgvUsuario.Columns["Nombres"].HeaderText = "Nombres";
                    dgvUsuario.Columns["Apellidos"].HeaderText = "Apellidos";
                    dgvUsuario.Columns["Correo"].HeaderText = "Correo";
                    dgvUsuario.Columns["Clave"].HeaderText = "Clave";
                    dgvUsuario.Columns["Rol"].HeaderText = "ID Rol"; // Cambiar encabezado para reflejar el ID
                    dgvUsuario.Columns["Empleado"].HeaderText = "ID Empleado"; // Cambiar encabezado para reflejar el ID
                }
                else
                {
                    MessageBox.Show("No se encontraron usuarios para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarDatos();
          
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
                        Id_usuario = int.Parse(txtid.Text),
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

                    LimpiarCampos();
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

        private void cboEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            var empleadoSeleccionado = (Empleado)cboEmpleado.SelectedItem;
            if (empleadoSeleccionado != null)
            {
                int idEmpleadoSeleccionado = empleadoSeleccionado.Id_empleado;
                CargarDatosEmpleado(idEmpleadoSeleccionado);
            }
        }


        private void CargarDatos()
        {
            // Cargar datos para el combo box de roles
            var roles = clrol.ListarRoles(); // Suponiendo que obtienes una lista o DataTable
            cboRol.DataSource = roles;
            cboRol.DisplayMember = "nombre_rol";  // Nombre de la columna para mostrar
            cboRol.ValueMember = "Id_rol";       // Nombre de la columna que sirve como valor



            var empleados = clempleado.ListarEmpleados(); // Suponiendo que obtienes una lista o DataTable
            cboEmpleado.DataSource = empleados;
            cboEmpleado.DisplayMember = "nombre_empleado";  // Nombre de la columna para mostrar
            cboEmpleado.ValueMember = "Id_empleado";       // Nombre de la columna que sirve como valor


        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarDatosEmpleado(int idEmpleado)
        {
            var empleados = clempleado.ListarEmpleados(); // Obtener la lista de empleados
            var empleado = empleados.FirstOrDefault(e => e.Id_empleado == idEmpleado);
            if (empleado != null)
              
            {
                txtnombre.Text = empleado.nombre_empleado;
                txtApellido.Text = empleado.apellido_empleado;
                txtCorreo.Text = empleado.correo_empleado;
            }
            else
            {
                MessageBox.Show("No se encontró el empleado.");
                txtnombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
            }
        }

        private void LimpiarCampos()
        {
            // Limpiar los TextBox
            txtCarnet.Text = "  ";
            txtnombre.Text = " ";
            txtApellido.Text = " ";
            txtCorreo.Text = " ";
            txtClave.Text = " ";

            // Restablecer los ComboBox al valor por defecto
            if (cboRol.Items.Count > 0)
                cboRol.SelectedIndex = 0; // Selecciona el primer elemento (si lo hay)

            if (cboEmpleado.Items.Count > 0)
                cboEmpleado.SelectedIndex = 0; // Selecciona el primer elemento (si lo hay)
        }


    }



}
