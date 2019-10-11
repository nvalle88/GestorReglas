using GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Director
{
    internal class GestorReglaDirectorContrato
    {
        private readonly IGestorReglaContructorContrato _gestorReglaConstructorContrato;

        internal GestorReglaDirectorContrato(IGestorReglaContructorContrato gestorReglaContructorContrato)
        {
            _gestorReglaConstructorContrato = gestorReglaContructorContrato;
        }
    }
}