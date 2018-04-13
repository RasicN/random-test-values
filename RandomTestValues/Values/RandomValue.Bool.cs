namespace RandomTestValues
{
    public static partial class RandomValue
    {
        public static bool Bool()
        {
            var randomNumber = Int(2);

            return randomNumber != 0;
        }
    }
}