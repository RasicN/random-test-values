using System;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        public static Guid Guid()
        {
            return System.Guid.NewGuid();
        }
    }
}