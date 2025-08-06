
namespace Capa_Presentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.MenuContendor = new System.Windows.Forms.MenuStrip();
            this.menuacceso = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuUsuario = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuEmpleados = new FontAwesome.Sharp.IconMenuItem();
            this.menuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuRegistrarCompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuProductos = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuInventario = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.menuGestionClinica = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuHistorial = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuMascotas = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuConfiguracion = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuRol = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuPermisos = new FontAwesome.Sharp.IconMenuItem();
            this.SubmenuAsignacion = new FontAwesome.Sharp.IconMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.PContenedor = new System.Windows.Forms.Panel();
            this.MenuContendor.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuContendor
            // 
            resources.ApplyResources(this.MenuContendor, "MenuContendor");
            this.MenuContendor.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuContendor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuacceso,
            this.menuCompras,
            this.menuProductos,
            this.menuGestionClinica,
            this.menuConfiguracion});
            this.MenuContendor.Name = "MenuContendor";
            this.MenuContendor.Stretch = false;
            // 
            // menuacceso
            // 
            this.menuacceso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmenuUsuario,
            this.SubmenuEmpleados});
            this.menuacceso.IconChar = FontAwesome.Sharp.IconChar.User;
            this.menuacceso.IconColor = System.Drawing.Color.Black;
            this.menuacceso.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuacceso, "menuacceso");
            this.menuacceso.Name = "menuacceso";
            // 
            // SubmenuUsuario
            // 
            this.SubmenuUsuario.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuUsuario.IconColor = System.Drawing.Color.Black;
            this.SubmenuUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuUsuario.Name = "SubmenuUsuario";
            resources.ApplyResources(this.SubmenuUsuario, "SubmenuUsuario");
            this.SubmenuUsuario.Click += new System.EventHandler(this.menuUsuario_Click);
            // 
            // SubmenuEmpleados
            // 
            this.SubmenuEmpleados.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuEmpleados.IconColor = System.Drawing.Color.Black;
            this.SubmenuEmpleados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuEmpleados.Name = "SubmenuEmpleados";
            resources.ApplyResources(this.SubmenuEmpleados, "SubmenuEmpleados");
            this.SubmenuEmpleados.Click += new System.EventHandler(this.SubmenuEmpleados_Click);
            // 
            // menuCompras
            // 
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmenuRegistrarCompra});
            this.menuCompras.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.menuCompras.IconColor = System.Drawing.Color.Black;
            this.menuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuCompras, "menuCompras");
            this.menuCompras.Name = "menuCompras";
            // 
            // SubmenuRegistrarCompra
            // 
            this.SubmenuRegistrarCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuRegistrarCompra.IconColor = System.Drawing.Color.Black;
            this.SubmenuRegistrarCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuRegistrarCompra.Name = "SubmenuRegistrarCompra";
            resources.ApplyResources(this.SubmenuRegistrarCompra, "SubmenuRegistrarCompra");
            this.SubmenuRegistrarCompra.Click += new System.EventHandler(this.SubmenuRegistrarCompra_Click);
            // 
            // menuProductos
            // 
            this.menuProductos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmenuInventario,
            this.SubmenuCategoria});
            this.menuProductos.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.menuProductos.IconColor = System.Drawing.Color.Black;
            this.menuProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuProductos, "menuProductos");
            this.menuProductos.Name = "menuProductos";
            // 
            // SubmenuInventario
            // 
            this.SubmenuInventario.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuInventario.IconColor = System.Drawing.Color.Black;
            this.SubmenuInventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuInventario.Name = "SubmenuInventario";
            resources.ApplyResources(this.SubmenuInventario, "SubmenuInventario");
            this.SubmenuInventario.Click += new System.EventHandler(this.SubmenuInventario_Click);
            // 
            // SubmenuCategoria
            // 
            this.SubmenuCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuCategoria.IconColor = System.Drawing.Color.Black;
            this.SubmenuCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuCategoria.Name = "SubmenuCategoria";
            resources.ApplyResources(this.SubmenuCategoria, "SubmenuCategoria");
            this.SubmenuCategoria.Click += new System.EventHandler(this.SubmenuCategoria_Click);
            // 
            // menuGestionClinica
            // 
            this.menuGestionClinica.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmenuHistorial,
            this.SubmenuMascotas,
            this.SubmenuClientes});
            this.menuGestionClinica.IconChar = FontAwesome.Sharp.IconChar.HospitalWide;
            this.menuGestionClinica.IconColor = System.Drawing.Color.Black;
            this.menuGestionClinica.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuGestionClinica, "menuGestionClinica");
            this.menuGestionClinica.Name = "menuGestionClinica";
            // 
            // SubmenuHistorial
            // 
            this.SubmenuHistorial.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuHistorial.IconColor = System.Drawing.Color.Black;
            this.SubmenuHistorial.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuHistorial.Name = "SubmenuHistorial";
            resources.ApplyResources(this.SubmenuHistorial, "SubmenuHistorial");
            this.SubmenuHistorial.Click += new System.EventHandler(this.SubmenuHistorial_Click);
            // 
            // SubmenuMascotas
            // 
            this.SubmenuMascotas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuMascotas.IconColor = System.Drawing.Color.Black;
            this.SubmenuMascotas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuMascotas.Name = "SubmenuMascotas";
            resources.ApplyResources(this.SubmenuMascotas, "SubmenuMascotas");
            this.SubmenuMascotas.Click += new System.EventHandler(this.SubmenuMascotas_Click);
            // 
            // SubmenuClientes
            // 
            this.SubmenuClientes.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuClientes.IconColor = System.Drawing.Color.Black;
            this.SubmenuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuClientes.Name = "SubmenuClientes";
            resources.ApplyResources(this.SubmenuClientes, "SubmenuClientes");
            this.SubmenuClientes.Click += new System.EventHandler(this.SubmenuClientes_Click);
            // 
            // menuConfiguracion
            // 
            this.menuConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmenuRol,
            this.SubmenuPermisos,
            this.SubmenuAsignacion});
            this.menuConfiguracion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuConfiguracion.IconColor = System.Drawing.Color.Black;
            this.menuConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuConfiguracion.Name = "menuConfiguracion";
            resources.ApplyResources(this.menuConfiguracion, "menuConfiguracion");
            // 
            // SubmenuRol
            // 
            this.SubmenuRol.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuRol.IconColor = System.Drawing.Color.Black;
            this.SubmenuRol.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuRol.Name = "SubmenuRol";
            resources.ApplyResources(this.SubmenuRol, "SubmenuRol");
            this.SubmenuRol.Click += new System.EventHandler(this.menuRol_Click);
            // 
            // SubmenuPermisos
            // 
            this.SubmenuPermisos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuPermisos.IconColor = System.Drawing.Color.Black;
            this.SubmenuPermisos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuPermisos.Name = "SubmenuPermisos";
            resources.ApplyResources(this.SubmenuPermisos, "SubmenuPermisos");
            this.SubmenuPermisos.Click += new System.EventHandler(this.SubmenuPermisos_Click);
            // 
            // SubmenuAsignacion
            // 
            this.SubmenuAsignacion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubmenuAsignacion.IconColor = System.Drawing.Color.Black;
            this.SubmenuAsignacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubmenuAsignacion.Name = "SubmenuAsignacion";
            resources.ApplyResources(this.SubmenuAsignacion, "SubmenuAsignacion");
            this.SubmenuAsignacion.Click += new System.EventHandler(this.SubmenuAsignacion_Click);
            // 
            // menuTitulo
            // 
            resources.ApplyResources(this.menuTitulo, "menuTitulo");
            this.menuTitulo.BackColor = System.Drawing.Color.Blue;
            this.menuTitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuTitulo_ItemClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Name = "label2";
            // 
            // lblusuario
            // 
            this.lblusuario.BackColor = System.Drawing.Color.Blue;
            this.lblusuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.lblusuario, "lblusuario");
            this.lblusuario.Name = "lblusuario";
            // 
            // PContenedor
            // 
            this.PContenedor.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.PContenedor, "PContenedor");
            this.PContenedor.Name = "PContenedor";
            // 
            // Inicio
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PContenedor);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MenuContendor);
            this.Controls.Add(this.menuTitulo);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuContendor;
            this.Name = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.MenuContendor.ResumeLayout(false);
            this.MenuContendor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuContendor;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuacceso;
        private FontAwesome.Sharp.IconMenuItem menuCompras;
        private FontAwesome.Sharp.IconMenuItem SubmenuUsuario;
        private FontAwesome.Sharp.IconMenuItem SubmenuEmpleados;
        private FontAwesome.Sharp.IconMenuItem SubmenuRegistrarCompra;
        private FontAwesome.Sharp.IconMenuItem menuProductos;
        private FontAwesome.Sharp.IconMenuItem SubmenuInventario;
        private FontAwesome.Sharp.IconMenuItem SubmenuCategoria;
        private FontAwesome.Sharp.IconMenuItem menuGestionClinica;
        private FontAwesome.Sharp.IconMenuItem SubmenuHistorial;
        private FontAwesome.Sharp.IconMenuItem SubmenuMascotas;
        private FontAwesome.Sharp.IconMenuItem SubmenuClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Panel PContenedor;
        private FontAwesome.Sharp.IconMenuItem menuConfiguracion;
        private FontAwesome.Sharp.IconMenuItem SubmenuRol;
        private FontAwesome.Sharp.IconMenuItem SubmenuPermisos;
        private FontAwesome.Sharp.IconMenuItem SubmenuAsignacion;
    }
}