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
    public partial class frmEmpleados : Form
    {
        private CL_Empleado cl_empleado = new CL_Empleado();

        public frmEmpleados()
        {
            InitializeComponent();
        }

       

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un nuevo objeto Empleado con los datos ingresados
                Empleado nuevoEmpleado = new Empleado
                {
                    nombre_empleado = txtnombreEmp.Text,
                    apellido_empleado = txtApellidosEmp.Text,
                    correo_empleado = txtCorreoEmp.Text,
                    telefono_empleado = txtTelefonoEmp.Text,
                    cargo_empleado = txtCargo.Text,
                    salario_empleado = decimal.Parse(txtSalario.Text)
                };

                // Llamar al método de inserción en la capa lógica
                cl_empleado.InsertarEmpleado(nuevoEmpleado);

                MessageBox.Show("Empleado insertado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar la lista de empleados en el DataGridView
                CargarEmpleados();

                LimpiarCajas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarEmpleados()
        {
            try
            {
                // Obtener la lista de empleados desde la capa lógica
                List<Empleado> lista = cl_empleado.ListarEmpleados();

                // Asignar la lista de empleados como fuente de datos del DataGridView
                dgvEmpleados.DataSource = lista;

                // Configurar los encabezados de las columnas del DataGridView
                dgvEmpleados.Columns["Id_empleado"].HeaderText = "ID Empleado";
                dgvEmpleados.Columns["nombre_empleado"].HeaderText = "Nombre";
                dgvEmpleados.Columns["apellido_empleado"].HeaderText = "Apellido";
                dgvEmpleados.Columns["correo_empleado"].HeaderText = "Correo";
                dgvEmpleados.Columns["telefono_empleado"].HeaderText = "Teléfono";
                dgvEmpleados.Columns["cargo_empleado"].HeaderText = "Cargo";
                dgvEmpleados.Columns["salario_empleado"].HeaderText = "Salario";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LimpiarCajas()
        {

            txtnombreEmp.Text = " ";
            txtApellidosEmp.Text = " ";
            txtCorreoEmp.Text = " ";
            txtCargo.Text = " ";
            txtTelefonoEmp.Text = " ";
            txtSalario.Text = " ";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
                try
                {
                    // Verifica si hay una fila seleccionada
                    if (dgvEmpleados.SelectedRows.Count > 0)
                    {
                        // Obtiene el ID de la fila seleccionada (ajusta el índice de columna si es necesario)
                        int Id_empleado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["Id_Empleado"].Value);

                    // Llama al método en la capa de negocios
                    CL_Empleado clempleado = new CL_Empleado();


                    var confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este empleado?",
                                                            "Confirmar eliminación",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);

                        if (confirmacion == DialogResult.Yes)
                        {
                            if (cl_empleado.EliminarEmpleado(Id_empleado))
                            {
                                MessageBox.Show("Empleado eliminado exitosamente.");
                                // Opcional: Actualizar el DataGridView
                                CargarEmpleados();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el empleado. Verifica el ID.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecciona un empleado para eliminar.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            




        }
    }       
}
