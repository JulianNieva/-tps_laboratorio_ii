using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Entidades.Excepciones;

namespace TestUnitarios
{

    [TestClass]
    public class RedSignalTest
    {
        RedSignal red = new RedSignal();

        Reclamo r1 = new Reclamo(new Cliente("Roberto", "Hernandez", "44555666", ELocalidad.BuenosAires), new LineaTelefonica(180),Reclamo.GenerarCodigoAlfanumerico());
        Reclamo r2 = new Reclamo(new Cliente("Presti", "Francis", "44555666", ELocalidad.EntreRios), new Internet(426),Reclamo.GenerarCodigoAlfanumerico());


        [TestMethod]
        public void Comparacion_CuandoRecibeUnReclamosYaCargadoEnLaListaDeReclamos_DebeRetornarTrue()
        {
            red.ListaDeReclamos.Add(r1);
            red.ListaDeReclamos.Add(r2);

            bool retorno = red == r1;

            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Comparacion_CuandoRecibeUnReclamosQueNoEstaCargadoEnLaListaDeReclamos_DebeRetornarFalse()
        {
            red.ListaDeReclamos.Add(r2);

            bool retorno = red == r1;

            Assert.IsFalse(retorno);
        }

    }
}
