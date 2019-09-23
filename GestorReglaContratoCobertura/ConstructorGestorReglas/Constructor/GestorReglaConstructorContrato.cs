using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Constructor
{
    public class GestorReglaConstructorContrato : IGestorReglaContructorContrato
    {
        private Contrato _contrato;

        public GestorReglaConstructorContrato(Contrato contrato)
        {
            _contrato = contrato;
        }

        public void AplicarReglaCambioNombrePlan(NombrePlan nombrePlan)
            => _contrato.NombrePlan = Utilidades.ProcesarTexto(nombrePlan.Texto, _contrato.NombrePlan, nombrePlan.Posicion);

        public void AplicarReglaCambioObservacionesContrato(ObservacionesContrato observacionesContrato)
            => _contrato.Observaciones = Utilidades.ProcesarTexto(observacionesContrato.Texto, _contrato.Observaciones, observacionesContrato.Posicion);

        public void IncorporarContrato(Contrato contrato)
        {
            LimpiarContrato();
            _contrato = contrato;
        }

        private void LimpiarContrato() => _contrato = new Contrato();
    }

}
