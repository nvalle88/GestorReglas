using GestorReglas.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorReglas.Modelos
{
   public class Ejemplo
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public Casa CasasPrincipal { get; set; }
        public List<Casa> Casas{ get; set; }
    }
}
