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
        readonly Internet internet;
        readonly Television television;
        readonly LineaTelefonica telefono;

        public FormAltaCliente()
        {
            InitializeComponent();
        }

        public FormAltaCliente(RedSignal red)
            :this()
        {
            redSignal = red;
            internet = new Internet(350);
            television = new Television(200);
            telefono = new LineaTelefonica(150);
        }

        private void FormAltaModificacionCliente_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(ELocalidad)))
            {
                this.cmbLocalidad.Items.Add(item);
            }
            this.cmbLocalidad.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

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
                MostrarError(exc);
            } 
        }

        private bool RevisarCampos()
        {
            bool retorno = false;

            if (VerficiarNombre() && VerificarApellido() && VerificarDni() && this.chlstListaDeServicios.CheckedItems.Count != 0)
            {
                retorno = true;
            }

            return retorno;
        }

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

        private void AgregarServiciosSeleccionados()
        {
            foreach (string item in this.chlstListaDeServicios.CheckedItems)
            {
                switch (item)
                {
                    case "Internet":
                        this.cliente.ServiciosContratados.Add(internet);
                        break;
                    case "Television":
                        this.cliente.ServiciosContratados.Add(television);
                        break;
                    default:
                        this.cliente.ServiciosContratados.Add(telefono);
                        break;
                }

            }
        }

        private void MostrarError(Exception exc)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ERROR");
            sb.AppendLine($"{exc.Message}");

            MessageBox.Show(sb.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
