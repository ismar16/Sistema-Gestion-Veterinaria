using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

using Capa_Presentacion.Formularios;
using Capa_Entidad;
using Capa_Logica;

namespace Capa_Presentacion
{

    
    public partial class Inicio : Form
    {
        private static Usuario usuarioaactual;
        private static IconMenuItem MenuActivo= null;
        private static Form formularioActivo = null;


    public Inicio(Usuario objusuario)
        {

            usuarioaactual = objusuario;

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
          
                if (usuarioaactual != null)
                {
                    lblusuario.Text = usuarioaactual.nombres+" "+ usuarioaactual.apellidos;
                }
                else
                {
                    lblusuario.Text = "Usuario no definido";
                }
                // Cargar el formulario de usuarios por defecto
                AbrirFormulario(SubmenuUsuario, new frmUsuarios());
        }


        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            // Restablece el color del menú anterior
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }

            // Cambia el color del menú activo
            menu.BackColor = Color.Gray;
            MenuActivo = menu;

            // Cierra el formulario activo si ya existe
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            // Configura el formulario nuevo
            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            // Agrega el formulario al panel contenedor y lo muestra
            PContenedor.Controls.Clear(); // Asegúrate de limpiar el panel antes de añadir el formulario nuevo
            PContenedor.Controls.Add(formulario);
            formulario.Show();
        }


        private void menuUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
            


           
        }

        private void menuRol_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmRoles());
        }

        private void SubmenuEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmEmpleados());
        }

        private void SubmenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmVenta());
        }

        private void SubmenuPermisos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmPermisos());
        }

        private void SubmenuAsignacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new AsignarPermisos());
        }

        private void menuTitulo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SubmenuRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmCompras());
        }

        private void SubmenuInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmInventario ());
        }

        private void SubmenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new CategoriaProductos());
        }

        private void SubmenuHistorial_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new Formularios.HistorialClinico());
        }

        private void SubmenuCitas_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmCitas());
        }

        private void SubmenuMascotas_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmMascotas());
        }

        private void SubmenuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new Clientes());
        }
    }
}
