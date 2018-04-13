using System;
using RandomTestValues.Formats;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        public static Uri Uri()
        {
            return new Uri(RandomFormat.UriString());
        }
    }
}