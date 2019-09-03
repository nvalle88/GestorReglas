using GestorReglas.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorReglas.LogicaNegocio
{
    public class Gestor
    {
        public Gestor()
        {
            L.Add(new Ejemplo());
            L.Add(new Casa());
        }

        public List<object> L { get; set; } = new List<object>();
    }
}
