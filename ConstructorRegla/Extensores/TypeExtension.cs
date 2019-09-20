using System;

namespace ConstructorRegla.Extensores
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
    }
}
