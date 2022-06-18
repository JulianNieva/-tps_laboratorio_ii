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
    public partial class FormCliente : Form
    {
        RedSignal redSignal;
        Cliente cliente;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FormCliente(RedSignal red)
        {
            redSignal = red;
            InitializeComponent();
        }

        public FormCliente(RedSignal red,string titulo, string boton,string nombre, string apellido,string dni,ELocalidad localidad,List<Servicio> servicios)
            :this(red)
        {
            this.Text = titulo;
            this.btnAgregar.Text = boton;
            this.txtNombre.Text = nombre;
            this.txtApellido.Text = apellido;
            this.txtDni.Text = dni;
            this.txtDni.Enabled = false;
            this.cmbLocalidad.SelectedItem = localidad;
            foreach (Servicio item in servicios)
            {
                switch (item.ToString())
                {
                    case "Television":
                        this.chlstListaDeServicios.SetItemChecked(2,true);
                        break;
                    case "Internet":
                        this.chlstListaDeServicios.SetItemChecked(0, true);
                        break;
                    case "Linea Telefonica":
                        this.chlstListaDeServicios.SetItemChecked(1, true);
                        break;
                }
            }
        }

        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
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
                    if(this.Text == "Modificar Cliente")
                    {
                        ModificarCliente();
                    }
                    else
                    {
                        AgregarCliente();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();

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

        private void AgregarCliente()
        {
            this.cliente = new Cliente(this.txtNombre.Text, this.txtApellido.Text, this.txtDni.Text, (ELocalidad)this.cmbLocalidad.SelectedItem);

            AgregarServiciosSeleccionados();

            if (this.redSignal == cliente)
            {
                throw new ClienteException("Ya se encuentra cargado este cliente!");
            }
        }
         
        private void ModificarCliente()
        {
            this.cliente = new Cliente(this.txtNombre.Text, this.txtApellido.Text, this.txtDni.Text, (ELocalidad)this.cmbLocalidad.SelectedItem);

            AgregarServiciosSeleccionados();
        }

        /// <summary>
        /// Verifico los campos del form
        /// </summary>
        /// <returns></returns>
        private bool RevisarCampos()
        {
            bool retorno = false;

            if (this.txtNombre.Text.VerificarTexto() && this.txtApellido.Text.VerificarTexto() 
                && this.txtDni.Text.VerificarDni() && this.chlstListaDeServicios.CheckedItems.Count != 0)
            {
                retorno = true;
            }

            return retorno;
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
