using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Should.Core.Assertions;

namespace RandomTestValues.Tests.ShouldExtensions
{
    public static class ShouldNotBeDefaultExtensions
    {
        public static void ShouldNotBeDefault(this decimal value)
        {
            Assert.NotEqual(new decimal(), value);
        }

        public static void ShouldNotBeDefault(this string value)
        {
            Assert.NotNull(value);
        }

        public static void ShouldNotBeDefault(this double value)
        {
            Assert.NotEqual(new double(), value);
        }

        public static void ShouldNotBeDefault(this int value)
        {
            Assert.NotEqual(new int(), value);
        }

        public static void ShouldNotBeDefault(this object value)
        {
            Assert.NotNull(value);
        }
    }
}
