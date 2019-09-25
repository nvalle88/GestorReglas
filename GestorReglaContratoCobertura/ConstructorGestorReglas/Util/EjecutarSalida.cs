using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Regla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Util
{
    public static class EjecutarSalida
    {
        public static void Inicio(object objeto, List<SalidaGenerica> salida)
        {
            if (objeto == null || salida == null)
            {
                throw new ArgumentNullException(nameof(objeto));
            }

            var propiedades = objeto.GetType().GetProperties();
            foreach (var propiedad in propiedades)
            {
                var s = salida.FirstOrDefault(x => x.NombrePropiedad == propiedad.Name);
                if (s.IsNotNull2())
                {
                    try
                    {
                        propiedad.SetValue(objeto, Convert.ChangeType
                                      (
                                      propiedad.PropertyType.EsString()
                                      ? Utilidades.ProcesarTexto
                                      (
                                          s.Valor, objeto.GetType().GetProperty(propiedad.Name).GetValue(objeto, null).ToString(), s.Posicion)
                                      : s.Valor, propiedad.PropertyType), null);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }
    }

}

