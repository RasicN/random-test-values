using System;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        public static TimeSpan TimeSpan()
        {
            var date1 = DateTime();
            var date2 = DateTime();

            return date1 > date2 ? date1.Subtract(date2) : date2.Subtract(date1);
        }
    }
}