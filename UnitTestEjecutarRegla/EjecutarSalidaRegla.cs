using System;
using System.Linq;
using GestorReglaContratoCobertura;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using GestorReglaContratoCobertura.Modelos.Regla;
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
            var fechaInicioAux = contrato.FechaInicio.ToString();
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
            Assert.AreEqual("Costa", contrato.Region);
            Assert.AreEqual(1000000, contrato.Version);
            Assert.AreEqual(55.23, contrato.DeducibleTotal);
            if (contrato.FechaInicio.ToString()!= fechaInicioAux)
            {
                Assert.AreEqual("10/09/2019 00:00:00", contrato.FechaInicio.ToString());
            }
            
            Assert.AreEqual(true, contrato.EsDeducibleAnual);
        }
    }
}
