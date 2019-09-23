using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces
{
    public interface IGestorReglaConstructorBeneficioPlan
    {
        void AplicarReglaCodigoBeneficioPlan(SalidaBeneficioPlan beneficio);
        void IncorporarBeneficioPlan(BeneficiosPlan beneficiosPlan);
    }
}
