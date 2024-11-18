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



namespace Capa_Presentacion
    {
        public partial class frmRoles : Form
        {
            private CL_Rol cl_rol = new CL_Rol(); // Instancia de la clase de lógica de negocio (solo una vez)

            public frmRoles()
            {
                InitializeComponent();
            }

            private void btnGuardar_Click(object sender, EventArgs e)
            {
                string nombre_rol = txtNombreRol.Text;

                try
                {
                    // Llama al método InsertarRol de la instancia cl_rol creada al inicio
                    cl_rol.InsertarRol(nombre_rol);

                    MessageBox.Show("Rol guardado exitosamente.");

                    // Limpia el campo de texto después de guardar
                    txtNombreRol.Clear();

                     CargarRol();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el rol: " + ex.Message);
                }
            }


        private void CargarRol()
        {

            try
            {
                // Obtener la lista de Rol desde la capa lógica
                List<Rol> lista = cl_rol.ListarRoles();

                // Asignar la lista de Rol como fuente de datos del DataGridView
                dgvRol.DataSource = lista;

                // Asegúrate de que el nombre de la columna coincide con el nombre en tu DataGridView.
                

                dgvRol.Columns["Id_rol"].ReadOnly = true;
                dgvRol.Columns["Id_rol"].HeaderText = "ID Rol";
                dgvRol.Columns["nombre_rol"].ReadOnly = true;
                dgvRol.Columns["nombre_rol"].HeaderText = "Nombre Rol";
                dgvRol.Columns["fecha_registro"].Visible = false;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar los Roles: " +e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            CargarRol();
        }
    }
}

   
    
