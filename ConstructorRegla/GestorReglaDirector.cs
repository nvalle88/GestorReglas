using System;
using Saludsa.UtilidadesRest;

namespace ConstructorRegla
{
    public class GestorReglaDirector
    {
        private readonly IGestorReglaContructor _gestorReglaConstructor;

        public GestorReglaDirector(IGestorReglaContructor gestorReglaContructor)
        {
            _gestorReglaConstructor = gestorReglaContructor;
        }

        public void ConstruirContratoConReglas(Salida salida)
        {
            if (salida.NombrePlan.IsNotNull())
                _gestorReglaConstructor.AplicarReglaCambioTexto(salida.NombrePlan);
        }
    }
}