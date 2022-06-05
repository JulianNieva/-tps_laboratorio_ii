
namespace Formularios
{
    partial class FormAltaReclamos
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
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.lblSeleccionClientes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarReclamo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grbxListaDeServicios = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 15;
            this.lstClientes.Location = new System.Drawing.Point(12, 27);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(240, 214);
            this.lstClientes.TabIndex = 0;
            this.lstClientes.SelectedValueChanged += new System.EventHandler(this.lstClientes_SelectedValueChanged);
            // 
            // lblSeleccionClientes
            // 
            this.lblSeleccionClientes.AutoSize = true;
            this.lblSeleccionClientes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSeleccionClientes.Location = new System.Drawing.Point(12, 9);
            this.lblSeleccionClientes.Name = "lblSeleccionClientes";
            this.lblSeleccionClientes.Size = new System.Drawing.Size(118, 15);
            this.lblSeleccionClientes.TabIndex = 1;
            this.lblSeleccionClientes.Text = "Seleccione un cliente";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(290, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "¿Que servicio se esta haciendo un reclamo?";
            // 
            // btnAgregarReclamo
            // 
            this.btnAgregarReclamo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgregarReclamo.Location = new System.Drawing.Point(290, 187);
            this.btnAgregarReclamo.Name = "btnAgregarReclamo";
            this.btnAgregarReclamo.Size = new System.Drawing.Size(120, 24);
            this.btnAgregarReclamo.TabIndex = 4;
            this.btnAgregarReclamo.Text = "Agregar Reclamo";
            this.btnAgregarReclamo.UseVisualStyleBackColor = true;
            this.btnAgregarReclamo.Click += new System.EventHandler(this.btnAgregarReclamo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.Location = new System.Drawing.Point(290, 217);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 24);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar Reclamo";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grbxListaDeServicios
            // 
            this.grbxListaDeServicios.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grbxListaDeServicios.Location = new System.Drawing.Point(290, 86);
            this.grbxListaDeServicios.Name = "grbxListaDeServicios";
            this.grbxListaDeServicios.Size = new System.Drawing.Size(141, 95);
            this.grbxListaDeServicios.TabIndex = 6;
            this.grbxListaDeServicios.TabStop = false;
            this.grbxListaDeServicios.Text = "Lista de servicios";
            // 
            // FormAltaReclamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(443, 254);
            this.Controls.Add(this.grbxListaDeServicios);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregarReclamo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSeleccionClientes);
            this.Controls.Add(this.lstClientes);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAltaReclamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Reclamos";
            this.Load += new System.EventHandler(this.FormAltaReclamos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.Label lblSeleccionClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarReclamo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grbxListaDeServicios;
    }
}