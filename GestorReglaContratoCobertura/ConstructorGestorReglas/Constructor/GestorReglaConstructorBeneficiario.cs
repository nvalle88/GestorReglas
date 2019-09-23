using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor
{
    public class GestorReglaConstructorBeneficiario : IGestorReglaConstructorBeneficiario
    {
        private Beneficiario _beneficiario;

        public GestorReglaConstructorBeneficiario(Beneficiario beneficiario)
        {
            _beneficiario = beneficiario;
        }

        public void AplicarReglaCarencia(Carencia carencia)
        {
            _beneficiario.EnCarencia = carencia.EnCarencia;
            _beneficiario.DiasFinCarencia = carencia.DiasFinCarencia;
        }

        public void IncorporarBeneficiario(Beneficiario beneficiario)
        {
            LimpiarBeneficiario();
            _beneficiario = beneficiario;
        }

        private void LimpiarBeneficiario() => _beneficiario = new Beneficiario();

    }

}
