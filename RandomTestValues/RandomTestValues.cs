using System;
using System.Collections.Generic;

namespace RandomTestValues
{
    public static class RandomTestValues
    {
        public static ICollection<Type> SupportedTypes =>
            new List<Type>
            {
                typeof(int),
                typeof(string),
                typeof(decimal),
                typeof(double)
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
            var randomString =  String();

            while (randomString.Length <= stringLength)
            {
                randomString += String();
            }

            return randomString.Substring(0, stringLength);
        }

        /// <summary>
        /// Use for getting a random integer for your unit tests.
        /// </summary>
        /// <returns>A random (positive) integer</returns>
        public static int Int(int maxPossibleValue = int.MaxValue)
        {
            return Math.Abs(_Random.Next(maxPossibleValue));
        }

        public static double Double()
        {
            return _Random.NextDouble();
        }

        public static decimal Decimal()
        {
            return (decimal) _Random.NextDouble();
        }

        public static T Object<T>() where T : new()
        {
            var genericObject = (T)Activator.CreateInstance(typeof(T));

            var properties = typeof(T).GetProperties();

            if (properties.Length == 0)
            {
                // properties[0].SetValue(genericObject, Convert.ChangeType(null, properties[0].PropertyType), null);
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
                            .Invoke(null, new object[] {});

                    prop.SetValue(genericObject, Convert.ChangeType(method, prop.PropertyType), null);
                }
            }

            return genericObject;
        }
    }
}
