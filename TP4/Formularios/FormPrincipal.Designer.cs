
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
            this.grbListado = new System.Windows.Forms.GroupBox();
            this.btnListarReclamos = new System.Windows.Forms.Button();
            this.btnListarClientes = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblServicios = new System.Windows.Forms.Label();
            this.btnGuardarInformes = new System.Windows.Forms.Button();
            this.cmbTipoArchivo = new System.Windows.Forms.ComboBox();
            this.dtgListado = new System.Windows.Forms.DataGridView();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.grbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListado)).BeginInit();
            this.SuspendLayout();
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
            this.btnListarReclamos.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnListarReclamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btnListarClientes.BackColor = System.Drawing.Color.SlateBlue;
            this.btnListarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAgregar.Location = new System.Drawing.Point(707, 12);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(175, 76);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar Cliente";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminar.Location = new System.Drawing.Point(707, 205);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(175, 76);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar Cliente";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblServicios.Location = new System.Drawing.Point(601, 351);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(42, 17);
            this.lblServicios.TabIndex = 8;
            this.lblServicios.Text = "datos";
            // 
            // btnGuardarInformes
            // 
            this.btnGuardarInformes.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardarInformes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarInformes.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarInformes.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardarInformes.Location = new System.Drawing.Point(12, 365);
            this.btnGuardarInformes.Name = "btnGuardarInformes";
            this.btnGuardarInformes.Size = new System.Drawing.Size(219, 64);
            this.btnGuardarInformes.TabIndex = 2;
            this.btnGuardarInformes.Text = "Guardar Listados";
            this.btnGuardarInformes.UseVisualStyleBackColor = false;
            this.btnGuardarInformes.Click += new System.EventHandler(this.btnGuardarInformes_Click);
            // 
            // cmbTipoArchivo
            // 
            this.cmbTipoArchivo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbTipoArchivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoArchivo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbTipoArchivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbTipoArchivo.FormattingEnabled = true;
            this.cmbTipoArchivo.Items.AddRange(new object[] {
            "",
            "XML",
            "TXT",
            "JSON"});
            this.cmbTipoArchivo.Location = new System.Drawing.Point(12, 330);
            this.cmbTipoArchivo.Name = "cmbTipoArchivo";
            this.cmbTipoArchivo.Size = new System.Drawing.Size(121, 29);
            this.cmbTipoArchivo.TabIndex = 9;
            // 
            // dtgListado
            // 
            this.dtgListado.AllowUserToAddRows = false;
            this.dtgListado.AllowUserToDeleteRows = false;
            this.dtgListado.AllowUserToResizeColumns = false;
            this.dtgListado.AllowUserToResizeRows = false;
            this.dtgListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgListado.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dtgListado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListado.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.dtgListado.Location = new System.Drawing.Point(265, 27);
            this.dtgListado.MultiSelect = false;
            this.dtgListado.Name = "dtgListado";
            this.dtgListado.ReadOnly = true;
            this.dtgListado.RowHeadersVisible = false;
            this.dtgListado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dtgListado.RowTemplate.Height = 25;
            this.dtgListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListado.ShowCellErrors = false;
            this.dtgListado.ShowCellToolTips = false;
            this.dtgListado.ShowEditingIcon = false;
            this.dtgListado.Size = new System.Drawing.Size(414, 293);
            this.dtgListado.TabIndex = 10;
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarCliente.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnModificarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificarCliente.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificarCliente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnModificarCliente.Location = new System.Drawing.Point(707, 108);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(175, 76);
            this.btnModificarCliente.TabIndex = 11;
            this.btnModificarCliente.Text = "Modificar Cliente";
            this.btnModificarCliente.UseVisualStyleBackColor = false;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(892, 472);
            this.Controls.Add(this.btnModificarCliente);
            this.Controls.Add(this.dtgListado);
            this.Controls.Add(this.cmbTipoArchivo);
            this.Controls.Add(this.btnGuardarInformes);
            this.Controls.Add(this.lblServicios);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.grbListado);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RedSignal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.grbListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grbListado;
        private System.Windows.Forms.Button btnListarReclamos;
        private System.Windows.Forms.Button btnListarClientes;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblServicios;
        private System.Windows.Forms.Button btnGuardarInformes;
        private System.Windows.Forms.ComboBox cmbTipoArchivo;
        private System.Windows.Forms.DataGridView dtgListado;
        private System.Windows.Forms.Button btnModificarCliente;
    }
}

