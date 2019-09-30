using GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExpresionRegular
{
    [TestClass]
    public class ExpresionesLogicas
    {
        [TestMethod]
        public void ValidarExpresionMayorQue()
        {
            var expresion = ">20";
            var expresionLogica = new ExpresionLogica(expresion);

            Assert.IsTrue(expresionLogica.EsExpresionLogica);
            Assert.IsTrue(expresionLogica.Proposiciones.Count == 1);
            Assert.IsTrue(expresionLogica.Proposiciones[0].Operador == Operador.Mayor);
            //Assert.IsTrue(expresionLogica.Proposiciones[0].Valor.Equals((object)20));
        }
    }
}
