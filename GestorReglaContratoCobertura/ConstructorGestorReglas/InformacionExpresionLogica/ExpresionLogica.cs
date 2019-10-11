using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    internal class ExpresionLogica
    {
        internal bool EsExpresionLogica { get; }
        internal List<FiltroExpresion> Proposiciones { get; }
        internal string OperadorLogico { get; }

        internal ExpresionLogica(string cadena)
        {
            Proposiciones = new List<FiltroExpresion>();
            cadena = ExpresionRegular.EliminarEspacio(cadena);
            var match = ExpresionRegular.ValidarExpresionLogica(cadena);

            EsExpresionLogica = match.Success;

            if (EsExpresionLogica)
            {
                var evaluador = new EvaluadorPreposicion(match);
                (Proposiciones, OperadorLogico) = evaluador.ValidarCadena();
            }
        }
    }
}