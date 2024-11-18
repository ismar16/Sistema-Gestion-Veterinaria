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

using Capa_Entidad;

namespace Capa_Presentacion
{

    
    public partial class Inicio : Form
    {
        private static Usuario usuarioaactual;
        private static IconMenuItem MenuACtivo= null;
        private static Form formularioActivo = null;


    public Inicio(Usuario objusuario)
        {

            usuarioaactual = objusuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            lblusuario.Text = usuarioaactual.nombres;
        }

        private void AbrirFormulario (IconMenuItem menu, Form formulario)
        {
            if (MenuACtivo != null)
            {
                MenuACtivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Gray;
            MenuACtivo = menu;

            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
        }

        private void menuUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
            

           
        }

        private void menuRol_Click(object sender, EventArgs e)
        {

        }
    }
}
