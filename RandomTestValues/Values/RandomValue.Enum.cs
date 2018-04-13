using System.Linq;
using System.Reflection;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        public static T Enum<T>()
        {
            var fields = typeof(T).GetRuntimeFields().Where(x => x.IsPublic && x.IsStatic).ToArray();

            var index = _Random.Next(fields.Length);

            return (T)System.Enum.Parse(typeof(T), fields[index].Name, false);
        }
    }
}