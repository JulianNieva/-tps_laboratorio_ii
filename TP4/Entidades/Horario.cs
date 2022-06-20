using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Horario
    {
        int hora;
        int segundo;
        int minuto;

        public delegate void MostrarHorario(Horario hora);
        public event MostrarHorario cambioDeSegundo;

        /// <summary>
        /// Se inicia un hilo secundario, en donde cada vez que el segundo cambie
        /// se lanza el evento cambioDeSegundo
        /// </summary>
        public void InicializarHorario()
        {
           Task.Run(() =>
           {
               while (true)
               {
                   DateTime tiempo = DateTime.Now;

                   if(tiempo.Second != segundo)
                   {
                       if(cambioDeSegundo is not null)
                       {
                           cambioDeSegundo.Invoke(this);
                       }
                   }

                   hora = tiempo.Hour;
                   segundo = tiempo.Second;
                   minuto = tiempo.Minute;
               }
           });
        }

        /// <summary>
        /// Devuelvo la hora exacta
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Hora Minutos Segundos\n{hora,-5}:  {minuto}  : {segundo,2}";
        }

    }
}
