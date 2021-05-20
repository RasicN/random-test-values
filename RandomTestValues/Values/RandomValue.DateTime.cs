using System;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        public static DateTimeOffset DateTimeOffset()
        {
            return new DateTimeOffset(DateTime());
        }

        /// <summary>
        /// Use for getting a random DateTimes for your unit tests. 
        /// </summary>
        /// <returns>A random DateTime between the inclusive minDateTime value and the exclusive maxDateTime value.</returns>
        public static DateTime DateTime(DateTime? minDateTime = null, DateTime? maxDateTime = null)
        {
            if (minDateTime == null)
            {
                minDateTime = new DateTime(1610, 1, 7); //discovery of galilean moons. Using system.DateTime.Min just made weird looking dates.
            }

            if (maxDateTime == null)
            {
                maxDateTime = System.DateTime.Now;
            }

            var timeBetween = maxDateTime.Value - minDateTime.Value;
            var hoursBetween = timeBetween.TotalHours;

            return hoursBetween <= 1.0
                ? minDateTime.Value
                : minDateTime.Value.AddHours(Int((int)hoursBetween, 1));
        }
    }
}