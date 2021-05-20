using System;
using System.Linq;
using System.Reflection;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        /// <summary>
        /// Use for getting a random object.
        /// </summary>
        /// <returns>A random Object T</returns>
        public static T Object<T>(int recursiveDepth = 0) where T : new()
        {
            return Object<T>(new RandomValueSettings { RecursiveDepth = recursiveDepth });
        }

        /// <summary>
        /// Use for getting a random object. You can configure the generator by passing in a new RandomValueSettings object.
        /// </summary>
        /// <returns>A random Object T</returns>
        public static T Object<T>(RandomValueSettings settings) where T : new()
        {
            return (T)Object(typeof(T), settings);
        }

        /// <summary>
        /// Use for getting a random object.
        /// </summary>
        /// <returns>A random Object T</returns>
        public static object Object(Type type, int recursiveDepth = 0)
        {
            return Object(type, new RandomValueSettings { RecursiveDepth = recursiveDepth });
        }

        /// <summary>
        /// Use for getting a random object. You can configure the generator by passing in a new RandomValueSettings object.
        /// </summary>
        /// <returns>A random Object T</returns>
        public static object Object(Type type, RandomValueSettings settings)
        {
            var genericObject = Activator.CreateInstance(type);

            var properties = type.GetRuntimeProperties().ToArray();

            foreach (var prop in properties)
            {
                if (PropertyHasNoSetter(prop))
                {
                    // Property doesn't have a public setter so let's ignore it
                    continue;
                }

                if (settings.RecursiveDepth <= 0 && PropertyTypeIsRecursiveOrCircular(type, prop))
                {
                    // Prevent infinite loop when called recursively
                    continue;
                }

                var newSettings = new RandomValueSettings { RecursiveDepth = settings.RecursiveDepth - 1, IncludeNullAsPossibleValueForNullables = settings.IncludeNullAsPossibleValueForNullables, LengthOfCollection = settings.LengthOfCollection };

                try
                {
                    var method = GetMethodCallAssociatedWithType(prop.PropertyType, newSettings);

                    prop.SetValue(genericObject, method, null);
                }
                catch (Exception)
                {
                    // ignore
                }
            }

            return genericObject;
        }
    }
}