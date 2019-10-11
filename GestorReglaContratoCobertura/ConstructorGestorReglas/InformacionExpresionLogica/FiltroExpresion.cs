namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    internal class FiltroExpresion
    {
        internal string NombrePropiedad { get; set; }
        internal object Valor { get; set; }
        internal Operador Operador { get; set; }

        internal FiltroExpresion()
        {
        }

        internal FiltroExpresion(string operador, object valor)
        {
            switch (operador)
            {
                case OperadoresRelacionales.Mayor:
                    Operador = Operador.Mayor;
                    break;

                case OperadoresRelacionales.MayorIgual:
                    Operador = Operador.MayorIgual;
                    break;

                case OperadoresRelacionales.Menor:
                    Operador = Operador.Menor;
                    break;

                case OperadoresRelacionales.MenorIgual:
                    Operador = Operador.MenorIgual;
                    break;

                case OperadoresRelacionales.Igual:
                    Operador = Operador.Igual;
                    break;

                case OperadoresRelacionales.Diferente:
                    Operador = Operador.Diferente;
                    break;
            }
            Valor = valor;
        }
    }
}