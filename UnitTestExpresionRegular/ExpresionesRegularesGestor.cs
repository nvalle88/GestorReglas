using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;

namespace UnitTestExpresionRegular
{
    [TestClass]
    public class ExpresionesRegularesGestorComodin
    {
        [TestMethod]
        public void EliminarComodinInicio()
        {
            var texto = "*200";
            var textoModificado = ExpresionRegular.EliminarComodin(texto);
            Assert.AreEqual("200", textoModificado);
        }

        [TestMethod]
        public void EliminarComodinFinal()
        {
            var texto = "200*";
            var textoModificado = ExpresionRegular.EliminarComodin(texto);
            Assert.AreEqual("200", textoModificado);
        }

        [TestMethod]
        public void EliminarComodinExtremos()
        {
            var texto = "*200*";
            var textoModificado = ExpresionRegular.EliminarComodin(texto);
            Assert.AreEqual("200", textoModificado);
        }

        [TestMethod]
        public void EliminarComodinIntermedio()
        {
            var texto = "2*0*0";
            var textoModificado = ExpresionRegular.EliminarComodin(texto);
            Assert.AreEqual("200", textoModificado);
        }

        [TestMethod]
        public void EliminarComodinTodoLugar()
        {
            var texto = "**2**0**0**";
            var textoModificado = ExpresionRegular.EliminarComodin(texto);
            Assert.AreEqual("200", textoModificado);
        }
    }

    [TestClass]
    public class ExpresionRegularGestorEspacio
    {
        [TestMethod]
        public void EliminarEspacioInicio()
        {
            var texto = " 200";
            var textoModificado = ExpresionRegular.EliminarEspacio(texto);
            Assert.AreEqual("200", textoModificado);
        }

        [TestMethod]
        public void EliminarEspacioFinal()
        {
            var texto = "200 ";
            var textoModificado = ExpresionRegular.EliminarEspacio(texto);
            Assert.AreEqual("200", textoModificado);
        }

        [TestMethod]
        public void EliminarEspacioExtremos()
        {
            var texto = " 200 ";
            var textoModificado = ExpresionRegular.EliminarEspacio(texto);
            Assert.AreEqual("200", textoModificado);
        }

        [TestMethod]
        public void EliminarEspacioIntermedio()
        {
            var texto = "2 0 0";
            var textoModificado = ExpresionRegular.EliminarEspacio(texto);
            Assert.AreEqual("200", textoModificado);
        }

        [TestMethod]
        public void EliminarEspacioTodoLugar()
        {
            var texto = "   2  0  0   ";
            var textoModificado = ExpresionRegular.EliminarEspacio(texto);
            Assert.AreEqual("200", textoModificado);
        }
    }

    [TestClass]
    public class ExpresionLogica
    {
        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionSimple_Mayor()
        {
            var cadena = ">20";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionSimple_MayorIgual()
        {
            var cadena = ">=20";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionSimple_Menor()
        {
            var cadena = "<20";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionSimple_MenorIgual()
        {
            var cadena = "<=20";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionSimple_Igual()
        {
            var cadena = "=20";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionSimple_Diferente()
        {
            var cadena = "!=20";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionCompuesta_Mayor_AND_Menor()
        {
            var cadena = ">20&&<40";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionCompuesta_MayorIgual_AND_MenorIgual()
        {
            var cadena = ">=20&&<=40";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionCompuesta_Menor_AND_Mayor()
        {
            var cadena = "<20&&>40";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionCompuesta_MenorIgual_AND_MayorIgual()
        {
            var cadena = "<=20&&>=40";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionCompuesta_Mayor_OR_Menor()
        {
            var cadena = ">20||<40";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionCompuesta_MayorIgual_OR_MenorIgual()
        {
            var cadena = ">=20||<=40";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionCompuesta_Menor_OR_Mayor()
        {
            var cadena = "<20||>40";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Correcta_ProposisionCompuesta_MenorIgual_OR_MayorIgual()
        {
            var cadena = "<=20||>=40";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }

        [TestMethod]
        public void ValidaExpresionLogica_Test()
        {
            var cadena = "<=20||>=40";
            var resultado = ExpresionRegular.ValidarExpresionLogica(cadena);
            Assert.IsTrue(resultado.Success);
        }
    }
}
