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

        /// <summary>
        /// Randomizes the properties of the given instance and specify the recursive depth (Default value = 0).
        /// </summary>
        /// <typeparam name="T">The type of the instance.</typeparam>
        /// <param name="instance">The instance of the class to have its properties randomized.</param>
        /// <param name="recursiveDepth">Recursive depth to apply.</param>
        /// <returns>The same instance with its properties set to random values.</returns>
        public static T Object<T>(T instance, int recursiveDepth = 0) where T : class
        {
            return RandomizeObject<T>(instance, new RandomValueSettings { RecursiveDepth = recursiveDepth });
        }

        /// <summary>
        /// Randomizes the properties of the given instance and specify the settings to use.
        /// </summary>
        /// <typeparam name="T">The type of the instance.</typeparam>
        /// <param name="instance">The instance of the class to have its properties randomized.</param>
        /// <param name="settings">The settings to apply.</param>
        /// <returns>The same instance with its properties set to random values.</returns>
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