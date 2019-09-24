using System;
using System.Collections.Generic;

namespace GestorReglaContratoCobertura.Modelos.Regla
{
    public class Regla
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EstadoActivo { get; set; }
        public DateTime? FechaInicioRegla { get; set; }
        public DateTime? FechaFinRegla { get; set; }
        public List<int> Convenio { get; set; }
        public List<int> Aplicacion { get; set; }
        public List<int> Plataforma { get; set; }
        public Entrada Entrada { get; set; }
        public Salida Salida { get; set; }
    }
}
