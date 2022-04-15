using System;
using System.Linq;
using System.Reflection;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        /// <summary>
        /// Use for getting a random object. You can configure the generator by passing in a new RandomValueSettings object.
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
            var genericObject = (T)Activator.CreateInstance(typeof(T));

            return RandomizeObject<T>(genericObject, settings);
        }

        public static T Object<T>(T instance, int recursiveDepth = 0) where T : class
        {
            return RandomizeObject<T>(instance, new RandomValueSettings { RecursiveDepth = recursiveDepth });
        }

        public static T Object<T>(T instance, RandomValueSettings settings) where T : class
        {
            return RandomizeObject<T>(instance, settings);
        }

        private static T RandomizeObject<T>(T instance, RandomValueSettings settings)
        {
            var properties = typeof(T).GetRuntimeProperties().ToArray();

            foreach (var prop in properties)
            {
                if (PropertyHasNoSetter(prop))
                {
                    // Property doesn't have a public setter so let's ignore it
                    continue;
                }

                if (settings.RecursiveDepth <= 0 && PropertyTypeIsRecursiveOrCircular<T>(prop))
                {
                    // Prevent infinite loop when called recursively
                    continue;
                }

                var newSettings = new RandomValueSettings
                {
                    RecursiveDepth = settings.RecursiveDepth - 1,
                    IncludeNullAsPossibleValueForNullables = settings.IncludeNullAsPossibleValueForNullables,
                    LengthOfCollection = settings.LengthOfCollection
                };

                try
                {
                    var method = GetMethodCallAssociatedWithType(prop.PropertyType, newSettings);

                    prop.SetValue(instance, method, null);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return instance;
        }
    }
}