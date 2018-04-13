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
        /// Use for getting a random DateTimes for your unit tests. Always returns a date in the past. 
        /// </summary>
        /// <returns>A random DateTime</returns>
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

            var timeSinceStartOfDateTime = maxDateTime.Value - minDateTime.Value;
            var timeInHoursSinceStartOfDateTime = (int)timeSinceStartOfDateTime.TotalHours;
            var hoursToSubtract = Int(timeInHoursSinceStartOfDateTime) * -1;
            var timeToReturn = maxDateTime.Value.AddHours(hoursToSubtract);

            if (timeToReturn > minDateTime.Value && timeToReturn < maxDateTime.Value)
            {
                return timeToReturn;
            }

            return System.DateTime.Now;
        }
    }
}