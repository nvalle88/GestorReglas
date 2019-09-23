using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    public class ExpresionLogica
    {
        public bool EsExpresionLogica { get; }
        public bool EsPredicadoSimple { get; }
        public Proposicion Proposicion1 { get; }
        public string OperadorLogico { get; }
        public Proposicion Proposicion2 { get; }

        public ExpresionLogica(string cadena)
        {
            cadena = ExpresionRegular.EliminarEspacio(cadena);
            var match = ExpresionRegular.ValidarExpresionLogica(cadena); // valida si expresion como >=20 | (>20 && <40)

            EsExpresionLogica = match.Success;

            if (EsExpresionLogica)
            {
                var evaluador = new EvaluadorPreposicion(match);
                (EsPredicadoSimple, Proposicion1, OperadorLogico, Proposicion2) = evaluador.ValidarCadena();
            }
        }
    }
}
