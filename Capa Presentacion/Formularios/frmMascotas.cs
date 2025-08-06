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
    public partial class frmMascotas : Form
    {
        private CL_Mascotas cl_mascotas = new CL_Mascotas();
        private CL_Popietario clpropietarios = new CL_Popietario();
        
        
        public frmMascotas()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmMascotas_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarMascotas();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPropietario.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un propietario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpfechanacimineto.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha de nacimiento no puede ser futura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Mascotas nuevoMascota = new Mascotas
                {
                    nombre_mascota = txtnombremascota.Text,
                    especie = txtespecie.Text,
                    raza = txtraza.Text,
                    fecha_nacimiento = dtpfechanacimineto.Value,
                    oPropietario = new Propietario
                    {
                        Id_propietario = (int)cboPropietario.SelectedValue
                    }
                };

                cl_mascotas.InsertarMascotas(nuevoMascota);

                MessageBox.Show("Mascota insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMascotas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar la mascota: {ex.Message}\n{ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CargarMascotas()
        {
            try
            {
                var mascotas = cl_mascotas.ListarMascotas();

                if (mascotas != null && mascotas.Count > 0)
                {
                    var datosAMostrar = mascotas.Select(m => new
                    {
                        Id_mascota = m.Id_mascota,
                        nombre_mascota = m.nombre_mascota,
                        especie = m.especie,
                        raza = m.raza,
                        fecha_nacimiento = m.fecha_nacimiento, // Corregido typo
                        Propietario = m.oPropietario != null ? m.oPropietario.Id_propietario : 0
                    }).ToList();

                    dgvMascotas.DataSource = datosAMostrar;

                    dgvMascotas.Columns["Id_mascota"].HeaderText = "ID Mascota";
                    dgvMascotas.Columns["nombre_mascota"].HeaderText = "Nombre";
                    dgvMascotas.Columns["especie"].HeaderText = "Especie";
                    dgvMascotas.Columns["raza"].HeaderText = "Raza";
                    dgvMascotas.Columns["fecha_nacimiento"].HeaderText = "Fecha Nacimiento";
                    dgvMascotas.Columns["Propietario"].HeaderText = "Propietario";
                }
                else
                {
                    MessageBox.Show("No se encontraron mascotas para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las mascotas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboPropietario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CargarDatos()
        {
            // Cargar datos para el combo box de roles
            var propietarios = clpropietarios.ListarPropietario(); // Suponiendo que obtienes una lista o DataTable
           cboPropietario.DataSource = propietarios;
           cboPropietario.DisplayMember = "nombres_propietario";  // Nombre de la columna para mostrar
           cboPropietario.ValueMember = "Id_propietario";       // Nombre de la columna que sirve como valor
            

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
                try
                {
                    // Verificar que se haya seleccionado una fila en el DataGridView
                    if (dgvMascotas.SelectedRows.Count > 0)
                    {
                        int Id_mascota = (int)dgvMascotas.SelectedRows[0].Cells["Id_mascota"].Value;

                        // Llamar a la lógica para eliminar la mascota
                        CL_Mascotas logicaMascotas = new CL_Mascotas();
                        logicaMascotas.EliminarMascota(Id_mascota);

                        MessageBox.Show("Mascota eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refrescar la lista de mascotas
                        CargarMascotas();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una mascota para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la mascota: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }
    }
}
