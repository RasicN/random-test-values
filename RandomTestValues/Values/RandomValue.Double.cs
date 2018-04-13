namespace RandomTestValues
{
    public static partial class RandomValue
    {
        /// <summary>
        /// Use for getting a random Double for your unit tests.
        /// </summary>
        /// <returns>A random (positive) Double</returns>
        public static double Double()
        {
            return _Random.NextDouble();
        }
    }
}