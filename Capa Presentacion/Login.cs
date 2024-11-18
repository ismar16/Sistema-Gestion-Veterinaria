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
    public partial class Login : Form
    {
      
       
        public  Login()
        {
            InitializeComponent();
        }

       

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btningresar_Click(object sender, EventArgs e)

        {
            if (!int.TryParse(txtCarnet.Text, out int carnet))
            {
                MessageBox.Show("Por favor ingresa un número de carnet válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  
            }

            string clave = txtClave.Text;


            
            
            Usuario ousuario = new CL_Usuario().Listar().Where(u => u.carnet == carnet &&  u.clave == clave).FirstOrDefault();

            if (ousuario != null)
            {
                Inicio form = new Inicio(ousuario);
                form.Show();
                this.Hide();


                form.FormClosing += formClosing;

            }else
            {
                MessageBox.Show("Carnet o Clave son incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void formClosing (object sender, FormClosingEventArgs e )
        {
            txtCarnet.Text = " ";
            txtClave.Text = " ";
            this.Show();

        }

        
    }
}
