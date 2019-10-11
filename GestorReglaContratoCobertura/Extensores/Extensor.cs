using GestorReglaContratoCobertura.Modelos.Contrato;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorReglaContratoCobertura.Extensores
{
    internal static class Extensor
    {
        internal static Type VarString = typeof(string);
        internal static Type VarInt16 = typeof(short);
        internal static Type VarInt32 = typeof(int);
        internal static Type VarInt64 = typeof(long);
        internal static Type VarBool = typeof(bool);

        internal static bool ValidarPrimitivo(this Type type)
            => type == VarString || type == VarInt16 || type == VarInt32 || type == VarInt64 || type == VarBool;

        internal static bool EsString(this Type type)
           => type == VarString;

        internal static bool IsNotNull(this object obj)
            => obj != null;

        internal static bool IsNotNullOrEmpty(this string obj)
            => obj == null ? false : obj != string.Empty;

        internal static bool IsNotNullOrEmpty<T>(this ICollection<T> obj)
            => obj == null ? false : obj.Count > 0;

        internal static bool IsNull(this object obj)
            => obj == null;

        internal static bool IsNullOrEmpty(this string obj)
            => obj == null || obj == string.Empty;

        internal static bool IsNullOrEmpty<T>(this ICollection<T> obj)
            => obj == null || obj.Count == 0;

        internal static T Clonar<T>(this T source)
        {
            if (ReferenceEquals(source, null))
                return default;

            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
        }

        internal static bool Contains(this IEnumerable<string> obj, string valor, StringComparison comparador)
            => obj.Any(o => o.Contains(valor, comparador));

        internal static bool Contains(this string obj, string valor, StringComparison comparador)
            => obj.IndexOf(valor, comparador) >= 0;

        internal static List<T> DeserializarGenerico<T>(this List<Contrato> listaContratos)
            => JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(listaContratos));

        internal static List<T> DeserializarGenerico<T>(this object listaContratos)
            => JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(listaContratos));
    }
}