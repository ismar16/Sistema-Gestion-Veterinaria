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
    public partial class HistorialClinico : Form
    {

        CL_Historial cL_Historial = new CL_Historial();
        CL_Empleado cl_empleado = new CL_Empleado();
        CL_Mascotas clmascotas = new CL_Mascotas();
        
        public HistorialClinico()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void HistorialClinico_Load(object sender, EventArgs e)
        {
            CargarVeterinarios();
            CargarDatos();
            CargarCombos();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
                {
                    // Crear un objeto HistorialClinico
                    Historialclinico historial = new Historialclinico
                    {
                        fecha = dtpFechaHistorial.Value,
                        descripcion = txtdescripcion.Text,
                        diagnostico = txtdiagnostico.Text,
                        tratamiento = txtTratamiento.Text,
                        medicamento = txtMedicamento.Text,

                        // Relación con Mascota
                        oMascotas = new Mascotas
                        {
                            Id_mascota = Convert.ToInt32(cbomascota.SelectedValue)
                        },

                        // Relación con Veterinario (Empleado)
                        oEmpleado = new Empleado
                        {
                            Id_empleado = Convert.ToInt32(cboVeterinario.SelectedValue)
                        }
                    };

                CargarDatos();
                CargarVeterinarios();
                CargarCombos();
                    // Llamar al método de la capa lógica
                    CL_Historial cl_historial = new CL_Historial();
                    cl_historial.InsertarHistorial(historial);

                    MessageBox.Show("Historial clínico registrado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            

        }


        private void CargarDatos()
        {
            try
            {
                // Instancia de la capa de datos
               CL_Historial cL_Historial = new CL_Historial();

                // Obtener la lista de historiales
                List<Historialclinico> listaHistorial = cL_Historial.ListarHistorial();

                // Verificar si hay datos
                if (listaHistorial != null && listaHistorial.Count > 0)
                {
                    
                    var datosMostrar = listaHistorial.Select(h => new
                    {
                        Id_historial = h.Id_historial,
                        Fecha = h.fecha,
                        Descripción = h.descripcion,
                        Mascota = h.oMascotas.nombre_mascota,
                        Veterinario = h.oEmpleado.nombre_empleado,
                        Diagnóstico = h.diagnostico,
                        Tratamiento = h.tratamiento,
                        Medicamento = h.medicamento,
                       
                    }).ToList();

                    dgvHistorial.DataSource = datosMostrar;

                    // Llenar el DataGridView con los datos
                    dgvHistorial.DataSource = listaHistorial;

                    // Opcional: ajustar las columnas del DataGridView
                    dgvHistorial.Columns["Id_historial"].HeaderText = "ID Historial";
                    dgvHistorial.Columns["fecha_historial"].HeaderText = "Fecha";
                    dgvHistorial.Columns["descripcion"].HeaderText = "Descripción";
                    dgvHistorial.Columns["oMascota"].HeaderText = "Mascota";
                    dgvHistorial.Columns["oMascota"].Visible = true;
                    dgvHistorial.Columns["oEmpleado"].HeaderText = "Veterinario";
                    dgvHistorial.Columns["oEmpleado"].Visible = true;
                    dgvHistorial.Columns["diagnostico"].HeaderText = "Diagnóstico";
                    dgvHistorial.Columns["tratamiento"].HeaderText = "Tratamiento";
                    dgvHistorial.Columns["medicamento"].HeaderText = "Medicamento";

                    // Mostrar ls de las relaciones
                    CargarVeterinarios();
                    CargarCombos();
                }
                else
                {
                    MessageBox.Show("No hay datos disponibles en el historial clínico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {

        }
        private void CargarVeterinarios()
        {
          
            List<Empleado> listaVeterinarios = cL_Historial.ObtenerVeterinarios();

            // Limpia el ComboBox antes de llenarlo
            cboVeterinario.DataSource = null;

            cboVeterinario.DataSource = listaVeterinarios;
            cboVeterinario.DisplayMember = "nombre_empleado";
            cboVeterinario.ValueMember = "Id_empleado";
        }
        
        private void CargarCombos()
        {
            
             
            cbomascota.DataSource = clmascotas.ListarMascotas();
            cbomascota.DisplayMember = "nombre_mascota";
            cbomascota.ValueMember = "Id_mascota";

           
        } 


    }
}
