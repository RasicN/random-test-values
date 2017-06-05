
using System;

namespace RandomTestValues.Formats
{
    public static partial class RandomFormat
    {
        private static readonly int Areacode = RandomValue.Int(999, 100);
        private static readonly int LocalCode = RandomValue.Int(999, 100);
        private static readonly int LastFour = RandomValue.Int(9999, 1000);
        public static string PhoneNumber()
        {
            return $"{Areacode}{LocalCode}{LastFour}";
        }

        public static string PhoneNumber(PhoneFormat format)
        {
            switch (format)
            {
                case PhoneFormat.NANP:
                {
                    return $"{Areacode}-{LocalCode}-{LastFour}";
                }
                default:
                    return PhoneNumber();
            }
        }
    }
}
