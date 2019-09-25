using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Director
{
    public class GestorReglaDirectorBeneficioPlan
    {
        private readonly IGestorReglaConstructorBeneficioPlan _gestorReglaConstructorBeneficioPlan;

        public GestorReglaDirectorBeneficioPlan(IGestorReglaConstructorBeneficioPlan gestorReglaConstructorBeneficioPlan)
        {
            _gestorReglaConstructorBeneficioPlan = gestorReglaConstructorBeneficioPlan;
        }
    }
}