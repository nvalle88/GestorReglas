using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Director
{
    public class GestorReglaDirectorBeneficiario
    {
        private readonly IGestorReglaConstructorBeneficiario _gestorReglaConstructorBeneficiario;

        public GestorReglaDirectorBeneficiario(IGestorReglaConstructorBeneficiario gestorReglaConstructorBeneficiario)
        {
            _gestorReglaConstructorBeneficiario = gestorReglaConstructorBeneficiario;
        }
    }
}