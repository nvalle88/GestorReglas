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

        private static T DatosValor<T>(T valor)
        {

            return (T)valor;

        }

        public List<string> ObtenerClass(object entity)
        {
            List<string> lista = new List<string>();

            Type type = entity.GetType();
            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                string atributo = "";
                object test = item.GetValue(entity, null);

                if (test != null)
                {
                    if (test.GetType().IsPrimitive || test is string || test is DateTime || test is decimal)
                    {
                        //atributo.tipo = test;
                        lista.Add(atributo);
                    }
                    else
                    {
                        lista.AddRange(ObtenerClass(test));
                    }
                }
            }

            return lista;
        }

        public object Inicio(object objeto, List<SalidaGenerica> listaSalidas)
        {
            if (objeto == null || listaSalidas == null)
            {
                throw new ArgumentNullException(nameof(objeto));
            }
            Type type = objeto.GetType();
            var propiedades = objeto.GetType().GetProperties();
            foreach (var item in propiedades)
            {
                if (!item.PropertyType.IsPrimitive)
                {
                    if (item.PropertyType.Name.Contains("List"))
                    {
                        object test3 = item.GetValue(objeto, null);

                        var lista = RecorrerLista((List<object>)test3, listaSalidas);
                    }
                    object test = item.GetValue(objeto, null);
                    RecorrerObjeto(test, listaSalidas);
                }
                object test1 = item.GetValue(objeto, null);
                var propertyInfos = item.GetType().GetProperties();

                foreach (var property in propertyInfos)
                {

                    var salida = listaSalidas.FirstOrDefault(x => x.NombrePropiedad == property.Name && x.NombrePadre == item.GetType().Name);
                    if (salida != null)
                    {
                        PropertyInfo propertyInfo = item.GetType().GetProperty(property.Name);
                        propertyInfo.SetValue(item, Convert.ChangeType(salida.Valor, propertyInfo.PropertyType), null);
                    }

                }
            }

            return objeto;
        }


        public List<object> RecorrerLista(List<object> list, List<SalidaGenerica> listaSalidas)
        {
            foreach (var item in list)
            {
                var PropertyInfos = item.GetType().GetProperties();
                foreach (var p in PropertyInfos)
                {
                    if (!p.GetType().IsPrimitive)
                    {
                        PropertyInfo propertyInfo = item.GetType().GetProperty(p.Name);
                        if (propertyInfo.PropertyType.Name.Contains("List"))
                        {
                            var valor = propertyInfo.GetValue(item, null);
                            propertyInfo.SetValue(valor, Convert.ChangeType(s.Valor, propertyInfo.PropertyType), null);
                            var lista = RecorrerLista(valor, listaSalidas);
                        }
                       
                    }

                    var s = listaSalidas.FirstOrDefault(x => x.NombrePropiedad == p.Name && x.NombrePadre == item.GetType().Name);
                    if (s != null)
                    {
                        PropertyInfo propertyInfo = item.GetType().GetProperty(p.Name);
                        var valor = propertyInfo.GetValue(item, null);
                        propertyInfo.SetValue(item, Convert.ChangeType(s.Valor, propertyInfo.PropertyType), null);
                    }
                }
            }
            return list;
        }


        public object RecorrerObjeto(object objeto, List<SalidaGenerica> listaSalidas)
        {
            var PropertyInfos = objeto.GetType().GetProperties();
            foreach (var p in PropertyInfos)
            {
                var s = listaSalidas.FirstOrDefault(x => x.NombrePropiedad == p.Name && x.NombrePadre == objeto.GetType().Name);
                if (s != null)
                {
                    PropertyInfo propertyInfo = objeto.GetType().GetProperty(p.Name);
                    var valor = propertyInfo.GetValue(objeto, null);
                    propertyInfo.SetValue(objeto, Convert.ChangeType(s.Valor, propertyInfo.PropertyType), null);
                }
            }
            return objeto;
        }

        public Logica()
        {

            var salida = new Salida();
            salida.ListaSalidas = new List<SalidaGenerica> {
                new SalidaGenerica {NombrePadre="Ejemplo" ,NombrePropiedad = "Nombre", Valor = "55", Condicion = "Ejemplo 1" },
                new SalidaGenerica {NombrePadre="Casa" , NombrePropiedad = "Tamano", Valor = "20", Condicion = "21" } };

            var gestor = new GestorReglas.LogicaNegocio.Gestor();
            var tipod = gestor.Lista.GetType();

            var salidaR = Inicio(gestor, salida.ListaSalidas);
            //var salidsa2 = ObtenerClass(gestor);
            foreach (var item in gestor.Lista)
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
                        var d = Convert.ChangeType(valor, propertyInfo.PropertyType);
                        var e = Convert.ChangeType(s.Condicion, propertyInfo.PropertyType);
                        if (d.ToString() == e.ToString())
                        {
                            propertyInfo.SetValue(item, Convert.ChangeType(s.Valor, propertyInfo.PropertyType), null);
                        }

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
