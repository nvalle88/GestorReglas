using GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;


namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    public class EvaluadorPreposicion
    {
        private readonly Match _match;

        public EvaluadorPreposicion(Match match)
        {
            _match = match;
        }

        public (List<FiltroExpresion>, string) ValidarCadena()
        {
            var proposiciones = new List<FiltroExpresion>();
            if (!_match.Success)
                return (proposiciones, string.Empty);

            proposiciones.Add(new FiltroExpresion(_match.Groups[1].ToString(), Convert.ToDouble(_match.Groups[2].ToString())));

            if (!_match.Groups[4].Success)
                return (proposiciones, string.Empty);

            proposiciones.Add(new FiltroExpresion(_match.Groups[5].ToString(), Convert.ToDouble(_match.Groups[6].ToString())));
            return (proposiciones, _match.Groups[4].ToString());
        }
    }
}
