using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;
using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Regla;

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
            if (salida.NombrePlan.IsNotNull2())
                _gestorReglaConstructorContrato.AplicarReglaCambioNombrePlan(salida.NombrePlan);

            if (salida.ObservacionesContrato.IsNotNull2())
                _gestorReglaConstructorContrato.AplicarReglaCambioObservacionesContrato(salida.ObservacionesContrato);
        }
    }
}