using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Director
{
    internal class GestorReglaDirectorBeneficioPlan
    {
        private readonly IGestorReglaConstructorBeneficioPlan _gestorReglaConstructorBeneficioPlan;

        internal GestorReglaDirectorBeneficioPlan(IGestorReglaConstructorBeneficioPlan gestorReglaConstructorBeneficioPlan)
        {
            _gestorReglaConstructorBeneficioPlan = gestorReglaConstructorBeneficioPlan;
        }
    }
}