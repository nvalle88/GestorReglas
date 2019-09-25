using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces
{
    public interface IGestorReglaConstructorBeneficioPlan
    {
        void AplicarRegla(List<SalidaGenerica> beneficio);
        void IncorporarBeneficioPlan(BeneficiosPlan beneficiosPlan);
    }
}
