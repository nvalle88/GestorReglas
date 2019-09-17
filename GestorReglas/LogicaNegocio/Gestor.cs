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
            Lista.Add(new Ejemplo {Nombre="Ejemplo 1",Valor="10" ,Casas= new List<Casa> { new Casa {Color="Verde",Tamano=21},new Casa {Color="Rojo",Tamano=55} },CasasPrincipal= new Casa {Tamano=21,Color="Verde" } });
        }

        public Gestor(object objeto)
        {
            Lista.Add(objeto);
        }

        public List<object> Lista { get; set; } = new List<object>();
    }
}
