using ExpresionRegular;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExpresionRegular
{
    [TestClass]
    public class UnitTestExpresionRegular
    {
        #region Expresión lógica
        [TestMethod]
        public void ValidarExpresionLogica_Validar_Correcto()
        {
            // Arrange
            var cadenaEvaluada = "<10";
            // Act
            var resultadoMetodo = ValidadorExpresionRegular.ValidarExpresionLogica(cadenaEvaluada);
            // Assert
            Assert.IsTrue(resultadoMetodo);
        }

        [TestMethod]
        public void ValidarExpresionLogica_Validar_Error_ConLetras()
        {
            // Arrange
            var cadenaEvaluada = "<ABC";
            // Act
            var resultadoMetodo = ValidadorExpresionRegular.ValidarExpresionLogica(cadenaEvaluada);
            // Assert
            Assert.IsFalse(resultadoMetodo);
        }

        [TestMethod]
        public void ValidarExpresionLogica_Validar_Error_ConNumerosYLetras()
        {
            // Arrange
            var cadenaEvaluada = "<654ABC";
            // Act
            var resultadoMetodo = ValidadorExpresionRegular.ValidarExpresionLogica(cadenaEvaluada);
            // Assert
            Assert.IsFalse(resultadoMetodo);
        }

        [TestMethod]
        public void ValidarExpresionLogica_Validar_Error_ConLetrasYNumeros()
        {
            // Arrange
            var cadenaEvaluada = "<ABC654";
            // Act
            var resultadoMetodo = ValidadorExpresionRegular.ValidarExpresionLogica(cadenaEvaluada);
            // Assert
            Assert.IsFalse(resultadoMetodo);
        }

        [TestMethod]
        public void ValidarExpresionLogica_Validar_Error_ConLetrasYNumerosCombinados()
        {
            // Arrange
            var cadenaEvaluada = "<A6B5C4";
            // Act
            var resultadoMetodo = ValidadorExpresionRegular.ValidarExpresionLogica(cadenaEvaluada);
            // Assert
            Assert.IsFalse(resultadoMetodo);
        }
        #endregion Expresión lógica
    }

    [TestClass]
    public class UnitTestExpresionLogica
    {
        [TestMethod]
        public void ValidarComparadorExpresionLogica_Validar_Correcto()
        {
            // Arrange
            var cadenaEvaluada = "<!=";
            // Act
            var resultadoMetodo = ValidadorExpresionRegular.ValidarComparadorExpresionLogica(cadenaEvaluada);
            // Assert
            Assert.IsTrue(resultadoMetodo);
        }
    }
}