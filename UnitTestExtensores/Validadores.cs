using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using GestorReglaContratoCobertura.Regla;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace UnitTestExtensores
{
    [TestClass]
    public class Validadores
    {
        [TestMethod]
        public void ValidarFechas_FechaInicioNull_FechaFinNull()
        {
            var regla = new ReglaContrato
            {
                FechaInicioRegla = null,
                FechaFinRegla = null
            };

            var validacion = Validaciones.ValidarFechaRegla(regla);
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void ValidarFechas_FechaInicioValida_FechaFinNull()
        {
            var regla = new ReglaContrato
            {
                FechaInicioRegla = new DateTime(2019, 09, 20),
                FechaFinRegla = null
            };

            var validacion = Validaciones.ValidarFechaRegla(regla);
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void ValidarFechas_FechaInicioNull_FechaFinValida()
        {
            var regla = new ReglaContrato
            {
                FechaInicioRegla = null,
                FechaFinRegla = new DateTime(2019, 10, 10)
            };

            var validacion = Validaciones.ValidarFechaRegla(regla);
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void ValidarFechas_FechaInicioValida_FechaFinValida()
        {
            var regla = new ReglaContrato
            {
                FechaInicioRegla = new DateTime(2019, 09, 20),
                FechaFinRegla = new DateTime(2019, 10, 10)
            };

            var validacion = Validaciones.ValidarFechaRegla(regla);
            Assert.IsTrue(validacion);
        }

        [TestMethod]
        public void ValidarFechas_FechaInicioValidaFueraDeRango_FechaFinNull()
        {
            var regla = new ReglaContrato
            {
                FechaInicioRegla = new DateTime(2020, 01, 01),
                FechaFinRegla = null
            };

            var validacion = Validaciones.ValidarFechaRegla(regla);
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void ValidarFechas_FechaInicioNull_FechaFinValidaFueraDeRango()
        {
            var regla = new ReglaContrato
            {
                FechaInicioRegla = null,
                FechaFinRegla = new DateTime(2019, 09, 01)
            };

            var validacion = Validaciones.ValidarFechaRegla(regla);
            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void ValidarFechas_FechaInicioValidaFueraDeRango_FechaFinValidaFueraDeRango()
        {
            var regla = new ReglaContrato
            {
                FechaInicioRegla = new DateTime(2019, 08, 01),
                FechaFinRegla = new DateTime(2019, 08, 31)
            };

            var validacion = Validaciones.ValidarFechaRegla(regla);
            Assert.IsFalse(validacion);
        }
    }
}
