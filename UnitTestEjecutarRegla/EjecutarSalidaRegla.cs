using System;
using System.Linq;
using GestorReglaContratoCobertura;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using GestorReglaContratoCobertura.Regla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestGestorReglas;

namespace UnitTestEjecutarRegla
{
    [TestClass]
    public class EjecutarSalidaRegla
    {
        [TestMethod]
        public void TestMethod1()
        {
            var listaContratos = DatosPruebaContrato.ContratoIND();
            var listaReglas = DatosPruebaRegla.ReglaCambioNombrePosicionPreIND();

            // Act

            var contrato = listaContratos.FirstOrDefault();
            var fechaInicioAux = contrato.GetType().GetProperty("FechaInicio").ToString();
            var re = listaContratos.FirstOrDefault();

            EjecutarSalida.Inicio(contrato, new System.Collections.Generic.List<SalidaGenerica>()
            {
                new SalidaGenerica
                {
                    NombrePropiedad ="Region",
                    Valor="Costa",
                },
                new SalidaGenerica
                {
                    NombrePropiedad ="Version",
                    Valor="1000000",
                },
                new SalidaGenerica
                {
                    NombrePropiedad ="DeducibleTotal",
                    Valor="55.23",
                },
                new SalidaGenerica
                {
                    NombrePropiedad ="FechaInicio",
                    Valor="20/20/2019",
                },
                new SalidaGenerica
                {
                    NombrePropiedad ="EsDeducibleAnual",
                    Valor="true",
                }
            });

            // Assert
            Assert.AreEqual("Costa", contrato.GetType().GetProperty("Region").ToString());
            Assert.AreEqual(1000000, contrato.GetType().GetProperty("Version").ToString());
            Assert.AreEqual(55.23, contrato.GetType().GetProperty("DeducibleTotal").ToString());
            if (contrato.GetType().GetProperty("FechaInicio").ToString() != fechaInicioAux)
            {
                Assert.AreEqual("10/09/2019 00:00:00", contrato.GetType().GetProperty("FechaInicio").ToString());
            }

            Assert.AreEqual(true, contrato.GetType().GetProperty("EsDeducibleAnual").ToString());
        }
    }
}
