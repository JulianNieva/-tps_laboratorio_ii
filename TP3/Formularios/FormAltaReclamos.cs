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

        /// <summary>
        /// Constructor que recibe la red
        /// </summary>
        /// <param name="red"></param>
        public FormAltaReclamos(RedSignal red)
        {
            this.red = red;
            InitializeComponent();
        }

        /// <summary>
        /// Se completa la lista con los clientes cargados en la red
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAltaReclamos_Load(object sender, EventArgs e)
        {
            this.lstClientes.DataSource = red.ListaDeClientes;
            this.lstClientes.SelectedItem = null;
            DesactivarRadioButtons();
        }

        /// <summary>
        /// Se cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Se agregara un reclamo siempre y cuando no exista en la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    throw new ReclamoException("No se selecciono un cliente!");
                }
                
            }
            catch (ReclamoException exc)
            {
                FormPrincipal.MostrarError(exc);
            }
        }

        /// <summary>
        /// Cuando se selecciona un cliente, se actualiza los radiobuttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Se desactivan los radiobuttons
        /// </summary>
        private void DesactivarRadioButtons()
        {
            this.rbInternet.Enabled = false;
            this.rbTelefono.Enabled = false;
            this.rbTelevision.Enabled = false;

            this.rbInternet.Checked = false;
            this.rbTelefono.Checked = false;
            this.rbTelevision.Checked = false;
        }

        /// <summary>
        /// Reviso cual fue el servicio seleccionado de los radiobuttons
        /// </summary>
        /// <returns>Retorna el nombre del control del radiobutton</returns>
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
