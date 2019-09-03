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
        public Logica()
        {
            var salida = new SalidaGenerica { NombrePropiedad = "Nombre", Valor = "55",TipoDato="string" };

            var salidaCasa = new SalidaGenerica { NombrePropiedad = "Tamano", Valor = "20" , TipoDato="int" };

            var gestor = new GestorReglas.LogicaNegocio.Gestor();

            foreach (var item in gestor.L)
            {

                var tipo = item.GetType();
                var PropertyInfos = item.GetType().GetProperties();
                var propiedad= PropertyInfos.Where(x => x.Name == salida.NombrePropiedad).FirstOrDefault();

                if (propiedad != null)
                {

                    propiedad.SetValue(item, "This caption has been changed.", null);
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
