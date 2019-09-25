using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Director
{
    public class GestorReglaDirectorContrato
    {
        private readonly IGestorReglaContructorContrato _gestorReglaConstructorContrato;

        public GestorReglaDirectorContrato(IGestorReglaContructorContrato gestorReglaContructorContrato)
        {
            _gestorReglaConstructorContrato = gestorReglaContructorContrato;
        }
    }
}