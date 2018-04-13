using System;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        /// <summary>
        /// Use for getting a random integer for your unit tests.
        /// </summary>
        /// <param name="maxPossibleValue">Maximum expected value (will always be a positive number)</param>
        /// <param name="minPossibleValue">Minumum expected value (will always be a positive number, will default to 0 if larger than maxossibleValue)</param>
        /// <returns>A random (positive) integer</returns>
        public static int Int(int maxPossibleValue = int.MaxValue, int minPossibleValue = 0)
        {
            if (minPossibleValue > maxPossibleValue || minPossibleValue < 0)
            {
                minPossibleValue = 0;
            }

            var max = Math.Abs(maxPossibleValue);

            return _Random.Next(max - minPossibleValue) + minPossibleValue;
        } 
    }
}