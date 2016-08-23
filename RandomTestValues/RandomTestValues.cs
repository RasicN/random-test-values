﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace RandomTestValues
{
    public static class RandomTestValues
    {
        public static IReadOnlyCollection<Type> SupportedTypes =>
            new List<Type>
            {
                typeof(int),
                typeof(string),
                typeof(decimal),
                typeof(double),
                typeof(bool),
                typeof(byte),
                typeof(char),
                typeof(float),
                typeof(long),
                typeof(sbyte),
                typeof(short),
                typeof(uint),
                typeof(ulong),
                typeof(ushort)
            };

        public static Random _Random = new Random();

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

            if(randomNumber == 0)
            {
                return false;
            }

            return true;
        }

        public static decimal Decimal()
        {
            return (decimal)_Random.NextDouble();
        }

        public static T Enum<T>() where T : struct, IConvertible
        {
            var fields = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);

            var index = _Random.Next(fields.Length);

            return (T)System.Enum.Parse(typeof(T), fields[index].Name, false);
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
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(genericObject, Convert.ChangeType(String(), prop.PropertyType), null);
                }
                else if (prop.PropertyType == typeof(decimal))
                {
                    prop.SetValue(genericObject, Convert.ChangeType(Decimal(), prop.PropertyType), null);
                }
                else if(prop.PropertyType == typeof(int))
                {
                    prop.SetValue(genericObject, Convert.ChangeType(Int(), prop.PropertyType), null);
                }
                else if (prop.PropertyType == typeof(double))
                {
                    prop.SetValue(genericObject, Convert.ChangeType(Double(), prop.PropertyType), null);
                }
                else
                {
                    var method =
                        typeof(RandomTestValues).GetMethod("Object")
                            .MakeGenericMethod(prop.PropertyType)
                            .Invoke(null, new object[] { });

                    prop.SetValue(genericObject, Convert.ChangeType(method, prop.PropertyType), null);
                }
            }

            return genericObject;
        }

        public static T ObjectExperiment<T>() where T : new()
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
                if (MethodsDictorary.ContainsKey(prop.PropertyType))
                {
                    prop.SetValue(genericObject, Act(prop.PropertyType), null);
                }
                else
                {
                    var method =
                        typeof(RandomTestValues).GetMethod("Object")
                            .MakeGenericMethod(prop.PropertyType)
                            .Invoke(null, new object[] { });

                    prop.SetValue(genericObject, Convert.ChangeType(method, prop.PropertyType), null);
                }
            }

            return genericObject;
        }

        private static IReadOnlyDictionary<Type, LambdaExpression> MethodsDictorary =>
            new Dictionary<Type, LambdaExpression> 
            {
                {typeof(string), (Expression<Func<string>>)(() => String()) },
                {typeof(double), (Expression<Func<double>>)(() => Double()) },
                {typeof(decimal), (Expression<Func<decimal>>)(() => Decimal()) },
                {typeof(int), (Expression<Func<int>>)(() => Int(int.MaxValue)) }
            };

        private static object Act(Type propertyType)
        {
            var method = MethodsDictorary[propertyType];

            return Convert.ChangeType(method.Compile().DynamicInvoke(), propertyType);
        }
    }
}
