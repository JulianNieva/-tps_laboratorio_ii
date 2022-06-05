
namespace Formularios
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstListado = new System.Windows.Forms.ListBox();
            this.grbListado = new System.Windows.Forms.GroupBox();
            this.btnListarReclamos = new System.Windows.Forms.Button();
            this.btnListarClientes = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblNombreYApellido = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblServicios = new System.Windows.Forms.Label();
            this.grbListado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstListado
            // 
            this.lstListado.BackColor = System.Drawing.Color.Lavender;
            this.lstListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstListado.ColumnWidth = 5;
            this.lstListado.ItemHeight = 15;
            this.lstListado.Location = new System.Drawing.Point(250, 12);
            this.lstListado.Name = "lstListado";
            this.lstListado.Size = new System.Drawing.Size(459, 300);
            this.lstListado.TabIndex = 0;
            this.lstListado.SelectedValueChanged += new System.EventHandler(this.lstListado_SelectedValueChanged);
            // 
            // grbListado
            // 
            this.grbListado.Controls.Add(this.btnListarReclamos);
            this.grbListado.Controls.Add(this.btnListarClientes);
            this.grbListado.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grbListado.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.grbListado.Location = new System.Drawing.Point(12, 27);
            this.grbListado.Name = "grbListado";
            this.grbListado.Size = new System.Drawing.Size(232, 202);
            this.grbListado.TabIndex = 1;
            this.grbListado.TabStop = false;
            this.grbListado.Text = "Listar: ";
            // 
            // btnListarReclamos
            // 
            this.btnListarReclamos.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnListarReclamos.Location = new System.Drawing.Point(7, 117);
            this.btnListarReclamos.Name = "btnListarReclamos";
            this.btnListarReclamos.Size = new System.Drawing.Size(219, 64);
            this.btnListarReclamos.TabIndex = 1;
            this.btnListarReclamos.Text = "Reclamos";
            this.btnListarReclamos.UseVisualStyleBackColor = false;
            this.btnListarReclamos.Click += new System.EventHandler(this.btnListarReclamos_Click);
            // 
            // btnListarClientes
            // 
            this.btnListarClientes.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnListarClientes.Location = new System.Drawing.Point(7, 23);
            this.btnListarClientes.Name = "btnListarClientes";
            this.btnListarClientes.Size = new System.Drawing.Size(219, 64);
            this.btnListarClientes.TabIndex = 0;
            this.btnListarClientes.Text = "Clientes";
            this.btnListarClientes.UseVisualStyleBackColor = false;
            this.btnListarClientes.Click += new System.EventHandler(this.btnListarClientes_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAgregar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAgregar.Location = new System.Drawing.Point(715, 12);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(175, 76);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar Cliente";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEliminar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminar.Location = new System.Drawing.Point(715, 121);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(175, 76);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar Cliente";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblNombreYApellido
            // 
            this.lblNombreYApellido.AutoSize = true;
            this.lblNombreYApellido.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblNombreYApellido.Location = new System.Drawing.Point(250, 340);
            this.lblNombreYApellido.Name = "lblNombreYApellido";
            this.lblNombreYApellido.Size = new System.Drawing.Size(47, 17);
            this.lblNombreYApellido.TabIndex = 5;
            this.lblNombreYApellido.Text = "label1";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblDni.Location = new System.Drawing.Point(250, 412);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(47, 17);
            this.lblDni.TabIndex = 6;
            this.lblDni.Text = "label1";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblLocalidad.Location = new System.Drawing.Point(480, 340);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(47, 17);
            this.lblLocalidad.TabIndex = 7;
            this.lblLocalidad.Text = "label1";
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblServicios.Location = new System.Drawing.Point(480, 384);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(47, 17);
            this.lblServicios.TabIndex = 8;
            this.lblServicios.Text = "label1";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(900, 472);
            this.Controls.Add(this.lblServicios);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblNombreYApellido);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.grbListado);
            this.Controls.Add(this.lstListado);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RedSignal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.grbListado.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstListado;
        private System.Windows.Forms.GroupBox grbListado;
        private System.Windows.Forms.Button btnListarReclamos;
        private System.Windows.Forms.Button btnListarClientes;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblNombreYApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblServicios;
    }
}

