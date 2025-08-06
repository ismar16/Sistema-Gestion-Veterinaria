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
    public partial class Clientes : Form
    {
        private CL_Popietario cl_propietarios = new CL_Popietario();

        public Clientes()
        {
            InitializeComponent();
        }


        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarPropietarios();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un nuevo objeto Empleado con los datos ingresados
                Propietario nuevoCliente = new Propietario
                {
                    nombres_propietario = txtNombres.Text,
                    apellidos_propietario = txtApellidos .Text,
                    correo_propietario = txtCorreo.Text,
                    telefono_propietario = txtTelefono.Text,
                    Direccion_propietario = txtDireccion.Text
                };

                // Llamar al método de inserción en la capa lógica
                cl_propietarios.RegistrarPropietario(nuevoCliente);

                MessageBox.Show("Propietario insertado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar la lista de empleados en el DataGridView
                CargarPropietarios();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void CargarPropietarios()
        {
            try
            {
                // Obtener la lista de empleados desde la capa lógica
                List<Propietario> lista = cl_propietarios.ListarPropietario();

                // Asignar la lista de empleados como fuente de datos del DataGridView
                dgvPropietarios.DataSource = lista;


                dgvPropietarios.Columns["Id_propietario"].HeaderText = "ID Propietario";
                dgvPropietarios.Columns["nombres_propietario"].HeaderText = "Nombres";
                dgvPropietarios.Columns["apellidos_propietario"].HeaderText = "Apellido";
                dgvPropietarios.Columns["correo_propietario"].HeaderText = "Correo";
                dgvPropietarios.Columns["telefono_propietario"].HeaderText = "Teléfono";
                dgvPropietarios.Columns["Direccion_propietario"].HeaderText = "Direccion";
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombres.Text = " ";
            txtApellidos.Text = " ";
            txtCorreo.Text = " ";
            txtTelefono.Text = " ";
            txtDireccion.Text = " "; 

        }
      

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvPropietarios.SelectedRows.Count > 0)
            {
                try
                {
                    int Id_propietario = Convert.ToInt32(dgvPropietarios.SelectedRows[0].Cells["Id_propietario"].Value);

                    CL_Popietario negocio = new CL_Popietario();
                    bool resultado = negocio.EliminarPropietario(Id_propietario);

                    if (resultado)
                    {
                        MessageBox.Show("Propietario eliminado correctamente.");
                        CargarPropietarios();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el propietario.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un propietario para eliminar.");
            }
        }
    }
}
