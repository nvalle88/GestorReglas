using GestorReglaContratoCobertura.Modelos.Contrato;
using Saludsa.GestorReglaContratoCobertura.Regla;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Interfaces
{
    internal interface IGestorReglaContructorContrato
    {
        void AplicarRegla(List<SalidaGenerica> salida);

        void IncorporarContrato(Contrato contrato);
    }
}