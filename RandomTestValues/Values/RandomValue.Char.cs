using System;

namespace RandomTestValues
{
    public static partial class RandomValue
    {
        public static char Char()
        {
            var buffer = new byte[sizeof(char)];

            _Random.NextBytes(buffer);

            return BitConverter.ToChar(buffer, 0);
        }
    }
}