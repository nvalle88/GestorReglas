using GestorReglaContratoCobertura.ConstructorGestorReglas.Director;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor
{
    public class GestorReglaConstructorContrato : IGestorReglaContructorContrato
    {
        private Contrato _contrato;

        public GestorReglaConstructorContrato(Contrato contrato)
        {
            _contrato = contrato;
        }

        public void AplicarRegla(List<SalidaGenerica> salida)
        {
            AplicarReglaSalisa.Buscar(_contrato, salida);
        }

        public void IncorporarContrato(Contrato contrato)
        {
            LimpiarContrato();
            _contrato = contrato;
        }

        private void LimpiarContrato() => _contrato = new Contrato();
    }

}
