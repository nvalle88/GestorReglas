using GestorReglaContratoCobertura.ConstructorGestorReglas.Util;
using GestorReglaContratoCobertura.Extensores;
using GestorReglaContratoCobertura.Modelos.Regla;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Director
{
    public static class AplicarReglaSalisa
    {
        public static void Buscar(object objeto, List<SalidaGenerica> salida)
        {
            if (salida.IsNullOrEmpty())
                return;
            var propiedades = objeto.GetType().GetProperties().Where(x => salida.Select(y => y.NombrePropiedad).Contains(x.Name));
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
