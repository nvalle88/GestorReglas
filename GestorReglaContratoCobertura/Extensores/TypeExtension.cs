using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorReglaContratoCobertura.Extensores
{
    public static class TypeExtension
    {
        public static Type VarString = typeof(string);
        public static Type VarInt16 = typeof(short);
        public static Type VarInt32 = typeof(int);
        public static Type VarInt64 = typeof(long);
        public static Type VarBool = typeof(bool);

        public static bool ValidarPrimitivo(this Type type)
            => type == VarString || type == VarInt16 || type == VarInt32 || type == VarInt64 || type == VarBool;

        public static bool IsNotNull2(this object obj)
        {
            return obj != null;
        }

      
        public static bool IsNotNullOrEmpty2(this string obj)
        {
            return obj !=null || obj !=string.Empty;
        }
       
        public static bool IsNotNullOrEmpty2(this IEnumerable obj)
        {
            ICollection<object> collection = (ICollection<object>)obj;
            var count = collection.Count();
            return obj != null || count >0  ;
        }
       
       
       
        public static string IsNotNullOrEmptyDefault2(this string obj, string valorPreterminado = "")
        {
            return valorPreterminado;
        }
      
        public static bool IsNull2(this object obj)
        {
            return obj == null;
        }
     
        public static bool IsNullOrEmpty2(this string obj)
        {
            return obj==null || obj==string.Empty;
        }
      
        public static bool IsNullOrEmpty2(this IEnumerable obj)
        {
            ICollection<object> collection = (ICollection<object>)obj;
            var count = collection.Count();
            return obj==null || count==0;
        }
    }
}
