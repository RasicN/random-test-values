using System;
using System.Collections;
using FluentAssertions;

namespace RandomTestValues.UnitTests.ShouldExtensions
{
    public static class ShouldToFluentExtensions
    {
        public static void ShouldBeGreaterThanOrEqualTo(this int value, int count)
        {
            value.Should().BeGreaterOrEqualTo(count);
        }

        public static void ShouldBeType<T>(this object value)
        {
            value.Should().BeOfType<T>();
        }

        public static void ShouldEqual(this object value, object expected)
        {
            value.Should().Be(expected);
        }

        public static void ShouldBeInRange(this int value, int min, int max)
        {
            value.Should().BeInRange(min, max);
        }

        public static void ShouldBeTrue(this bool value)
        {
            value.Should().BeTrue();
        }

        public static void ShouldNotEqual(this object value, object expected)
        {
            value.Should().NotBe(expected);
        }

        public static void ShouldBeInRange(this DateTime value, DateTime min, DateTime max)
        {
            value.Should().BeBefore(max);
            value.Should().BeAfter(min);
        }

        public static void ShouldBeLessThan(this DateTime value, DateTime max)
        {
            value.Should().BeBefore(max);
        }

        public static void ShouldBeGreaterThan(this DateTime value, DateTime min)
        {
            value.Should().BeAfter(min);
        }

        public static void ShouldBeGreaterThan(this decimal value, decimal min)
        {
            value.Should().BeGreaterThan(min);
        }

        public static void ShouldBeLessThan(this decimal value, decimal max)
        {
            value.Should().BeLessThan(max);
        }

        public static void ShouldBeInRange(this ulong value, ulong min, ulong max)
        {
            value.Should().BeInRange(min, max);
        }

        public static void ShouldBeInRange(this long value, long min, long max)
        {
            value.Should().BeInRange(min, max);
        }

        public static void ShouldBeInRange(this short value, short min, short max)
        {
            value.Should().BeInRange(min, max);
        }

        public static void ShouldBeInRange(this uint value, uint min, uint max)
        {
            value.Should().BeInRange(min, max);
        }

        public static void ShouldBeInRange(this sbyte value, sbyte min, sbyte max)
        {
            value.Should().BeInRange(min, max);
        }

        public static void ShouldBeInRange(this byte value, byte min, byte max)
        {
            value.Should().BeInRange(min, max);
        }

        public static void ShouldBeGreaterThan(this int value, int min)
        {
            value.Should().BeGreaterThan(min);
        }

        public static void ShouldBeInRange(this double value, double min, double max)
        {
            value.Should().BeInRange(min, max);
        }
    }
}
