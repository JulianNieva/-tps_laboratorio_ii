using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensionValidaciones
    {
        /// <summary>
        /// Verifico un dni 
        /// </summary>
        /// <param name="dni">Dni a verificar</param>
        /// <returns>Retorno true si esta bien ingresado, false caso contrario</returns>
        public static bool VerificarDni(this string dni)
        {
            bool esValido = false;

            if (dni.Length == 8)
            {
                esValido = true;

                foreach (char letra in dni)
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
        /// Verifico de que el texto recibido no tenga numeros y no este vacio
        /// </summary>
        /// <param name="texto">Texto a verificar</param>
        /// <returns>Retorno true si es valido, false caso contrario</returns>
        public static bool VerificarTexto(this string texto)
        {
            bool esValido = true;

            if (!string.IsNullOrWhiteSpace(texto))
            {
                foreach (char caracter in texto)
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
    }
}
