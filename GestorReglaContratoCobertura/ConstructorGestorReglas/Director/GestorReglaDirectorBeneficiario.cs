using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Regla;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Director
{
    public class GestorReglaDirectorBeneficiario
    {
        private readonly IGestorReglaConstructorBeneficiario _gestorReglaConstructorBeneficiario;

        public GestorReglaDirectorBeneficiario(IGestorReglaConstructorBeneficiario gestorReglaConstructorBeneficiario)
        {
            _gestorReglaConstructorBeneficiario = gestorReglaConstructorBeneficiario;
        }

        public void ConstruirBeneficiarioConReglas(Salida salida)
        {
            if (salida.Carencia.IsNotNull2())
                _gestorReglaConstructorBeneficiario.AplicarReglaCarencia(salida.Carencia);
        }
    }
}