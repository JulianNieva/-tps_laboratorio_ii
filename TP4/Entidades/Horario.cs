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

        public override string ToString()
        {
            return $"Hora  Minutos  Segundos\n{hora} - {minuto} - {segundo}";
        }

    }
}
