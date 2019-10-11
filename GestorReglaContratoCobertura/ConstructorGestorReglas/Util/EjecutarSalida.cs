using GestorReglaContratoCobertura.Extensores;
using Saludsa.GestorReglaContratoCobertura.Regla;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Util
{
    internal static class EjecutarSalida
    {
        internal static void Inicio(object objeto, List<SalidaGenerica> salida)
        {
            var propiedades = objeto.GetType().GetProperties();
            foreach (var propiedad in propiedades)
            {
                var s = salida.FirstOrDefault(x => x.NombrePropiedad == propiedad.Name);
                if (s.IsNotNull())
                {
                    try
                    {
                        propiedad.SetValue(objeto, Convert.ChangeType
                                      (
                                      propiedad.PropertyType.EsString()
                                      ? Utilidades.ProcesarTexto
                                      (s.Valor, objeto.GetType().GetProperty(propiedad.Name).GetValue(objeto, null).ToString(), s.Posicion)
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