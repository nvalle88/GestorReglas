﻿using GestorReglaContratoCobertura.ConstructorGestorReglas.Director;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor
{
    public class GestorReglaConstructorBeneficioPlan : IGestorReglaConstructorBeneficioPlan
    {
        private BeneficiosPlan _beneficioPlan;

        public GestorReglaConstructorBeneficioPlan(BeneficiosPlan beneficioPlan)
        {
            _beneficioPlan = beneficioPlan;
        }

        public void AplicarRegla(List<SalidaGenerica> salida)
        {
            AplicarReglaSalisa.Buscar(_beneficioPlan, salida);
        }

        public void IncorporarBeneficioPlan(BeneficiosPlan beneficiosPlan)
        {
            LimpiarBeneficioPlan();
            _beneficioPlan = beneficiosPlan;
        }

        private void LimpiarBeneficioPlan() => _beneficioPlan = new BeneficiosPlan();
    }

}
