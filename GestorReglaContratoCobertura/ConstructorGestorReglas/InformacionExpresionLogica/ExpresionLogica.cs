using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    public class ExpresionLogica
    {
        public bool EsExpresionLogica { get; }
        public List<FiltroExpresion> Proposiciones { get; }
        public string OperadorLogico { get; }

        public ExpresionLogica(string cadena)
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
