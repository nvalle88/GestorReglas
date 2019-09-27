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

            objeto.GetType().GetProperties()
                .Where(p => salida.Select(s => s.NombrePropiedad).Contains(p.Name))
                .ToList()
                .ForEach(p =>
                {
                    var s = salida.FirstOrDefault(x => x.NombrePropiedad == p.Name);
                    if (s.IsNotNull())
                    {
                        try
                        {
                            p.SetValue(objeto, Convert.ChangeType
                                (p.PropertyType.EsString()
                                    ? Utilidades.ProcesarTexto(s.Valor, objeto.GetType().GetProperty(p.Name).GetValue(objeto, null).ToString(), s.Posicion)
                                    : s.Valor, p.PropertyType), null);
                        }
                        catch (Exception)
                        {
                        }
                    }
                });
        }
    }
}
