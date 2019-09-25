using GestorReglaContratoCobertura.Modelos.Contrato;
using GestorReglaContratoCobertura.Modelos.Regla;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces
{
    public interface IGestorReglaContructorContrato
    {
        void AplicarRegla(List<SalidaGenerica> salida);
        void IncorporarContrato(Contrato contrato);
    }
}
