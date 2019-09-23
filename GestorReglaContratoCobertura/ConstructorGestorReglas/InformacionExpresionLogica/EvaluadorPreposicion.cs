using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using System.Text.RegularExpressions;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    public class EvaluadorPreposicion
    {
        private readonly Match _match;

        public EvaluadorPreposicion(Match match)
        {
            _match = match;
        }

        public (bool, Proposicion, string, Proposicion) ValidarCadena()
        {
            if (!_match.Success)
                return (false, null, string.Empty, null);

            var proposicion1 = new Proposicion(_match.Groups[1].ToString(), _match.Groups[2].ToString());

            if (!_match.Groups[4].Success)
                return (true, proposicion1, string.Empty, null);

            var proposicion2 = new Proposicion(_match.Groups[5].ToString(), _match.Groups[6].ToString());
            return (false, proposicion1, _match.Groups[4].ToString(), proposicion2);
        }
    }
}
