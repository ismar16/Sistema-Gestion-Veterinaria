
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
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.menuacceso = new FontAwesome.Sharp.IconMenuItem();
            this.menuUsuario = new FontAwesome.Sharp.IconMenuItem();
            this.menuEmpleados = new FontAwesome.Sharp.IconMenuItem();
            this.menuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.menuRegistrarCompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.menuRegistrarVenta = new FontAwesome.Sharp.IconMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuProductos = new FontAwesome.Sharp.IconMenuItem();
            this.menuInventario = new FontAwesome.Sharp.IconMenuItem();
            this.menuCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.menuGestionClinica = new FontAwesome.Sharp.IconMenuItem();
            this.menuCitas = new FontAwesome.Sharp.IconMenuItem();
            this.menuHistorial = new FontAwesome.Sharp.IconMenuItem();
            this.menuMascotas = new FontAwesome.Sharp.IconMenuItem();
            this.menuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuPagoServicios = new FontAwesome.Sharp.IconMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuAcercaDe = new FontAwesome.Sharp.IconMenuItem();
            this.menuConfiguracion = new FontAwesome.Sharp.IconMenuItem();
            this.menuRol = new FontAwesome.Sharp.IconMenuItem();
            this.menuPermisos = new FontAwesome.Sharp.IconMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.PContenedor = new System.Windows.Forms.Panel();
            this.menuAsignacion = new FontAwesome.Sharp.IconMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            resources.ApplyResources(this.Menu, "Menu");
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuacceso,
            this.menuCompras,
            this.menuVentas,
            this.menuProductos,
            this.menuGestionClinica,
            this.menuConfiguracion,
            this.menuReportes,
            this.menuAcercaDe});
            this.Menu.Name = "Menu";
            this.Menu.Stretch = false;
            // 
            // menuacceso
            // 
            this.menuacceso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuario,
            this.menuEmpleados});
            this.menuacceso.IconChar = FontAwesome.Sharp.IconChar.User;
            this.menuacceso.IconColor = System.Drawing.Color.Black;
            this.menuacceso.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuacceso, "menuacceso");
            this.menuacceso.Name = "menuacceso";
            // 
            // menuUsuario
            // 
            this.menuUsuario.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuUsuario.IconColor = System.Drawing.Color.Black;
            this.menuUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuario.Name = "menuUsuario";
            resources.ApplyResources(this.menuUsuario, "menuUsuario");
            this.menuUsuario.Click += new System.EventHandler(this.menuUsuario_Click);
            // 
            // menuEmpleados
            // 
            this.menuEmpleados.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuEmpleados.IconColor = System.Drawing.Color.Black;
            this.menuEmpleados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuEmpleados.Name = "menuEmpleados";
            resources.ApplyResources(this.menuEmpleados, "menuEmpleados");
            // 
            // menuCompras
            // 
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRegistrarCompra});
            this.menuCompras.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.menuCompras.IconColor = System.Drawing.Color.Black;
            this.menuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuCompras, "menuCompras");
            this.menuCompras.Name = "menuCompras";
            // 
            // menuRegistrarCompra
            // 
            this.menuRegistrarCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuRegistrarCompra.IconColor = System.Drawing.Color.Black;
            this.menuRegistrarCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuRegistrarCompra.Name = "menuRegistrarCompra";
            resources.ApplyResources(this.menuRegistrarCompra, "menuRegistrarCompra");
            // 
            // menuVentas
            // 
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRegistrarVenta,
            this.toolStripSeparator1});
            this.menuVentas.IconChar = FontAwesome.Sharp.IconChar.CreditCardAlt;
            this.menuVentas.IconColor = System.Drawing.Color.Black;
            this.menuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuVentas, "menuVentas");
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // menuRegistrarVenta
            // 
            this.menuRegistrarVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuRegistrarVenta.IconColor = System.Drawing.Color.Black;
            this.menuRegistrarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuRegistrarVenta.Name = "menuRegistrarVenta";
            resources.ApplyResources(this.menuRegistrarVenta, "menuRegistrarVenta");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // menuProductos
            // 
            this.menuProductos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInventario,
            this.menuCategoria});
            this.menuProductos.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.menuProductos.IconColor = System.Drawing.Color.Black;
            this.menuProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuProductos, "menuProductos");
            this.menuProductos.Name = "menuProductos";
            // 
            // menuInventario
            // 
            this.menuInventario.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuInventario.IconColor = System.Drawing.Color.Black;
            this.menuInventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuInventario.Name = "menuInventario";
            resources.ApplyResources(this.menuInventario, "menuInventario");
            // 
            // menuCategoria
            // 
            this.menuCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuCategoria.IconColor = System.Drawing.Color.Black;
            this.menuCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCategoria.Name = "menuCategoria";
            resources.ApplyResources(this.menuCategoria, "menuCategoria");
            // 
            // menuGestionClinica
            // 
            this.menuGestionClinica.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCitas,
            this.menuHistorial,
            this.menuMascotas,
            this.menuClientes,
            this.menuPagoServicios});
            this.menuGestionClinica.IconChar = FontAwesome.Sharp.IconChar.HospitalWide;
            this.menuGestionClinica.IconColor = System.Drawing.Color.Black;
            this.menuGestionClinica.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuGestionClinica, "menuGestionClinica");
            this.menuGestionClinica.Name = "menuGestionClinica";
            // 
            // menuCitas
            // 
            this.menuCitas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuCitas.IconColor = System.Drawing.Color.Black;
            this.menuCitas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCitas.Name = "menuCitas";
            resources.ApplyResources(this.menuCitas, "menuCitas");
            // 
            // menuHistorial
            // 
            this.menuHistorial.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuHistorial.IconColor = System.Drawing.Color.Black;
            this.menuHistorial.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuHistorial.Name = "menuHistorial";
            resources.ApplyResources(this.menuHistorial, "menuHistorial");
            // 
            // menuMascotas
            // 
            this.menuMascotas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuMascotas.IconColor = System.Drawing.Color.Black;
            this.menuMascotas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMascotas.Name = "menuMascotas";
            resources.ApplyResources(this.menuMascotas, "menuMascotas");
            // 
            // menuClientes
            // 
            this.menuClientes.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuClientes.IconColor = System.Drawing.Color.Black;
            this.menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClientes.Name = "menuClientes";
            resources.ApplyResources(this.menuClientes, "menuClientes");
            // 
            // menuPagoServicios
            // 
            this.menuPagoServicios.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuPagoServicios.IconColor = System.Drawing.Color.Black;
            this.menuPagoServicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuPagoServicios.Name = "menuPagoServicios";
            resources.ApplyResources(this.menuPagoServicios, "menuPagoServicios");
            // 
            // menuReportes
            // 
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuReportes, "menuReportes");
            this.menuReportes.Name = "menuReportes";
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuAcercaDe.IconColor = System.Drawing.Color.Black;
            this.menuAcercaDe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.menuAcercaDe, "menuAcercaDe");
            this.menuAcercaDe.Name = "menuAcercaDe";
            // 
            // menuConfiguracion
            // 
            this.menuConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRol,
            this.menuPermisos,
            this.menuAsignacion});
            this.menuConfiguracion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuConfiguracion.IconColor = System.Drawing.Color.Black;
            this.menuConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuConfiguracion.Name = "menuConfiguracion";
            resources.ApplyResources(this.menuConfiguracion, "menuConfiguracion");
            // 
            // menuRol
            // 
            this.menuRol.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuRol.IconColor = System.Drawing.Color.Black;
            this.menuRol.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuRol.Name = "menuRol";
            resources.ApplyResources(this.menuRol, "menuRol");
            this.menuRol.Click += new System.EventHandler(this.menuRol_Click);
            // 
            // menuPermisos
            // 
            this.menuPermisos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuPermisos.IconColor = System.Drawing.Color.Black;
            this.menuPermisos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuPermisos.Name = "menuPermisos";
            resources.ApplyResources(this.menuPermisos, "menuPermisos");
            // 
            // menuTitulo
            // 
            resources.ApplyResources(this.menuTitulo, "menuTitulo");
            this.menuTitulo.BackColor = System.Drawing.Color.Blue;
            this.menuTitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTitulo.Name = "menuTitulo";
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
            this.label2.Name = "label2";
            // 
            // lblusuario
            // 
            this.lblusuario.BackColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.lblusuario, "lblusuario");
            this.lblusuario.Name = "lblusuario";
            // 
            // PContenedor
            // 
            this.PContenedor.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.PContenedor, "PContenedor");
            this.PContenedor.Name = "PContenedor";
            // 
            // menuAsignacion
            // 
            this.menuAsignacion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuAsignacion.IconColor = System.Drawing.Color.Black;
            this.menuAsignacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAsignacion.Name = "menuAsignacion";
            resources.ApplyResources(this.menuAsignacion, "menuAsignacion");
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
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.menuTitulo);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Menu;
            this.Name = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuacceso;
        private FontAwesome.Sharp.IconMenuItem menuCompras;
        private FontAwesome.Sharp.IconMenuItem menuVentas;
        private FontAwesome.Sharp.IconMenuItem menuUsuario;
        private FontAwesome.Sharp.IconMenuItem menuEmpleados;
        private FontAwesome.Sharp.IconMenuItem menuRegistrarCompra;
        private FontAwesome.Sharp.IconMenuItem menuRegistrarVenta;
        private FontAwesome.Sharp.IconMenuItem menuProductos;
        private FontAwesome.Sharp.IconMenuItem menuInventario;
        private FontAwesome.Sharp.IconMenuItem menuCategoria;
        private FontAwesome.Sharp.IconMenuItem menuGestionClinica;
        private FontAwesome.Sharp.IconMenuItem menuCitas;
        private FontAwesome.Sharp.IconMenuItem menuHistorial;
        private FontAwesome.Sharp.IconMenuItem menuMascotas;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private FontAwesome.Sharp.IconMenuItem menuAcercaDe;
        private FontAwesome.Sharp.IconMenuItem menuPagoServicios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Panel PContenedor;
        private FontAwesome.Sharp.IconMenuItem menuConfiguracion;
        private FontAwesome.Sharp.IconMenuItem menuRol;
        private FontAwesome.Sharp.IconMenuItem menuPermisos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private FontAwesome.Sharp.IconMenuItem menuAsignacion;
    }
}