using System;

namespace RandomTestValues.Formats
{
    public static partial class RandomFormat
    {
        public static string UriString()
        {
            var domain = RandomValue.String(20).Replace("-", string.Empty);
            var dotComThing = RandomValue.String(3).Replace("-", string.Empty);
            return $"http://{domain}.{dotComThing}";
        }
    }
}
