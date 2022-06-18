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
            try
            {
                RefrescarLista(opcionSeleccionada);
            }
            catch (BaseDeDatosException exc)
            {
                MostrarError(exc);
            }

            DesactivarLabel();
        }

        /// <summary>
        /// Refresco la lista segun la opcion
        /// </summary>
        /// <param name="opcion">si es true, se asignara la lista de clientes, false la lista de reclamos</param>
        public void RefrescarLista(bool opcion)
        {
            dtgListado.DataSource = null;
            redSignal.ListaDeClientes = ClienteDAO.LeerClientes();
            redSignal.ListaDeReclamos = ReclamoDAO.LeerReclamos();

            if (opcion)
            {
                dtgListado.DataSource = redSignal.ListaDeClientes;
            }
            else
            {
                dtgListado.DataSource = redSignal.ListaDeReclamos;    
            }
            dtgListado.Refresh();
            dtgListado.Update();
            dtgListado.ClearSelection();
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
            this.btnModificarCliente.Enabled = true;
            DesactivarLabel();
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
            this.btnModificarCliente.Enabled = false;
            DesactivarLabel();
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
            FormCliente alta = new FormCliente(redSignal);

            alta.ShowDialog();

            if (alta.DialogResult == DialogResult.OK)
            {
                ClienteDAO.GuardarCliente(alta.Cliente);
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
                    FormReclamos altaReclamo = new FormReclamos(redSignal);

                    altaReclamo.ShowDialog();

                    if (altaReclamo.DialogResult == DialogResult.OK)
                    {
                        ReclamoDAO.GuardarReclamo(altaReclamo.Reclamo);
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
                if(dtgListado.SelectedRows.Count > 0)
                {
                    if(dtgListado.CurrentRow.DataBoundItem is Cliente)
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
            Reclamo reclamo = this.dtgListado.CurrentRow.DataBoundItem as Reclamo;

            if (MessageBox.Show($"{Reclamo.MostrarReclamo(reclamo)}","¿Se soluciono este reclamo?",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                ReclamoDAO.EliminarReclamo(reclamo.Codigo);
                RefrescarLista(false);
            }
        }

        /// <summary>
        /// Se elimina un cliente, y consigo, los reclamos que le correponden
        /// </summary>
        private void EliminarCliente()
        {
            Cliente cliente = this.dtgListado.CurrentRow.DataBoundItem as Cliente;

            if (MessageBox.Show($"{Cliente.MostrarCliente(cliente)}", "¿Estas seguro que desea eliminar este cliente?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    EliminarReclamosDeClienteEliminado(cliente);
                    ClienteDAO.BorrarCliente(cliente.Dni);
                    RefrescarLista(true);
                }
                catch (Exception exc)
                {
                    MostrarError(exc);
                }
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
                    ReclamoDAO.EliminarReclamo(redSignal.ListaDeReclamos[i].Codigo);
                }
            }
        }

        /// <summary>
        /// Se desactivan los labels
        /// </summary>
        private void DesactivarLabel()
        {
            this.lblServicios.Visible = false;
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
            bool seExporto = false;

            if(redSignal.ListaDeClientes.Count != 0 && redSignal.ListaDeReclamos.Count != 0)
            {
                try
                {

                    switch (cmbTipoArchivo.Text)
                    {
                        case "TXT":
                            Txt<List<Cliente>> clientesTxt = new Txt<List<Cliente>>();
                            Txt<List<Reclamo>> reclamosTxt = new Txt<List<Reclamo>>();

                            clientesTxt.ExportarArchivo("Listado de Clientes",redSignal.ListaDeClientes);
                            reclamosTxt.ExportarArchivo("Listado de Reclamos", redSignal.ListaDeReclamos);
                            seExporto = true;
                            break;
                        case "XML":
                            Xml<List<Cliente>> clientesXml = new Xml<List<Cliente>>();
                            Xml<List<Reclamo>> reclamosXml = new Xml<List<Reclamo>>();

                            clientesXml.ExportarArchivo("Listado de Clientes", redSignal.ListaDeClientes);
                            reclamosXml.ExportarArchivo("Listado de Reclamos", redSignal.ListaDeReclamos);
                            seExporto = true;
                            break;
                        default:
                            MessageBox.Show("Asegurese de seleccionar alguna opcion deseada!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }

                    if(seExporto)
                    {
                        MessageBox.Show($"Se exporto el archivo con exito!{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (ArchivosException ex)
                {
                    MostrarError(ex);
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

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if(dtgListado.SelectedRows.Count > 0)
                {
                    Cliente clienteAux = ClienteDAO.LeerClientePorDni((dtgListado.CurrentRow.DataBoundItem as Cliente).Dni);

                    FormCliente modificacion = new FormCliente(redSignal,"Modificar Cliente","Modificar",clienteAux.Nombre,clienteAux.Apellido,clienteAux.Dni,clienteAux.Localidad,clienteAux.ServiciosContratados);

                    modificacion.ShowDialog();
                    if(modificacion.DialogResult == DialogResult.OK)
                    {
                        ClienteDAO.ModificarCliente(modificacion.Cliente);
                    }
                }
                else
                {
                    throw new ClienteException("Asegurese de seleccionar el cliente que desea modificar");
                }
            }
            catch (ClienteException exc)
            {
                MostrarError(exc);
            }
        }

        /*private void EliminarReclamosDeClienteModificado(Cliente c)
        {
            foreach (Reclamo item in redSignal.ListaDeReclamos)
            {

            }
        }*/
    }
}
