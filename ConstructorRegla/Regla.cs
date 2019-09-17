namespace ConstructorRegla
{
    public class Regla
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Entrada Entrada { get; set; }
        public Salida Salida { get; set; }
    }

    public class Entrada
    {
        public string Producto { get; set; }
        public string Plan { get; set; }
        public string Nivel { get; set; }
        public int Convenio { get; set; }
    }

    public class Salida
    {
        public NombrePlan NombrePlan { get; set; }
    }

    public class NombrePlan
    {
        public string Campo { get; set; }
        public string Texto { get; set; }
    }
}
