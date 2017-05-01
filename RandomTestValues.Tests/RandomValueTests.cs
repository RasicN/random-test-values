using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using System.Collections.Generic;
using System.Linq;

namespace RandomTestValues.Tests
{
    [TestClass]
    public class RandomValueTests
    {
        [TestMethod]
        public void RandomStringShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomString1 = RandomValue.String();
            var randomString2 = RandomValue.String();

            randomString1.ShouldNotEqual(randomString2);
        }

        [TestMethod]
        public void RandomIntShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomInt1 = RandomValue.Int();
            var randomInt2 = RandomValue.Int();

            randomInt1.ShouldNotEqual(randomInt2);
        }

        [TestMethod]
        public void RandomIntShouldNotExceedMaximumValuePassedIn()
        {
            var randomInt = RandomValue.Int(4);

            randomInt.ShouldBeInRange(0, 4);
        }

        [TestMethod]
        public void RandomIntShouldReturnAPositiveNumberIfANegativeMaxIsPassedIn()
        {
            var randomInt = RandomValue.Int(-4);

            randomInt.ShouldBeInRange(0, 4);
        }

        [TestMethod]
        public void RandomIntShouldBeWithinRangesOfMinimumANdMaximumPossibleValuesPassedIn()
        {
            var randomInt = RandomValue.Int(1000, 990);
            var randomInt2 = RandomValue.Int(10000, 9000);
            var randomInt3 = RandomValue.Int(10, 9);

            randomInt.ShouldBeInRange(990, 1000);
            randomInt2.ShouldBeInRange(9000, 10000);
            randomInt3.ShouldBeInRange(9, 10);
        }

        [TestMethod]
        public void RandomIntShouldOmitMinumumossibleValueIfIsHigherThanTheMaximumExpected()
        {
            var randomInt = RandomValue.Int(5, 15);
            var randomInt2 = RandomValue.Int(10, 200);
            var randomInt3 = RandomValue.Int(100, 30000);

            randomInt.ShouldBeInRange(0, 5);
            randomInt2.ShouldBeInRange(0, 10);
            randomInt3.ShouldBeInRange(0, 100);
        }

        [TestMethod]
        public void RandomIntShouldOmitMinumumossibleValueIfIsLowerThan0()
        {
            var randomInt = RandomValue.Int(5, -15);
            var randomInt2 = RandomValue.Int(10, -200);
            var randomInt3 = RandomValue.Int(100, -30000);

            randomInt.ShouldBeInRange(0, 5);
            randomInt2.ShouldBeInRange(0, 10);
            randomInt3.ShouldBeInRange(0, 100);
        }

        [TestMethod]
        public void RandomByteShouldReturnSomethingDifferentMostOfTheTimeItIsCalled()
        {
            //Just comparing two would break occasionally. There are only 256 values in sbyte
            var randomBytes = new List<byte>();

            for (int i = 0; i < 20; i++)
            {
                randomBytes.Add(RandomValue.Byte());
            }

            var groupedbytes = randomBytes.GroupBy(x => x);
            groupedbytes.Count().ShouldBeGreaterThan(10);
        }

        [TestMethod]
        public void RandomByteShouldNotExceedTheMaximumValuePassedIn()
        {
            var randomByte = RandomValue.Byte(5);

            randomByte.ShouldBeInRange((byte)0, (byte)5);
        }

        [TestMethod]
        public void RandomSByteShouldNotExceedTheMaximumValuePassedIn()
        {
            var randomByte = RandomValue.SByte(3);

            randomByte.ShouldBeInRange((sbyte)0, (sbyte)3);
        }

        [TestMethod]
        public void RandomUIntShouldNotReturnSomethingDifferentWithEachCall()
        {
            var randomUInt1 = RandomValue.UInt();
            var randomUInt2 = RandomValue.UInt();

            randomUInt1.ShouldNotEqual(randomUInt2);
        }

        [TestMethod]
        public void RandomUIntShouldReturnValueWithinTheRangeOf0AndTheMaxValueProvided()
        {
            var randomUint = RandomValue.UInt(23);

            randomUint.ShouldBeInRange((uint)0, (uint)23);
        }

        [TestMethod]
        public void RandomShortShouldReturnAUniqueNumberEachTimeItIsCalled()
        {
            var randomShort1 = RandomValue.Short();
            var randomShort2 = RandomValue.Short();

            randomShort1.ShouldNotEqual(randomShort2);
        }

        [TestMethod]
        public void RandomShortShouldRespectTheMaxValueSupplied()
        {
            var randomShort = RandomValue.Short(12);

            randomShort.ShouldBeInRange((short)0, (short)12);
        }

        [TestMethod]
        public void RandomUShortShouldGenerateANewNumberEachTimeItIsCalled()
        {
            var randomUShort1 = RandomValue.UShort();
            var randomUShort2 = RandomValue.UShort();

            randomUShort1.ShouldNotEqual(randomUShort2);
        }

        [TestMethod]
        public void RandomLongShouldGenerateANewNumberEachTimeItIsCalled()
        {
            var randomBrendan1 = RandomValue.Long();
            var randomBrendan2 = RandomValue.Long();

            randomBrendan1.ShouldNotEqual(randomBrendan2);
        }

        [TestMethod]
        public void RandomLongShouldRespectTheMaxValueSupplied()
        {
            var randomBrendan = RandomValue.Long(3000);

            randomBrendan.ShouldBeInRange(0, 3000);
        }

        [TestMethod]
        public void RandomULongShouldProductUniqueNumbersEachTimeItIsCalled()
        {
            var randomULong1 = RandomValue.ULong();
            var randomULong2 = RandomValue.ULong();

            randomULong1.ShouldNotEqual(randomULong2);
        }

        [TestMethod]
        public void RandomULongShouldProduceSomeNumbersLargerThanMaxLong()
        {
            var randomULongs = new List<ulong>();

            for (int i = 0; i < 50; i++)
            {
                randomULongs.Add(RandomValue.ULong());
            }

            var numbersLargerThanMaxLong = randomULongs.Where(x => x > long.MaxValue);
            numbersLargerThanMaxLong.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomULongShouldRespectTheLargestNumberInput()
        {
            var randomULong = RandomValue.ULong(2000);

            randomULong.ShouldBeInRange((ulong)0, (ulong)2000);
        }

        [TestMethod]
        public void RandomFloatShouldProductUniqueValuesEachTimeItIsCalled()
        {
            var randomFloat1 = RandomValue.Float();
            var randomFloat2 = RandomValue.Float();

            randomFloat1.ShouldNotEqual(randomFloat2);
        }

        [TestMethod]
        public void RandomDoubleShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomDouble1 = RandomValue.Double();
            var randomDouble2 = RandomValue.Double();

            randomDouble1.ShouldNotEqual(randomDouble2);
        }

        [TestMethod]
        public void RandomCharProducesAUniqueValueEachTimeItIsCalled()
        {
            var randomChar1 = RandomValue.Char();
            var randomChar2 = RandomValue.Char();

            randomChar1.ShouldNotEqual(randomChar2);
        }

        [TestMethod]
        public void RandomDecimalShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomDecimal1 = RandomValue.Decimal();
            var randomDecimal2 = RandomValue.Decimal();

            randomDecimal1.ShouldNotEqual(randomDecimal2);
        }

        [TestMethod]
        public void RandomDecimalShouldReturnValuesSmallerThanMaximumEveryTimeIsCalled()
        {
            var maxDecimal1 = .3m;
            var maxDecimal2 = 1.5m;
            var maxDecimal3 = 9.8m;

            var randomDecimal1 = RandomValue.Decimal(maxDecimal1);
            var randomDecimal2 = RandomValue.Decimal(maxDecimal2);
            var randomDecimal3 = RandomValue.Decimal(maxDecimal3);

            randomDecimal1.ShouldBeLessThan(maxDecimal1 + .01m);
            randomDecimal2.ShouldBeLessThan(maxDecimal2 + .01m);
            randomDecimal3.ShouldBeLessThan(maxDecimal3 + .01m);
        }

        [TestMethod]
        public void RandomDecimalShouldReturnARelevantValueWhenCalledWithAMaximumDecimal()
        {
            var maxDecimal1 = 520.3m;
            var maxDecimal2 = 356.5m;

            var randomDecimal1 = RandomValue.Decimal(maxDecimal1);
            var randomDecimal2 = RandomValue.Decimal(maxDecimal2);

            randomDecimal1.ShouldBeGreaterThan(1);
            randomDecimal2.ShouldBeGreaterThan(1);
        }

        [TestMethod]
        public void RandomEnumShouldReturnAnEmumOfTheCorrectType()
        {
            var randomEnum = RandomValue.Enum<TestEnum>();

            randomEnum.ShouldBeType<TestEnum>();
        }

        [TestMethod]
        public void RandomDateTimeShouldGiveUniqueValuesForEachCall()
        {
            var blindDate1 = RandomValue.DateTime();
            var blindDate2 = RandomValue.DateTime();

            blindDate1.ShouldNotEqual(blindDate2);
        }

        [TestMethod]
        public void RandomDateTimeWithMinValueRangeShouldGiveUniqueValuesForEachCallWithinGreaterThanMinValue()
        {
            var blindDate1 = RandomValue.DateTime(DateTime.Now.AddDays(-2));
            var blindDate2 = RandomValue.DateTime(DateTime.Now.AddDays(-800));

            blindDate1.ShouldNotEqual(blindDate2);
            blindDate1.ShouldBeGreaterThan(DateTime.Now.AddDays(-2));

            blindDate2.ShouldBeGreaterThan(DateTime.Now.AddDays(-800));
        }

        [TestMethod]
        public void RandomDateTimeWithMaxValueShouldGiveUniqueValuesForEachCallLessThanMaxValue()
        {
            var blindDate1 = RandomValue.DateTime(maxDateTime: DateTime.Now.AddDays(-2));
            var blindDate2 = RandomValue.DateTime(maxDateTime: DateTime.Now.AddDays(-800));

            blindDate1.ShouldNotEqual(blindDate2);
            blindDate1.ShouldBeLessThan(DateTime.Now.AddDays(-2));

            blindDate2.ShouldBeLessThan(DateTime.Now.AddDays(-800));
        }

        [TestMethod]
        public void RandomDateTimeWithRangeShouldGiveUniqueValuesForEachCallWithinRange()
        {
            var blindDate1 = RandomValue.DateTime(DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1));
            var blindDate2 = RandomValue.DateTime(DateTime.Now, DateTime.Now.AddDays(500));

            blindDate1.ShouldNotEqual(blindDate2);
            blindDate1.ShouldBeInRange(DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1));

            blindDate2.ShouldBeInRange(DateTime.Now, DateTime.Now.AddDays(500));
        }

        [TestMethod]
        public void RandomGuidShouldGiveUniqueValuesForEachCall()
        {
            var guid1 = RandomValue.Guid();
            var guid2 = RandomValue.Guid();

            guid1.ShouldNotEqual(guid2);
        }

        [TestMethod]
        public void RandomTimeSpanShouldGiveUniqueValuesForEachCall()
        {
            var timespan1 = RandomValue.TimeSpan();
            var timespan2 = RandomValue.TimeSpan();

            timespan1.ShouldNotEqual(timespan2);
        }

        [TestMethod]
        public void RandomDateTimeOffsetShouldGiveUniqueValuesForEachCall()
        {
            var offset1 = RandomValue.DateTimeOffset();
            var offset2 = RandomValue.DateTimeOffset();

            offset1.ShouldNotEqual(offset2);
        }

        [TestMethod]
        public void RandomBoolIsStatisticallyDistributed5050()
        {
            var total = 1000000;
            var trueCases = Enumerable.Repeat(0, total).Where(i => RandomValue.Bool()).Count();
            var ratio = trueCases / (double)total;
 
            ratio.ShouldBeInRange(0.49, 0.51);
        }
    }
}

