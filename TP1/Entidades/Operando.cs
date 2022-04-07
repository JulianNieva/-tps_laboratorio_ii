using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero; 

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Operando()   :this(0)
        {
        }

        /// <summary>
        /// Constructor del operando
        /// </summary>
        /// <param name="numero">Numero a asignar</param>
        public Operando(double numero)  :this(numero.ToString())
        {
        }

        /// <summary>
        /// Constructor del operando
        /// </summary>
        /// <param name="strNumero">String del numero a asignar</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Setter del numero con su validacion
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Valida el numero recibido
        /// </summary>
        /// <param name="strNumero">Numero a validar</param>
        /// <returns>Retorna 0 si es un numero invalido, caso contrario retorna el mismo numero</returns>
        private double ValidarOperando(string strNumero)
        {
            double retorno;

            if(!double.TryParse(strNumero, out retorno))
            {
                retorno = 0;
            }

            return retorno;
        }

        /// <summary>
        /// Convierte de binario a decimal
        /// </summary>
        /// <param name="binario">Cadena a convertir</param>
        /// <returns>Retorna el decimal convertido, caso contario, valor invalido</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor Invalido";

            if(this.EsBinario(binario))
            {
                retorno = Convert.ToInt32(binario, 2).ToString();
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna el valor binario, caso contario, valor invalido</returns>
        public string DecimalBinario(double numero)
        {
            string retorno = "Valor Invalido";
            int auxiliar;

            //Lo convierto a entero para quedarme con su parte absoluta
            auxiliar = Convert.ToInt32(numero);

            //Verifico de que no sea un numero negativo
            if (auxiliar > -1)
            {
                retorno = Convert.ToString(auxiliar, 2);
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero">Cadena a convertir</param>
        /// <returns>Retorna el valor binario, caso contario, valor invalido</returns>
        public string DecimalBinario(string numero)
        {
            //Llamo a su sobrecarga
            return this.DecimalBinario(Convert.ToDouble(numero));
        }

        /// <summary>
        /// Valido si la cadena es binario
        /// </summary>
        /// <param name="binario">Cadena a validar</param>
        /// <returns>Retorna true si es binario, false caso contrario</returns>
        private bool EsBinario(string binario)
        {
            bool esBinario = true;

            foreach (var caracter in binario)
            {
                if(caracter != '1' && caracter != '0')
                {
                    esBinario = false;
                    break;
                }
            }

            return esBinario;
        }

        /// <summary>
        /// Suma entre dos operandos
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Retorna el resultado de la suma</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta entre dos operandos
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Retorna el resultado de la resta</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Multiplicacion entre dos operandos
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Retorna el resultado de la multiplicacion</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Division entre dos operandos
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Retorna el resultado de la division, en caso de didivir por 0, double.MinValue</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado = double.MinValue;

            if(n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }

    }
}
