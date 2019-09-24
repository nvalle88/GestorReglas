using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace GestorReglaContratoCobertura.Extensores
{
    public static class Extensor
    {
        public static Type VarString = typeof(string);
        public static Type VarInt16 = typeof(short);
        public static Type VarInt32 = typeof(int);
        public static Type VarInt64 = typeof(long);
        public static Type VarBool = typeof(bool);

        public static bool ValidarPrimitivo(this Type type)
            => type == VarString || type == VarInt16 || type == VarInt32 || type == VarInt64 || type == VarBool;

        public static bool IsNotNull2(this object obj)
            => obj != null;

        public static bool IsNotNullOrEmpty2(this string obj)
            => obj == null ? false : obj != string.Empty;

        public static bool IsNotNullOrEmpty2<T>(this ICollection<T> obj)
            => obj == null ? false : obj.Count > 0;

        public static bool IsNull2(this object obj)
            => obj == null;

        public static bool IsNullOrEmpty2(this string obj)
            => obj == null || obj == string.Empty;

        public static bool IsNullOrEmpty2<T>(this ICollection<T> obj)
            => obj == null || obj.Count == 0;

        public static T Clonar<T>(this T source)
        {
            if (ReferenceEquals(source, null))
                return default;

            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
        }

        public static bool Contains(this IEnumerable<string> obj, string valor, StringComparison comparador)
            => obj.Any(o => o.Contains(valor, comparador));

        public static bool Contains(this string obj, string valor, StringComparison comparador)
            => obj.IndexOf(valor, comparador) >= 0;
    }
}
