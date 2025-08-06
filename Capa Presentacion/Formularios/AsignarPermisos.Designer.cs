
namespace Capa_Presentacion.Formularios
{
    partial class AsignarPermisos
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboROL = new System.Windows.Forms.ComboBox();
            this.dgvROlPermisos = new System.Windows.Forms.DataGridView();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvROlPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar Rol:";
            // 
            // cboROL
            // 
            this.cboROL.FormattingEnabled = true;
            this.cboROL.Location = new System.Drawing.Point(12, 70);
            this.cboROL.Name = "cboROL";
            this.cboROL.Size = new System.Drawing.Size(205, 24);
            this.cboROL.TabIndex = 1;
            this.cboROL.SelectedIndexChanged += new System.EventHandler(this.cboROL_SelectedIndexChanged);
            // 
            // dgvROlPermisos
            // 
            this.dgvROlPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvROlPermisos.Location = new System.Drawing.Point(12, 137);
            this.dgvROlPermisos.Name = "dgvROlPermisos";
            this.dgvROlPermisos.RowHeadersWidth = 51;
            this.dgvROlPermisos.RowTemplate.Height = 24;
            this.dgvROlPermisos.Size = new System.Drawing.Size(391, 300);
            this.dgvROlPermisos.TabIndex = 2;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(114, 455);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(186, 65);
            this.btnGuardarCambios.TabIndex = 3;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // AsignarPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 542);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.dgvROlPermisos);
            this.Controls.Add(this.cboROL);
            this.Controls.Add(this.label1);
            this.Name = "AsignarPermisos";
            this.Text = "AsignarPermisos";
            this.Load += new System.EventHandler(this.AsignarPermisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvROlPermisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboROL;
        private System.Windows.Forms.DataGridView dgvROlPermisos;
        private System.Windows.Forms.Button btnGuardarCambios;
    }
}