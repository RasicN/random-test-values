using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        public static T[] Array<T>(int? optionalLength = null, int recursiveDepth = 0)
        {
            return Array<T>(new RandomValueSettings(optionalLength) { RecursiveDepth = recursiveDepth });
        }

        public static T[] Array<T>(RandomValueSettings settings)
        {
            return Collection<T>(settings).ToArray(); ;
        }

        public static List<T> List<T>(int? optionalLength = null, int recursiveDepth = 0)
        {
            return List<T>(new RandomValueSettings(optionalLength) { RecursiveDepth = recursiveDepth });
        }

        public static List<T> List<T>(RandomValueSettings settings)
        {
            return ICollection<T>(settings).ToList();
        }

        public static IList<T> IList<T>(int? optionalLength = null, int recursiveDepth = 0)
        {
            return IList<T>(new RandomValueSettings(optionalLength) { RecursiveDepth = recursiveDepth });
        }

        public static IList<T> IList<T>(RandomValueSettings settings)
        {
            return ICollection<T>(settings).ToList();
        }

        public static Collection<T> Collection<T>(int? optionalLength = null, int recursiveDepth = 0)
        {
            return Collection<T>(new RandomValueSettings(optionalLength) { RecursiveDepth = recursiveDepth });
        }

        public static Collection<T> Collection<T>(RandomValueSettings settings)
        {
            return (Collection<T>)ICollection<T>(settings);
        }

        public static ICollection<T> ICollection<T>(int? optionalLength = null, int recursiveDepth = 0)
        {
            return ICollection<T>(new RandomValueSettings(optionalLength) { RecursiveDepth = recursiveDepth });
        }

        public static ICollection<T> ICollection<T>(RandomValueSettings settings)
        {
            var enumerable = LazyIEnumerable<T>(settings).Take(settings.LengthOfCollection);

            var randomList = new Collection<T>(enumerable.ToList());

            return randomList;
        }

        public static IEnumerable<T> IEnumerable<T>(int? optionalLength = null, int recursiveDepth = 0)
        {
            return IEnumerable<T>(new RandomValueSettings(optionalLength) { RecursiveDepth = recursiveDepth });
        }

        public static IEnumerable<T> IEnumerable<T>(RandomValueSettings settings)
        {
            return LazyIEnumerable<T>(settings).Take(settings.LengthOfCollection);
        }

        public static IEnumerable<T> LazyIEnumerable<T>(int recursiveDepth = 0)
        {
            return LazyIEnumerable<T>(new RandomValueSettings { RecursiveDepth = recursiveDepth });
        }

        public static IEnumerable<T> LazyIEnumerable<T>(RandomValueSettings settings)
        {
            var type = typeof(T);

            var supportType = GetSupportType(type);

            while (supportType != SupportType.NotSupported)
            {
                var method = GetMethodCallAssociatedWithType(type, settings);

                yield return (T)method;
            }
        }

        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(int? optionalLength = null, int recursiveDepth = 0)
        {
            return Dictionary<TKey, TValue>(new RandomValueSettings(optionalLength) { RecursiveDepth = recursiveDepth });
        }

        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(RandomValueSettings settings)
        {
            return (Dictionary<TKey, TValue>)IDictionary<TKey, TValue>(settings);
        }

        public static IDictionary<TKey, TValue> IDictionary<TKey, TValue>(int? optionalLength = null, int recursiveDepth = 0)
        {
            return IDictionary<TKey, TValue>(new RandomValueSettings(optionalLength) { RecursiveDepth = recursiveDepth });
        }

        public static IDictionary<TKey, TValue> IDictionary<TKey, TValue>(RandomValueSettings settings)
        {
            var length = settings.LengthOfCollection;

            var keys = LazyIEnumerable<TKey>().Distinct().Take(length);

            var values = ICollection<TValue>(settings);

            var keyValuePairs = keys.Zip(values, (key, value) => new KeyValuePair<TKey, TValue>(key, value));

            return keyValuePairs.ToDictionary(key => key.Key, value => value.Value);
        }
    }
}