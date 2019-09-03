using GestorReglas.Modelos;
using GestorReglas.Modelos.Regla.Salida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        private static T DatosValor<T>(object valor)
        {

            return (T)valor;
           
        }


        public Logica()
        {

            var salida = new Salida();
            salida.ListaSalidas = new List<SalidaGenerica> {
                new SalidaGenerica {NombrePadre="Ejemplo" ,NombrePropiedad = "Nombre", Valor = "55", Condicion = "50" },
                new SalidaGenerica { NombrePropiedad = "Tamano", Valor = "20", Condicion = "A002" } };

            var gestor = new GestorReglas.LogicaNegocio.Gestor();
            var tipod = gestor.L.GetType();
            foreach (var item in gestor.L)
            {

                var tipo = item.GetType();
                var PropertyInfos = item.GetType().GetProperties();

                foreach (var p in PropertyInfos)
                {
                    var s = salida.ListaSalidas.FirstOrDefault(x => x.NombrePropiedad == p.Name && x.NombrePadre == tipo.Name);
                    if (s != null)
                    {


                        PropertyInfo propertyInfo = item.GetType().GetProperty(p.Name);
                        var valor = propertyInfo.GetValue(item, null);
                        if (DatosValor< item.GetType().GetProperty(p.Name). > (valor) == s.Condicion)
                        {

                        }
                        propertyInfo.SetValue(item, Convert.ChangeType(s.Valor, propertyInfo.PropertyType), null);
                    }
                }
            }
        }
    }

    /// // IEnumerable<FieldInfo> fields = typeof(Ejemplo).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

    //// string name = (string)fields.Single(f => f.Name.Equals(salida.NombrePropiedad)).GetValue(item);
    // var valor = fields.FirstOrDefault(f => f.Name.Equals("Valor")).GetValue(item,);
    // Console.WriteLine("\nGetValue: " + propiedad.GetValue(item, null));


    //foreach (var p in PropertyInfos)
    //{
    //    Type type = p.GetType();


    //    if (p.Name == salida.NombrePropiedad)
    //    {
    //        TestClass t = new TestClass();

    //        // Get the type and PropertyInfo.
    //        Type myType = t.GetType();
    //        PropertyInfo pinfo = myType.GetProperty("Caption");

    //        // Display the property value, using the GetValue method.
    //        Console.WriteLine("\nGetValue: " + pinfo.GetValue(t, null));

    //        // Use the SetValue method to change the caption.
    //        pinfo.SetValue(t, "This caption has been changed.", null);

    //        //  Display the caption again.
    //        Console.WriteLine("GetValue: " + pinfo.GetValue(t, null));

    //        Console.WriteLine("\nPress the Enter key to continue.");
    //        Console.ReadLine();
    //        var d=  p.GetValue(type,null);
    //    }
    //}
}
