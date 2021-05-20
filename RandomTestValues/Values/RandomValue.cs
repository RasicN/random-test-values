using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Linq;
using RandomTestValues.Formats;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        private static Dictionary<Type, Func<Type, object>> SupportedTypes =>
            new Dictionary<Type, Func<Type, object>>
            {
                {typeof(int), type => Int()},
                {typeof(string), type => String()},
                {typeof(decimal), type => Decimal()},
                {typeof(double), type => Double()},
                {typeof(bool), type => Bool()},
                {typeof(byte), type => Byte()},
                {typeof(char), type => Char()},
                {typeof(float), type => Float()},
                {typeof(long), type => Long()},
                {typeof(sbyte), type => SByte()},
                {typeof(short), type => Short()},
                {typeof(uint), type => UInt()},
                {typeof(ulong), type => ULong()},
                {typeof(ushort), type => UShort()},
                {typeof(Guid), type => Guid()},
                {typeof(DateTime), type => DateTime()},
                {typeof(TimeSpan), type => TimeSpan() },
                {typeof(DateTimeOffset), type => DateTimeOffset() },
                {typeof(Uri), type => Uri() }
            };

        private static readonly Random _Random = new Random();

        private static object GetMethodCallAssociatedWithType(Type propertyType, RandomValueSettings settings)
        {
            var supportType = GetSupportType(propertyType);

            switch (supportType)
            {
                case SupportType.Basic:
                    return SupportedTypes[propertyType].Invoke(propertyType);
                case SupportType.Enum:
                    return EnumMethodCall(propertyType);
                case SupportType.Collection:
                {
                    var collectionType = GetSupportedCollectionType(propertyType);
                    return GetListMethodOfCollections(propertyType, collectionType.First(), settings);
                }
                case SupportType.Nullable:
                    return NullableMethodCall(propertyType, settings);
                case SupportType.UserDefined:
                    return ObjectMethodCall(propertyType, settings);
                default:
                    return null;
            }
        }

        private static object NullableMethodCall(Type propertyType, RandomValueSettings settings)
        {
            if(settings.IncludeNullAsPossibleValueForNullables && Bool())
            {
                return null;
            }

            var baseType = Nullable.GetUnderlyingType(propertyType);
            return GetMethodCallAssociatedWithType(baseType, settings);
        }

        private static bool IsNullableType(Type propertyType)
        {
            return propertyType.GetTypeInfo().IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static int CreateRandomLengthIfOptionLengthIsNull(int? optionalLength)
        {
            return optionalLength ?? _Random.Next(1, 10);
        }

        private static object GetListMethodOfCollections(Type propertyType, Type genericType, RandomValueSettings settings)
        {
            var typeOfList = genericType;

            object listMethod = null;

            Type type = propertyType;

            if (propertyType.IsArray)
            {
                listMethod = ArrayMethodCall(propertyType.GetElementType(), settings);
            }
            else if (type.GetTypeInfo().IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)))
            {
                listMethod = ListMethodCall(typeOfList, settings);
            }
            else if (type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                listMethod = IListMethodCall(typeOfList, settings);
            }
            else if (type.GetTypeInfo().IsGenericType && (type.GetGenericTypeDefinition() == typeof(Collection<>)))
            {
                listMethod = CollectionMethodCall(typeOfList, settings);
            }
            else if (type.GetGenericTypeDefinition() == typeof(ICollection<>))
            {
                listMethod = ICollectionMethodCall(typeOfList, settings);
            }
            else if (type.GetTypeInfo().IsGenericType && (type.GetGenericTypeDefinition() == typeof(Dictionary<,>)))
            {
                listMethod = DictionaryMethodCall(type.GenericTypeArguments, settings);
            }
            else if (type.GetGenericTypeDefinition() == typeof(IDictionary<,>))
            {
                listMethod = IDictionaryMethodCall(type.GenericTypeArguments, settings);
            }
            else if (type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                listMethod = IEnumerableMethodCall(typeOfList, settings);
            }

            return listMethod;
        }

        private static bool IsSupportedCollection(Type propertyType)
        {
            var hasImplementedICollection = propertyType.GetTypeInfo().ImplementedInterfaces.Any(x => x.Name == "ICollection");

            return hasImplementedICollection
                   || (propertyType.GetTypeInfo().IsGenericType &&
                       (propertyType.IsArray
                       || propertyType.GetGenericTypeDefinition() == typeof(ICollection<>)
                       || propertyType.GetGenericTypeDefinition() == typeof(IList<>)
                       || propertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                       || propertyType.GetGenericTypeDefinition() == typeof(IDictionary<,>)
                       ));
        }

        private static object ObjectMethodCall(Type type, RandomValueSettings settings)
        {
            return typeof(RandomValue).GetRuntimeMethods()
                .First(x => x.Name == "Object" && x.GetParameters()?[0]?.ParameterType == typeof(RandomValueSettings))
                .MakeGenericMethod(type)
                .Invoke(null, new object[] { settings });
        }

        private static object EnumMethodCall(Type type)
        {
            return GetMethod("Enum")
                .MakeGenericMethod(type)
                .Invoke(null, new object[] { });
        }

        private static object IEnumerableMethodCall(Type type, RandomValueSettings settings)
        {
            return GetMethod("IEnumerable")
                .MakeGenericMethod(type)
                .Invoke(null, new object[] { settings });
        }

        private static object ArrayMethodCall(Type typeOfList, RandomValueSettings settings)
        {
            return InvokeCollectionMethod("Array", typeOfList, settings);
        }

        private static object ListMethodCall(Type typeOfList, RandomValueSettings settings)
        {
            return InvokeCollectionMethod("List", typeOfList, settings);
        }

        private static object IListMethodCall(Type typeOfList, RandomValueSettings settings)
        {
            return InvokeCollectionMethod("IList", typeOfList, settings);
        }

        private static object CollectionMethodCall(Type typeOfList, RandomValueSettings settings)
        { 
            return InvokeCollectionMethod("Collection", typeOfList, settings);
        }

        private static object ICollectionMethodCall(Type typeOfList, RandomValueSettings settings)
        {
            return InvokeCollectionMethod("ICollection", typeOfList, settings);
        }

        private static object DictionaryMethodCall(Type[] genericTypeArguments, RandomValueSettings settings)
        {
            var method = GetMethod("Dictionary");

            return method
                 .MakeGenericMethod(genericTypeArguments[0], genericTypeArguments[1])
                 .Invoke(null, new object[] { settings });
        }

        private static object IDictionaryMethodCall(Type[] genericTypeArguments, RandomValueSettings settings)
        {
            var method = GetMethod("IDictionary");

            return method
                 .MakeGenericMethod(genericTypeArguments[0], genericTypeArguments[1])
                 .Invoke(null, new object[] { settings });
        }

        private static object InvokeCollectionMethod(string nameOfMethod, Type type, RandomValueSettings settings)
        {
            var method = GetMethod(nameOfMethod);

            return method
                .MakeGenericMethod(type)
                .Invoke(null, new object[] { settings });
        }

        private static MethodInfo GetMethod(string nameOfMethod)
        {
            var possibleMethods = typeof(RandomValue).GetRuntimeMethods().Where(x => x.Name == nameOfMethod);

            if(possibleMethods.Count() > 1)
            {
                return possibleMethods.First(x => x.GetParameters().Length == 1);
            }

            return possibleMethods.First();
        }

        private static SupportType GetSupportType(Type type)
        {
            if (SupportedTypes.ContainsKey(type))
            {
                return SupportType.Basic;
            }
            if (type.GetTypeInfo().IsEnum)
            {
                return SupportType.Enum;
            }
            if (IsSupportedCollection(type))
            {
                return SupportType.Collection;
            }
            if (IsNullableType(type))
            {
                return SupportType.Nullable;
            }
            if (type.GetTypeInfo().IsClass)
            {
                return SupportType.UserDefined;
            }

            return SupportType.NotSupported;
        }

        private static Type[] GetSupportedCollectionType(Type type)
        {
            if (type.IsArray)
            {
                return new Type[]
                {
                    type.GetElementType()
                };
            }
            else
            {
                return type.GetGenericArguments();
            }
        }

        private static Type[] GetGenericArguments(this Type type)
        {
            return type.GetTypeInfo().IsGenericTypeDefinition ? type.GetTypeInfo().GenericTypeParameters : type.GetTypeInfo().GenericTypeArguments;
        }

        private static bool PropertyTypeIsRecursiveOrCircular<T>(PropertyInfo property) where T : new()
        {
            return PropertyTypeIsRecursive<T>(property); // || PropertyTypeIsCircular<T>(property);
        }

        private static bool PropertyTypeIsRecursiveOrCircular(Type type, PropertyInfo property)
        {
            return PropertyTypeIsRecursive(type, property);
        }

        private static bool PropertyTypeIsRecursive<T>(PropertyInfo property) where T : new()
        {
            return PropertyTypeIsRecursive(typeof(T), property);
        }

        private static bool PropertyTypeIsRecursive(Type type, PropertyInfo property)
        {
            var propertyType = property.PropertyType;

            if (propertyType == type)
            {
                return true;
            }
            if (IsSupportedCollection(propertyType))
            {
                var collectionType = GetSupportedCollectionType(propertyType);
                return collectionType.Contains(type);
            }
            if (IsNullableType(propertyType))
            {
                var underlyingType = Nullable.GetUnderlyingType(propertyType);
                return underlyingType == type;
            }

            return false;
        }

        private static bool PropertyHasNoSetter(PropertyInfo prop)
        {
            return prop.SetMethod == null;
        }
    }

    internal enum SupportType
    {
        NotSupported,
        UserDefined,
        Basic,
        Enum,
        Collection,
        Nullable
    }
}
