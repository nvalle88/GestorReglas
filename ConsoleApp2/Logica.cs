using GestorReglas.Modelos.Regla.Salida;
using System.Linq;

namespace ConsoleApp2
{
    public class Logica
    {
        public class TestClass
        {
            private string caption = "A Default caption";
            public string Caption
            {
                get { return caption; }
                set
                {
                    if (caption != value)
                    {
                        caption = value;
                    }
                }
            }
        }
        public Logica()
        {
            var salida = new SalidaGenerica { NombrePropiedad = "Nombre", Valor = "55", TipoDato = "string" };
            var salidaCasa = new SalidaGenerica { NombrePropiedad = "Tamano", Valor = "20", TipoDato = "int" };



            var gestor = new GestorReglas.LogicaNegocio.Gestor();

            foreach (var item in gestor.L)
            {

                var tipo = item.GetType();
                var PropertyInfos = item.GetType().GetProperties();
                var propiedad = PropertyInfos.FirstOrDefault(x => x.Name == salida.NombrePropiedad);

                if (propiedad != null)
                {

                    propiedad.SetValue(item, "This caption has been changed.", null);
                }
            }
        }
    }
}
