
using System;

namespace RandomTestValues.Formats
{
    public static partial class RandomFormat
    {
        public static string PhoneNumber()
        {
            var areaCode = RandomValue.Int(999, 200);
            var localCode = RandomValue.Int(999, 100);
            var lastFour = RandomValue.Int(9999, 1000);
            return $"{areaCode}{localCode}{lastFour}";
        }

        public static string PhoneNumber(PhoneFormat format)
        {
            var areaCode = RandomValue.Int(999, 200);
            var localCode = RandomValue.Int(999, 100);
            var lastFour = RandomValue.Int(9999, 1000);

            switch (format)
            {
                case PhoneFormat.NANP:
                {
                    return $"{areaCode}-{localCode}-{lastFour}";
                }
                default:
                    return PhoneNumber();
            }
        }
    }
}
