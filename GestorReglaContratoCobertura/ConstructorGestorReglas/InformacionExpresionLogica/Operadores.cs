namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    internal static class OperadoresRelacionales
    {
        public const string Mayor = ">";
        public const string MayorIgual = ">=";
        public const string Menor = "<";
        public const string MenorIgual = "<=";
        public const string Igual = "=";
        public const string Diferente = "!=";
    }

    internal enum Operador
    {
        Igual,
        Menor,
        MenorIgual,
        Mayor,
        MayorIgual,
        Diferente,
        Contiene, //for strings
        IniciaCon, //for strings
        TerminaCon, //for strings
        IgualQue // for strings
    }
}