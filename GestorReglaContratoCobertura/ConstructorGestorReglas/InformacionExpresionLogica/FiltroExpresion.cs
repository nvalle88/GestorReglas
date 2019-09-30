namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    public class FiltroExpresion
    {
        public string NombrePropiedad { get; set; }
        public object Valor { get; set; }
        public Operador Operador { get; set; }

        public FiltroExpresion()
        {
        }

        public FiltroExpresion(string operador, object valor)
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
