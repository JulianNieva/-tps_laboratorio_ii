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
using Entidades.Serializador;
using Entidades.Excepciones;

namespace Formularios
{
    public partial class FormPrincipal : Form
    {
        public static Internet internet;
        public static LineaTelefonica telefono;
        public static Television television;

        RedSignal redSignal;
        Cliente cliente;
        Reclamo reclamo;
        bool opcionSeleccionada;

        static FormPrincipal()
        {
            internet = new Internet(350);
            television = new Television(200);
            telefono = new LineaTelefonica(150);
        }

        public FormPrincipal()
        {
            redSignal = new RedSignal();
            opcionSeleccionada = true;

            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //Agregar carga de archivos

            LimpiarLabels();
        }

        public void RefrescarLista(bool opcion)
        {
            lstListado.DataSource = null;

            if(opcion)
            {
                lstListado.DataSource = redSignal.ListaDeClientes;
            }
            else
            {
                lstListado.DataSource = redSignal.ListaDeReclamos;
                
            }
            lstListado.SelectedItem = null;
            LimpiarLabels();
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            RefrescarLista(true);
            this.btnAgregar.Text = "Agregar Cliente";
            this.btnEliminar.Text = "Eliminar Cliente";
            this.opcionSeleccionada = true;
            LimpiarLabels();
        }

        private void btnListarReclamos_Click(object sender, EventArgs e)
        {
            RefrescarLista(false);
            this.btnAgregar.Text = "Agregar Reclamo";
            this.btnEliminar.Text = "Eliminar Reclamo";
            this.opcionSeleccionada = false;
            LimpiarLabels();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(opcionSeleccionada)
            {
                AgregarCliente();
            }
            else
            {
                AgregarReclamo();
            }
        }

        private void AgregarCliente()
        {
            FormAltaCliente alta = new FormAltaCliente(redSignal);

            alta.ShowDialog();

            if (alta.DialogResult == DialogResult.OK)
            {
                RefrescarLista(true);
            }
        }

        private void AgregarReclamo()
        {
            try
            {
                if (redSignal.ListaDeClientes.Count > 0)
                {
                    FormAltaReclamos altaReclamo = new FormAltaReclamos(redSignal);

                    altaReclamo.ShowDialog();

                    if (altaReclamo.DialogResult == DialogResult.OK)
                    {
                        RefrescarLista(false);
                    }
                }
                else
                {
                    throw new ReclamoException("Debe existir al menos un cliente para poder realizar un reclamo");
                }
            }
            catch (ReclamoException exc)
            {
                MostrarError(exc);
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(lstListado.SelectedItem is not null)
                {
                    if(lstListado.SelectedItem is Cliente)
                    {
                        EliminarCliente();
                    }
                    else
                    {
                        EliminarReclamo();
                    }
                }
                else
                {
                    throw new Exception("Asegure de seleccionar el elemento a eliminar");
                }
            }
            catch (Exception exc)
            {
                MostrarError(exc);
            }

        }

        private void EliminarReclamo()
        {
            Reclamo reclamo = this.lstListado.SelectedItem as Reclamo;

            if (MessageBox.Show($"{Reclamo.MostrarReclamo(reclamo)}","¿Se respondio este reclamo?",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                redSignal.ListaDeReclamos.Remove(reclamo);
                RefrescarLista(false);
            }
        }

        private void EliminarCliente()
        {
            Cliente cliente = this.lstListado.SelectedItem as Cliente;

            if (MessageBox.Show($"{Cliente.MostrarCliente(cliente)}", "¿Estas seguro que desea eliminar este cliente?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                redSignal.ListaDeClientes.Remove(cliente);
                /*foreach (Reclamo item in redSignal.ListaDeReclamos)
                {
                    if(cliente == item.Cliente)
                    {
                        redSignal.ListaDeReclamos.Remove(item);
                    }
                }*/

                RefrescarLista(true);
            }
            
        }

        private void lstListado_SelectedValueChanged(object sender, EventArgs e)
        {
            if(this.lstListado.SelectedItem is Cliente)
            {
                MostrarDatosCliente();
            }
            else if(this.lstListado.SelectedItem is Reclamo)
            {
                MostrarDatosReclamo();
            }
            
        }

        private void MostrarDatosReclamo()
        {
            ActivarLabels();
            lblServicios.Visible = false;

            reclamo = lstListado.SelectedItem as Reclamo;

            lblNombreYApellido.Text = $"Codigo: {reclamo.Codigo}";
            lblDni.Text = $"Cliente: {reclamo.Cliente.Nombre} {reclamo.Cliente.Apellido}";
            lblLocalidad.Text = $"Servicio reclamado: {reclamo.ServicioReclamado.Mostrar()}"; 
        }

        private void MostrarDatosCliente()
        {
            StringBuilder sb = new StringBuilder();
            ActivarLabels();

            cliente = lstListado.SelectedItem as Cliente;

            lblDni.Text = $"Dni: {cliente.Dni}";
            lblLocalidad.Text = $"Localidad: {cliente.Localidad}";
            lblNombreYApellido.Text = $"Cliente: {cliente.Nombre} {cliente.Apellido}";

            foreach (Servicio item in cliente.ServiciosContratados)
            {
                sb.AppendLine($"* {item.Mostrar()}");
            }
            lblServicios.Text = $"Servicios contratados: \n{sb.ToString()}";
        }

        private void LimpiarLabels()
        {
            this.lblDni.Visible = false;
            this.lblLocalidad.Visible = false;
            this.lblNombreYApellido.Visible = false;
            this.lblServicios.Visible = false;
        }

        private void ActivarLabels()
        {
            this.lblDni.Visible = true;
            this.lblLocalidad.Visible = true;
            this.lblNombreYApellido.Visible = true;
            this.lblServicios.Visible = true;
        }

        public static void MostrarError(Exception exc)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ERROR");
            sb.AppendLine($"{exc.Message}");

            MessageBox.Show(sb.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
