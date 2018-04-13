namespace RandomTestValues
{
    public static partial class RandomValue
    {
        /// <summary>
        /// Use for getting a random Decimal for your unit test
        /// </summary>
        /// <param name="maxPossibleValue">Maximum decimal value, defaults to 1</param>
        /// <returns></returns>
        public static decimal Decimal(decimal maxPossibleValue = 1m)
        {
            return (decimal)_Random.NextDouble() * maxPossibleValue;
        }
    }
}