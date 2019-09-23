using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Modelos.Regla;
using Saludsa.UtilidadesRest;

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
            if (salida.Carencia.IsNotNull())
                _gestorReglaConstructorBeneficiario.AplicarReglaCarencia(salida.Carencia);
        }
    }
}