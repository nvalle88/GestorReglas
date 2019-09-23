using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces
{
    public interface IGestorReglaConstructorBeneficiario
    {
        void AplicarReglaCarencia(Carencia carencia);
        void IncorporarBeneficiario(Beneficiario beneficiario);
    }
}
