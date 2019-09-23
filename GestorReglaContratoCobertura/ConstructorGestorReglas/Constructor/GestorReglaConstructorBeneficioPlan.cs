using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor
{
    public class GestorReglaConstructorBeneficioPlan : IGestorReglaConstructorBeneficioPlan
    {
        private BeneficiosPlan _beneficioPlan;

        public GestorReglaConstructorBeneficioPlan(BeneficiosPlan beneficioPlan)
        {
            _beneficioPlan = beneficioPlan;
        }

        public void AplicarReglaCodigoBeneficioPlan(SalidaBeneficioPlan beneficioPlan)
        {
            _beneficioPlan.Valor = beneficioPlan.Valor;
        }

        public void IncorporarBeneficioPlan(BeneficiosPlan beneficiosPlan)
        {
            LimpiarBeneficioPlan();
            _beneficioPlan = beneficiosPlan;
        }

        private void LimpiarBeneficioPlan() => _beneficioPlan = new BeneficiosPlan();
    }

}
