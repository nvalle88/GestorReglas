using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Director
{
    internal class GestorReglaDirectorBeneficiario
    {
        private readonly IGestorReglaConstructorBeneficiario _gestorReglaConstructorBeneficiario;

        internal GestorReglaDirectorBeneficiario(IGestorReglaConstructorBeneficiario gestorReglaConstructorBeneficiario)
        {
            _gestorReglaConstructorBeneficiario = gestorReglaConstructorBeneficiario;
        }
    }
}