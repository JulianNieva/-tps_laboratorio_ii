using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Excepciones;

namespace Formularios
{
    public partial class FormAltaReclamos : Form
    {
        RedSignal red;
        Cliente cliente;

        public FormAltaReclamos(RedSignal red)
        {
            this.red = red;
            InitializeComponent();
        }

        private void FormAltaReclamos_Load(object sender, EventArgs e)
        {
            this.lstClientes.DataSource = red.ListaDeClientes;
            this.lstClientes.SelectedItem = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAgregarReclamo_Click(object sender, EventArgs e)
        {
            if(true)
            {

            }

        }

        private void lstClientes_SelectedValueChanged(object sender, EventArgs e)
        {
            if(this.lstClientes.SelectedItem is not null)
            {
                cliente = this.lstClientes.SelectedItem as Cliente;

                foreach (Servicio item in cliente.ServiciosContratados)
                {
                    RadioButton rb = new RadioButton();
                    

                }
            }
        }
    }
}
