namespace RandomTestValues
{
    public static partial class RandomValue
    {
        /// <summary>
        /// Use for getting a random Float for your unit tests.
        /// </summary>
        /// <returns>A random (positive) Float</returns>
        public static float Float()
        {
            return (float)_Random.NextDouble();
        }
    }
}