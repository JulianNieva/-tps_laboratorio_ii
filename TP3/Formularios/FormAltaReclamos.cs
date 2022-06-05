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
            DesactivarRadioButtons();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAgregarReclamo_Click(object sender, EventArgs e)
        {
            try
            {
                if(lstClientes.SelectedItem is not null)
                {
                    Reclamo reclamo;
                    string retornoFuncion = BuscarReclamoSeleccionado();

                    switch (retornoFuncion)
                    {
                        case "rbInternet":
                            reclamo = new Reclamo(this.lstClientes.SelectedItem as Cliente,FormPrincipal.internet,Reclamo.GenerarCodigoAlfanumerico());
                            break;
                        case "rbTelevision":
                            reclamo = new Reclamo(this.lstClientes.SelectedItem as Cliente,FormPrincipal.television,Reclamo.GenerarCodigoAlfanumerico());
                            break;
                        case "rbTelefono":
                            reclamo = new Reclamo(this.lstClientes.SelectedItem as Cliente,FormPrincipal.telefono,Reclamo.GenerarCodigoAlfanumerico());
                            break;
                        default:
                            throw new ReclamoException("Asegurese de seleccionar un servicio al que se desea realizar el reclamo");
                    }

                    if (red != reclamo)
                    {
                        red.ListaDeReclamos.Add(reclamo);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        throw new ReclamoException("Ya existe un reclamo con los mismo datos");
                    }
                }
                else
                {
                    throw new ReclamoException("No se seleccione un cliente!");
                }
                
            }
            catch (ReclamoException exc)
            {
                FormPrincipal.MostrarError(exc);
            }
        }

        private void lstClientes_SelectedValueChanged(object sender, EventArgs e)
        {
            DesactivarRadioButtons();

            if (this.lstClientes.SelectedItem is not null)
            {
                cliente = this.lstClientes.SelectedItem as Cliente;

                foreach (Servicio item in cliente.ServiciosContratados)
                {
                    switch (item)
                    {
                        case Television:
                            rbTelevision.Enabled = true;
                            break;
                        case Internet:
                            rbInternet.Enabled = true;
                            break;
                        default:
                            rbTelefono.Enabled = true;
                            break;
                    }

                }
            }
        }

        private void DesactivarRadioButtons()
        {
            this.rbInternet.Enabled = false;
            this.rbTelefono.Enabled = false;
            this.rbTelevision.Enabled = false;

            this.rbInternet.Checked = false;
            this.rbTelefono.Checked = false;
            this.rbTelevision.Checked = false;
        }

        private string BuscarReclamoSeleccionado()
        {
            string aux = string.Empty;

            foreach (RadioButton item in grbxListaDeServicios.Controls)
            {
                if(item.Checked)
                {
                    aux = item.Name;
                    break;
                }
            }

            return aux;
        }
    }
}
