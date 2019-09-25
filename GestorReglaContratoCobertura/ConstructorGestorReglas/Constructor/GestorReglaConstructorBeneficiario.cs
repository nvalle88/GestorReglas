using GestorReglaContratoCobertura.ConstructorGestorReglas.Director;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor
{
    public class GestorReglaConstructorBeneficiario : IGestorReglaConstructorBeneficiario
    {
        private Beneficiario _beneficiario;

        public GestorReglaConstructorBeneficiario(Beneficiario beneficiario)
        {
            _beneficiario = beneficiario;
        }

        public void AplicarRegla(List<SalidaGenerica> salida)
        {
            BuscarConReflexion.Buscar(_beneficiario, salida);
        }

        public void IncorporarBeneficiario(Beneficiario beneficiario)
        {
            LimpiarBeneficiario();
            _beneficiario = beneficiario;
        }

        private void LimpiarBeneficiario() => _beneficiario = new Beneficiario();

    }

}
