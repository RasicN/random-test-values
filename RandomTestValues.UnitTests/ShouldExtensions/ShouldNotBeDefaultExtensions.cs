using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RandomTestValues.UnitTests.ShouldExtensions
{
    public static class ShouldNotBeDefaultExtensions
    {
        public static void ShouldNotBeDefault(this decimal value)
        {
            Assert.AreNotEqual(new decimal(), value);
        }

        public static void ShouldNotBeDefault(this string value)
        {
            Assert.IsNotNull(value);
        }

        public static void ShouldNotBeDefault(this double value)
        {
            Assert.AreNotEqual(new double(), value);
        }

        public static void ShouldNotBeDefault(this int value)
        {
            Assert.AreNotEqual(new int(), value);
        }

        public static void ShouldNotBeDefault(this TimeSpan value)
        {
            Assert.AreNotEqual(new TimeSpan(), value);
        }

        public static void ShouldNotBeDefault(this object value)
        {
            Assert.IsNotNull(value);
        }
    }
}
