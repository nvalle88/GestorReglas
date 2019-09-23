using GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado;
using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    public class ExpresionLogica
    {
        public bool EsExpresionLogica { get; }
        public List<ExpressionFilter> Proposiciones { get; }
        public string OperadorLogico { get; }

        public ExpresionLogica(string cadena)
        {
            Proposiciones = new List<ExpressionFilter>();
            cadena = ExpresionRegular.EliminarEspacio(cadena);
            var match = ExpresionRegular.ValidarExpresionLogica(cadena); // valida si expresion como >=20 | (>20 && <40)

            EsExpresionLogica = match.Success;

            if (EsExpresionLogica)
            {
                var evaluador = new EvaluadorPreposicion(match);
                (Proposiciones, OperadorLogico) = evaluador.ValidarCadena();
            }
        }
    }
}
