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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Se ejecuta cuando el formulario se desea cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "¡Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Se ejecuta el metodo limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Se inicia el proceso de cierre del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// Borra los datos de los Textbox, Combobox y Label
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "0";
        }

        /// <summary>
        /// Realiza la operacion entre dos numeros
        /// </summary>
        /// <param name="numero1"> Primer operando</param>
        /// <param name="numero2"> Segundo numero</param>
        /// <param name="operador"> Operacion a realizar</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        private static double Operar(string numero1,string numero2,string operador)
        {
            double resultado = 0;

            //Instancio los dos numeros recibidos
            Operando primerOperando = new Operando(numero1);
            Operando segundoOperando = new Operando(numero2);

            //Realizo el calculo y lo retorno
            resultado = Calculadora.Operar(primerOperando, segundoOperando, Convert.ToChar(operador));

            return resultado;
        }

        /// <summary>
        /// Se inicia el proceso de realizar el calculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = 0;

            string operadorAuxiliar = this.cmbOperador.Text;

            //Verifico de que se ingreso algun numero
            if (!(txtNumero1.Text == "") && !(txtNumero2.Text == ""))
            {
                //Verifico de que se ingreso algun operador
                if (operadorAuxiliar == "")
                {
                    operadorAuxiliar = "+";
                }

                resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, operadorAuxiliar);

                //Si el resultado me devulve la constante double.MinValue, se trato de dividir por 0
                if(resultado != double.MinValue)
                {
                    this.lblResultado.Text = resultado.ToString();
                    this.lstOperaciones.Items.Add($"{this.txtNumero1.Text} {operadorAuxiliar} {this.txtNumero2.Text} = {resultado}");
                }
                else
                {
                    MessageBox.Show("¡No se puede dividir por 0!", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Asegurese de ingresar algun numero en los campos","¡Atencion!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Se convierte el resultado del label a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numeroAuxiliar = new Operando();

            if(this.lblResultado.Text != "Valor Invalido")
            {
                string retorno = numeroAuxiliar.DecimalBinario(this.lblResultado.Text);
                this.lblResultado.Text = retorno;
            }
            else
            {
                MessageBox.Show("No hay un resultado para convertirlo a binario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se convierte el resultado del label a decimal, si es binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numeroAuxiliar = new Operando();

            if (this.lblResultado.Text != "Valor Invalido")
            {
                string retorno = numeroAuxiliar.BinarioDecimal(this.lblResultado.Text);
                this.lblResultado.Text = retorno;
            }
            else
            {
                MessageBox.Show("No hay un resultado para convertirlo a binario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
