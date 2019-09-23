using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Modelos.Regla;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Director
{
    public class GestorReglaDirectorBeneficioPlan
    {
        private readonly IGestorReglaConstructorBeneficioPlan _gestorReglaConstructorBeneficioPlan;

        public GestorReglaDirectorBeneficioPlan(IGestorReglaConstructorBeneficioPlan gestorReglaConstructorBeneficioPlan)
        {
            _gestorReglaConstructorBeneficioPlan = gestorReglaConstructorBeneficioPlan;
        }

        public void ConstruirBeneficioPlanConReglas(SalidaBeneficioPlan salida)
        {
            _gestorReglaConstructorBeneficioPlan.AplicarReglaCodigoBeneficioPlan(salida);
        }
    }
}