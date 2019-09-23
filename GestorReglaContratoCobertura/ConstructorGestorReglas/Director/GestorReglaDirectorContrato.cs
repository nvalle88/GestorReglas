using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Modelos.Regla;
using Saludsa.UtilidadesRest;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Director
{
    public class GestorReglaDirectorContrato
    {
        private readonly IGestorReglaContructorContrato _gestorReglaConstructorContrato;

        public GestorReglaDirectorContrato(IGestorReglaContructorContrato gestorReglaContructorContrato)
        {
            _gestorReglaConstructorContrato = gestorReglaContructorContrato;
        }

        public void ConstruirContratoConReglas(Salida salida)
        {
            if (salida.NombrePlan.IsNotNull())
                _gestorReglaConstructorContrato.AplicarReglaCambioNombrePlan(salida.NombrePlan);

            if (salida.ObservacionesContrato.IsNotNull())
                _gestorReglaConstructorContrato.AplicarReglaCambioObservacionesContrato(salida.ObservacionesContrato);
        }
    }
}