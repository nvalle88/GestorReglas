using GestorReglaContratoCobertura.Modelos.Contrato;
using Saludsa.GestorReglaContratoCobertura.Regla;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces
{
    internal interface IGestorReglaConstructorBeneficiario
    {
        void AplicarRegla(List<SalidaGenerica> salida);

        void IncorporarBeneficiario(Beneficiario beneficiario);
    }
}