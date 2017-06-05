namespace RandomTestValues.Formats
{
    public static partial class RandomFormat
    {
        public static string Email()
        {
            return $"{RandomValue.String(15)}@{RandomValue.String(10)}.com";
        }
    }
}
