﻿using GestorReglaContratoCobertura.ConstructorGestorReglas.Director;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Contrato;
using Saludsa.GestorReglaContratoCobertura.Regla;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor
{
    internal class GestorReglaConstructorBeneficiario : IGestorReglaConstructorBeneficiario
    {
        private Beneficiario _beneficiario;

        public GestorReglaConstructorBeneficiario(Beneficiario beneficiario)
        {
            _beneficiario = beneficiario;
        }

        public void AplicarRegla(List<SalidaGenerica> salida)
        {
            if (salida.IsNull())
                return;
            AplicarReglaSalisa.Buscar(_beneficiario, salida);
        }

        public void IncorporarBeneficiario(Beneficiario beneficiario)
        {
            LimpiarBeneficiario();
            _beneficiario = beneficiario;
        }

        private void LimpiarBeneficiario() => _beneficiario = new Beneficiario();
    }
}