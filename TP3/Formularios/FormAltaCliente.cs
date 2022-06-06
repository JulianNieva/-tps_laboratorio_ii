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
    public partial class FormAltaCliente : Form
    {
        RedSignal redSignal;
        Cliente cliente;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FormAltaCliente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que recibe la red
        /// </summary>
        /// <param name="red"></param>
        public FormAltaCliente(RedSignal red)
            :this()
        {
            redSignal = red;
        }

        /// <summary>
        /// Se carga el combobox con los datos del enumerado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAltaCliente_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(ELocalidad)))
            {
                this.cmbLocalidad.Items.Add(item);
            }
            this.cmbLocalidad.SelectedIndex = 0;
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
        /// Se agregara un cliente siempre y cuando los datos sean validos y no exista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (RevisarCampos())
                {
                    this.cliente = new Cliente(this.txtNombre.Text, this.txtApellido.Text, this.txtDni.Text, (ELocalidad)this.cmbLocalidad.SelectedItem);

                    AgregarServiciosSeleccionados();

                    if (this.redSignal != cliente)
                    {
                        this.redSignal.ListaDeClientes.Add(cliente);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        throw new ClienteException("Ya se encuentra cargado este cliente!");
                    }
                }
                else
                {
                    throw new ClienteException("Asegurese de completar los datos como corresponden");
                }
            }
            catch (ClienteException exc)
            {
                FormPrincipal.MostrarError(exc);
            } 
        }

        /// <summary>
        /// Verifico los campos del form
        /// </summary>
        /// <returns></returns>
        private bool RevisarCampos()
        {
            bool retorno = false;

            if (VerficiarNombre() && VerificarApellido() && VerificarDni() && this.chlstListaDeServicios.CheckedItems.Count != 0)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Verifico el nombre ingresado
        /// </summary>
        /// <returns></returns>
        private bool VerficiarNombre()
        {
            bool esValido = true;

            if(!string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                foreach (char caracter in this.txtNombre.Text)
                {
                    if (char.IsDigit(caracter))
                    {
                        esValido = false;
                        break;
                    }
                }
            }

            return esValido;
        }

        /// <summary>
        /// Verifico el apellido ingresado
        /// </summary>
        /// <returns></returns>
        private bool VerificarApellido()
        {
            bool esValido = true;

            if (!string.IsNullOrWhiteSpace(this.txtApellido.Text))
            {
                foreach (char caracter in this.txtApellido.Text)
                {
                    if (char.IsDigit(caracter))
                    {
                        esValido = false;
                        break;
                    }
                }
            }

            return esValido;
        }

        /// <summary>
        /// Verifico el DNI ingresado
        /// </summary>
        /// <returns></returns>
        private bool VerificarDni()
        {
            bool esValido = false;

            if(this.txtDni.TextLength == 8)
            {
                esValido = true;

                foreach (char letra in this.txtDni.Text)
                {
                    if (char.IsLetter(letra))
                    {
                        esValido = false;
                        break;
                    }
                }
            }

            return esValido;
        }

        /// <summary>
        /// Reviso los servicios seleccionados y los agrego al cliente
        /// </summary>
        private void AgregarServiciosSeleccionados()
        {
            foreach (string item in this.chlstListaDeServicios.CheckedItems)
            {
                switch (item)
                {
                    case "Internet":
                        this.cliente += FormPrincipal.internet;
                        break;
                    case "Television":
                        this.cliente+= FormPrincipal.television;
                        break;
                    default:
                        this.cliente += FormPrincipal.telefono;
                        break;
                }

            }
        }
    }
}
