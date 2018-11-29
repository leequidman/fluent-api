using System;
using System.Linq;
using System.Reflection;

namespace ObjectPrinting
{
    public static class ObjectExtensions
    {
        public static string PrintToString<T>(this T obj)
        {
            return ObjectPrinter.For<T>().PrintToString(obj);
        }

        public static object GetValue(this MemberInfo memberInfo, object forObject)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).GetValue(forObject);
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).GetValue(forObject);
                default:
                    throw new ArgumentException("Input MemberInfo must be if type FieldInfo, or PropertyInfo");
            }
        }

        public static Type GetUnderlyingType(this MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                default:
                    throw new ArgumentException("Input MemberInfo must be if type FieldInfo, or PropertyInfo");
            }
        }

        public static bool IsNumericType(this Type type)
        {
            return new[]
            {
                typeof(sbyte),
                typeof(short),
                typeof(long),
                typeof(int),
                typeof(byte),
                typeof(int),
                typeof(uint),
                typeof(ulong),
                typeof(float),
                typeof(double),
                typeof(decimal)
            }.Contains(type);
        }
    }
}