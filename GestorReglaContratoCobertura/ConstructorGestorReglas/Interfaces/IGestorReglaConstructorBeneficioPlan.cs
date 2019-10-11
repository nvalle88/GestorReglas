using GestorReglaContratoCobertura.Modelos.Contrato;
using Saludsa.GestorReglaContratoCobertura.Regla;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces
{
    internal interface IGestorReglaConstructorBeneficioPlan
    {
        void AplicarRegla(List<SalidaGenerica> beneficio);

        void IncorporarBeneficioPlan(BeneficiosPlan beneficiosPlan);
    }
}