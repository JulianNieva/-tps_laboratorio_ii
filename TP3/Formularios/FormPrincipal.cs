using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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

        /// <summary>
        /// Constructor estatico
        /// </summary>
        static FormPrincipal()
        {
            internet = new Internet(350);
            television = new Television(200);
            telefono = new LineaTelefonica(150);
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FormPrincipal()
        {
            redSignal = new RedSignal();
            opcionSeleccionada = true;
            InitializeComponent();
        }

        /// <summary>
        /// Importo los archivos hardcodeados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Xml<List<Cliente>> listadoClientes = new Xml<List<Cliente>>();
            Xml<List<Reclamo>> listadoReclamos = new Xml<List<Reclamo>>();

            List<Cliente> listaDeClientesAux;
            List<Reclamo> listaDeReclamosAux;
            
            try
            {
                listadoClientes.ImportarArchivo(Environment.CurrentDirectory+@"\ImportarXml\InicializarClientes.xml",out listaDeClientesAux);
                listadoReclamos.ImportarArchivo(Environment.CurrentDirectory + @"\ImportarXml\InicializarReclamos.xml", out listaDeReclamosAux);

                redSignal.ListaDeClientes = listaDeClientesAux;
                redSignal.ListaDeReclamos = listaDeReclamosAux;
            }
            catch (Exception exc)
            {
                MostrarError(exc);
            }

            RefrescarLista(opcionSeleccionada);

            DesactivarLabels();
        }

        /// <summary>
        /// Refresco la lista segun la opcion
        /// </summary>
        /// <param name="opcion">si es true, se asignara la lista de clientes, false la lista de reclamos</param>
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
            DesactivarLabels();
        }

        /// <summary>
        /// Se muestra el listado de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            this.opcionSeleccionada = true;
            RefrescarLista(opcionSeleccionada);
            this.btnAgregar.Text = "Agregar Cliente";
            this.btnEliminar.Text = "Eliminar Cliente";
            DesactivarLabels();
        }

        /// <summary>
        /// Se muestra el lista de reclamos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarReclamos_Click(object sender, EventArgs e)
        {
            this.opcionSeleccionada = false;
            RefrescarLista(opcionSeleccionada);
            this.btnAgregar.Text = "Agregar Reclamo";
            this.btnEliminar.Text = "Eliminar Reclamo";
            DesactivarLabels();
        }

        /// <summary>
        /// Cuando hace click en el boton, se agrega el objeto segun la opcion elegida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Se agrega un cliente a la lista
        /// </summary>
        private void AgregarCliente()
        {
            FormAltaCliente alta = new FormAltaCliente(redSignal);

            alta.ShowDialog();

            if (alta.DialogResult == DialogResult.OK)
            {
                RefrescarLista(true);
            }
        }

        /// <summary>
        /// Se agrega un reclamo a la lista
        /// </summary>
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

        /// <summary>
        /// Cuando hace click en el boton, se elimina el objeto segun el item de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Se eliimina un reclamo
        /// </summary>
        private void EliminarReclamo()
        {
            Reclamo reclamo = this.lstListado.SelectedItem as Reclamo;

            if (MessageBox.Show($"{Reclamo.MostrarReclamo(reclamo)}","¿Se respondio este reclamo?",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                redSignal.ListaDeReclamos.Remove(reclamo);
                RefrescarLista(false);
            }
        }

        /// <summary>
        /// Se elimina un cliente, y consigo, los reclamos que le correponden
        /// </summary>
        private void EliminarCliente()
        {
            Cliente cliente = this.lstListado.SelectedItem as Cliente;

            if (MessageBox.Show($"{Cliente.MostrarCliente(cliente)}", "¿Estas seguro que desea eliminar este cliente?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                redSignal.ListaDeClientes.Remove(cliente);
                EliminarReclamosDeClienteEliminado(cliente);

                RefrescarLista(true);
            }
            
        }
        
        /// <summary>
        /// Se eliminan los reclamos del cliente recibido
        /// </summary>
        /// <param name="c"></param>
        private void EliminarReclamosDeClienteEliminado(Cliente c)
        {
            for (int i = redSignal.ListaDeReclamos.Count-1; i >= 0; i--)
            {
                if(c == redSignal.ListaDeReclamos[i].Cliente)
                {
                    redSignal.ListaDeReclamos.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Cuando se selecciona un elemento de la lista, mostrara su datos mediante los labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Muestra los datos del reclamo seleccionado
        /// </summary>
        private void MostrarDatosReclamo()
        {
            ActivarLabels();
            lblServicios.Visible = false;

            reclamo = lstListado.SelectedItem as Reclamo;

            lblNombreYApellido.Text = $"Codigo: {reclamo.Codigo}";
            lblDni.Text = $"Cliente: {reclamo.Cliente.Nombre} {reclamo.Cliente.Apellido}";
            lblLocalidad.Text = $"Servicio reclamado: {reclamo.ServicioReclamado.Mostrar()}"; 
        }

        /// <summary>
        /// Muestra los datos del cliente seleccionado
        /// </summary>
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

        /// <summary>
        /// Se desactivan los labels
        /// </summary>
        private void DesactivarLabels()
        {
            this.lblDni.Visible = false;
            this.lblLocalidad.Visible = false;
            this.lblNombreYApellido.Visible = false;
            this.lblServicios.Visible = false;
        }

        /// <summary>
        /// Se activan los labels
        /// </summary>
        private void ActivarLabels()
        {
            this.lblDni.Visible = true;
            this.lblLocalidad.Visible = true;
            this.lblNombreYApellido.Visible = true;
            this.lblServicios.Visible = true;
        }

        /// <summary>
        /// Muestro mediante un messagebox la excepcion recibida
        /// </summary>
        /// <param name="exc"></param>
        public static void MostrarError(Exception exc)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ERROR");
            sb.AppendLine($"{exc.Message}");

            MessageBox.Show(sb.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Se guarda en un archivo los listados 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarInformes_Click(object sender, EventArgs e)
        {
            if(redSignal.ListaDeClientes.Count != 0 && redSignal.ListaDeReclamos.Count != 0)
            {
                Xml<List<Cliente>> listadoClientes = new Xml<List<Cliente>>();
                Xml<List<Reclamo>> listadoReclamos = new Xml<List<Reclamo>>();

                try
                {
                    if(listadoClientes.ExportarArchivo("Listado De Clientes", redSignal.ListaDeClientes) && listadoReclamos.ExportarArchivo("Listado De Reclamos", redSignal.ListaDeReclamos))
                    {
                        MessageBox.Show($"Se guardaron los listados con exito!\n{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}","Exito!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                catch (Exception exc)
                {
                    MostrarError(exc);
                }
            }
            else
            {
                MessageBox.Show("Asegurese de tener los dos listados con un cliente/reclamo","Alerta!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }


        }

        /// <summary>
        /// Se ceustiona al usuario si desea cerrar la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Estas seguro que desea salir?","¡Atencion!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
