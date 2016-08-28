using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Linq;

namespace RandomTestValues
{
    public static class RandomValue
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
                {typeof(Guid), type => Guid.NewGuid()},
                {typeof(DateTime), type => DateTime.Now}
            };

        private static readonly Random _Random = new Random();

        /// <summary>
        /// Use for getting a random string for your unit tests.  This is basically a Guid.ToString() so it will
        /// not have any formatting and it will have "-"
        /// </summary>
        /// <returns>A random string the length of a Guid</returns>
        public static string String()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Use for getting a random string of a specific length for your unit tests.
        /// </summary>
        /// <param name="stringLength">Length of desired random string</param>
        /// <returns>A random string the length of a stringLength parameter</returns>
        public static string String(int stringLength)
        {
            var randomString = String();

            while (randomString.Length <= stringLength)
            {
                randomString += String();
            }

            return randomString.Substring(0, stringLength);
        }

        /// <summary>
        /// Use for getting a random Byte for your unit tests.
        /// </summary>
        /// <returns>A random Byte</returns>
        public static byte Byte(byte maxPossibleValue = byte.MaxValue)
        {
            return (byte)Int(maxPossibleValue);
        }

        /// <summary>
        /// Use for getting a random Signed Byte for your unit tests.
        /// </summary>
        /// <returns>A random (positive) Signed Byte</returns>
        public static sbyte SByte(sbyte maxPossibleValue = sbyte.MaxValue)
        {
            return (sbyte)Int(maxPossibleValue);
        }

        /// <summary>
        /// Use for getting a random integer for your unit tests.
        /// </summary>
        /// <returns>A random (positive) integer</returns>
        public static int Int(int maxPossibleValue = int.MaxValue)
        {
            return _Random.Next(Math.Abs(maxPossibleValue));
        }

        /// <summary>
        /// Use for getting a random Unsigned integer for your unit tests.
        /// </summary>
        /// <returns>A random Unsigned integer</returns>
        public static uint UInt(uint maxPossibleValue = uint.MaxValue)
        {
            var buffer = new byte[sizeof(uint)];
            _Random.NextBytes(buffer);

            var generatedUint = BitConverter.ToUInt32(buffer, 0);

            while (generatedUint > maxPossibleValue)
            {
                generatedUint = generatedUint >> 1;
            }

            return generatedUint;
        }

        /// <summary>
        /// Use for getting a random Short for your unit tests.
        /// </summary>
        /// <returns>A random (positive) Short</returns>
        public static short Short(short maxPossibleValue = short.MaxValue)
        {
            return (short)Int(maxPossibleValue);
        }

        /// <summary>
        /// Use for getting a random Unsigned Short for your unit tests.
        /// </summary>
        /// <returns>A random Unsigned Short</returns>
        public static ushort UShort(ushort maxPossibleValue = ushort.MaxValue)
        {
            return (ushort)Int();
        }

        /// <summary>
        /// Use for getting a random Long for your unit tests.
        /// </summary>
        /// <returns>A random (Positive) Long</returns>
        public static long Long(long maxPossibleValue = long.MaxValue)
        {
            return (long)ULong((ulong)maxPossibleValue);
        }

        /// <summary>
        /// Use for getting a random Unsigned Long for your unit tests.
        /// </summary>
        /// <returns>A random Long</returns>
        public static ulong ULong(ulong maxPossibleValue = ulong.MaxValue)
        {
            var buffer = new byte[sizeof(ulong)];

            _Random.NextBytes(buffer);

            var generatedULongs = BitConverter.ToUInt64(buffer, 0);

            while (generatedULongs > maxPossibleValue)
            {
                generatedULongs = generatedULongs >> 1;
            }

            return generatedULongs;
        }

        public static float Float()
        {
            return (float)_Random.NextDouble();
        }

        public static double Double()
        {
            return _Random.NextDouble();
        }

        public static char Char()
        {
            var buffer = new byte[sizeof(char)];

            _Random.NextBytes(buffer);

            return BitConverter.ToChar(buffer, 0);
        }

        public static bool Bool()
        {
            var randomNumber = Int(2);

            if (randomNumber == 0)
            {
                return false;
            }

            return true;
        }

        public static decimal Decimal()
        {
            return (decimal)_Random.NextDouble();
        }

        public static T Object<T>() where T : new()
        {
            var genericObject = (T)Activator.CreateInstance(typeof(T));

            var properties = typeof(T).GetProperties();

            if (properties.Length == 0)
            {
                // Prevent infinite loop when called recursively
                return genericObject;
            }

            foreach (var prop in properties)
            {
                if (SupportedTypes.ContainsKey(prop.PropertyType))
                {
                    prop.SetValue(genericObject, Convert.ChangeType(SupportedTypes[prop.PropertyType].Invoke(prop.PropertyType), prop.PropertyType), null);
                }
                else if (prop.PropertyType.IsEnum)
                {
                    var enumMethod = EnumMethodCall(prop.PropertyType);
                    prop.SetValue(genericObject, enumMethod, null);
                }
                else if (IsSupportedCollection(prop.PropertyType))
                {
                    // WARNING: UGLY CODE AHEAD
                    object listMethod = GetListMethodOfCollections(prop.PropertyType, prop.PropertyType.GetGenericArguments()[0]);

                    if (listMethod != null)
                    {
                        if(prop.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                        {
                            prop.SetValue(genericObject, listMethod, new object[] { });
                        }
                        else
                        {
                            prop.SetValue(genericObject, listMethod, null);
                        }
                    }
                }
                else
                {
                    var method = ObjectMethodCall(prop.PropertyType);

                    prop.SetValue(genericObject, Convert.ChangeType(method, prop.PropertyType), null);
                }
            }

            return genericObject;
        }

        public static T Enum<T>() where T : struct, IConvertible
        {
            var fields = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);

            var index = _Random.Next(fields.Length);

            return (T)System.Enum.Parse(typeof(T), fields[index].Name, false);
        }

        public static List<T> List<T>(int? optionalLength = null)
        {
            return ICollection<T>(optionalLength).ToList();
        }

        public static IList<T> IList<T>(int? optionalLength = null)
        {
            return ICollection<T>(optionalLength).ToList();
        }

        public static Collection<T> Collection<T>(int? optionalLength = null)
        {
            return (Collection<T>)ICollection<T>(optionalLength);
        }

        public static ICollection<T> ICollection<T>(int? optionalLength = null)
        {
            var numberOfItems = optionalLength ?? _Random.Next(1, 10); //Do we care if this is empty or not? I sort of think it would be good if this would be occasionally empty. 

            var enumerable = IEnumerable<T>().Take(numberOfItems);

            var randomList = new Collection<T>(enumerable.ToList());

            return randomList;
        }

        public static IEnumerable<T> IEnumerable<T>()
        {
            var type = typeof(T);

            var supportedType = 
                SupportedTypes.ContainsKey(type) 
                || type.IsEnum 
                || type.IsClass 
                || (IsSupportedCollection(type)); 
            
            while(supportedType)
            {
                if (SupportedTypes.ContainsKey(type))
                {
                    yield return (T)SupportedTypes[type].Invoke(type);
                }
                else if (type.IsEnum)
                {
                    yield return (T)EnumMethodCall(type);
                }
                else if (IsSupportedCollection(type))
                {
                    var genericType = type.GetGenericArguments()[0];
                    var method = GetListMethodOfCollections(type, genericType);
                    yield return (T)method;
                }
                else if (type.IsClass)
                {
                    yield return (T)ObjectMethodCall(type);
                }
            }
        }

        private static object GetListMethodOfCollections(Type propertyType, Type genericType)
        {
            var typeOfList = genericType;

            object listMethod = null;

            Type type = propertyType;
            if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)))
            {
                listMethod =
                typeof(RandomValue).GetMethod("List")
                    .MakeGenericMethod(typeOfList)
                    .Invoke(null, new object[] { null });
            }
            else if (type.GetGenericTypeDefinition() == typeof(IList<>))
            {
                listMethod =
                typeof(RandomValue).GetMethod("IList")
                    .MakeGenericMethod(typeOfList)
                    .Invoke(null, new object[] { null });
            }
            else if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Collection<>)))
            {
                listMethod =
                typeof(RandomValue).GetMethod("Collection")
                    .MakeGenericMethod(typeOfList)
                    .Invoke(null, new object[] { null });
            }
            else if (type.GetGenericTypeDefinition() == typeof(ICollection<>))
            {
                listMethod =
                typeof(RandomValue).GetMethod("ICollection")
                    .MakeGenericMethod(typeOfList)
                    .Invoke(null, new object[] { null });
            }
            else if (type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                listMethod = 
                typeof(RandomValue).GetMethod("IEnumerable")
                    .MakeGenericMethod(typeOfList)
                    .Invoke(null, new object[] {  }); ;
            }

            return listMethod;
        }


        private static bool IsSupportedCollection(Type propertyType)
        {
            return propertyType.GetInterface("ICollection") != null 
                || (propertyType.IsGenericType 
                && (propertyType.GetGenericTypeDefinition() == typeof(ICollection<>) 
                || propertyType.GetGenericTypeDefinition() == typeof(IList<>)
                || propertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>)));
        }

        private static object ObjectMethodCall(Type type)
        {
            return typeof(RandomValue).GetMethod("Object")
                .MakeGenericMethod(type)
                .Invoke(null, new object[] {});
        }

        private static object EnumMethodCall(Type type)
        {
            return typeof(RandomValue).GetMethod("Enum")
                .MakeGenericMethod(type)
                .Invoke(null, new object[] { });
        }

        private static object EnumerableMethodCall(Type type)
        {
            return typeof(RandomValue).GetMethod("IEnumerable")
                .MakeGenericMethod(type)
                .Invoke(null, new object[] { });
        }
    }
}
