using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces
{
    public interface IGestorReglaContructorContrato
    {
        void AplicarReglaCambioNombrePlan(NombrePlan nombrePlan);
        void AplicarReglaCambioObservacionesContrato(ObservacionesContrato observacionesContrato);
        void IncorporarContrato(Contrato contrato);
    }
}
