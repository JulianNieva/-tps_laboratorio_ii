using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operacion matematica correspondiente
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>Retorna el resultado de la operacion realziada</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            switch (Calculadora.ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;

            }

            return resultado;
        }

        /// <summary>
        /// Valida el operador recibido
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Retorna el operador que corresponde, si es invalido, retorna +</returns>
        private static char ValidarOperador(char operador)
        {
            char retorno = '+';

            if(operador == '-' || operador == '*' || operador == '/')
            {
                retorno = operador;
            }

            return retorno;
        }

    }
}
