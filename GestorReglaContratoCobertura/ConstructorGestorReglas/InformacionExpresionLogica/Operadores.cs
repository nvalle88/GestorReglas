namespace GestorReglaContratoCobertura.ConstructorGestorReglas.InformacionExpresionLogica
{
    public static class OperadoresRelacionales
    {
        public const string Mayor = ">";
        public const string MayorIgual = ">=";
        public const string Menor = "<";
        public const string MenorIgual = "<=";
        public const string Igual = "=";
        public const string Diferente = "!=";
    }

    public static class OperadoresLogicos
    {
        public static string Y => "&&";
        public static string O => "||";
        public static string NO => "!";
    }

    public static class OperadoresAritmeticos
    {
        public static string Suma => "+";
        public static string Resta => "-";
        public static string Multiplicacion => "*";
        public static string Division => "/";
        public static string Producto => "^";
    }
}
