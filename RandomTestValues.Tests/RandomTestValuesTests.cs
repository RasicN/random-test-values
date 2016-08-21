using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using Should;
using System.Collections.Generic;
using System.Linq;

namespace RandomTestValues.Tests
{
    [TestClass]
    public class RandomTestValuesTests
    {
        [TestMethod]
        public void RandomStringShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomString1 = RandomTestValues.String();
            var randomString2 = RandomTestValues.String();

            randomString1.ShouldNotEqual(randomString2);
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(60)]
        [DataRow(600)]
        [DataRow(6000)]
        public void RandomStringWithALengthPassedInShouldReturnAStringOfThatLength(int expectedStringLength)
        {
            var randomString = RandomTestValues.String(expectedStringLength);

            randomString.Length.ShouldEqual(expectedStringLength);
        }
        
        [TestMethod]
        public void RandomIntShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomInt1 = RandomTestValues.Int();
            var randomInt2 = RandomTestValues.Int();

            randomInt1.ShouldNotEqual(randomInt2);
        }

        [TestMethod]
        public void RandomIntShouldNotExceedMaximumValuePassedIn()
        {
            var randomInt = RandomTestValues.Int(4);

            randomInt.ShouldBeInRange(0, 4);
        }

        [TestMethod]
        public void RandomIntShouldReturnAPositiveNumberIfANegativeMaxIsPassedIn()
        {
            var randomInt = RandomTestValues.Int(-4);

            randomInt.ShouldBeInRange(0, 4);
        }

        [TestMethod]
        public void RandomByteShouldReturnSomethingDifferentMostOfTheTimeItIsCalled()
        {
            //Just comparing two would break occasionally. There are only 256 values in sbyte
            var randomBytes = new List<byte>();

            for (int i = 0; i < 20; i++)
            {
                randomBytes.Add(RandomTestValues.Byte());
            }

            var groupedbytes = randomBytes.GroupBy(x => x);
            groupedbytes.Count().ShouldBeGreaterThan(10);
        }

        [TestMethod]
        public void RandomByteShouldNotExceedTheMaximumValuePassedIn()
        {
            var randomByte = RandomTestValues.Byte(5);

            randomByte.ShouldBeInRange((byte)0, (byte)5);
        }

        [TestMethod]
        public void RandomSbyteShouldReturnSomethingDifferentMostOfTheTimeItIsCalled()
        {
            //Just comparing two would break occasionally. There are only 256 values in sbyte
            var randomSBytes = new List<sbyte>();

            for (int i = 0; i < 20; i++)
            {
                randomSBytes.Add(RandomTestValues.SByte());
            }

            var groupedSbytes = randomSBytes.GroupBy(x => x);
            groupedSbytes.Count().ShouldBeGreaterThan(10);
        }

        [TestMethod]
        public void RandomSByteShouldNotExceedTheMaximumValuePassedIn()
        {
            var randomByte = RandomTestValues.SByte(3);

            randomByte.ShouldBeInRange((sbyte)0, (sbyte)3);
        }

        [TestMethod]
        public void RandomUIntShouldNotReturnSomethingDifferentWithEachCall()
        {
            var randomUInt1 = RandomTestValues.UInt();
            var randomUInt2 = RandomTestValues.UInt();

            randomUInt1.ShouldNotEqual(randomUInt2);
        }

        [TestMethod]
        public void RandomUIntShouldReturnValuesGreaterThanMaxIntSomeTimes()
        {
            var randomUints = new List<uint>();

            for (int i = 0; i < 50; i++)
            {
                randomUints.Add(RandomTestValues.UInt());
            }

            var uintsLargerThanMaxInt = randomUints.Where(x => x > int.MaxValue);
            uintsLargerThanMaxInt.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomUIntShouldReturnValueWithinTheRangeOf0AndTheMaxValueProvided()
        {
            var randomUint = RandomTestValues.UInt(23);

            randomUint.ShouldBeInRange((uint)0, (uint)23);
        }

        [TestMethod]
        public void RandomShortShouldReturnAUniqueNumberEachTimeItIsCalled()
        {
            var randomShort1 = RandomTestValues.Short();
            var randomShort2 = RandomTestValues.Short();

            randomShort1.ShouldNotEqual(randomShort2);
        }

        [TestMethod]
        public void RandomShortShouldRespectTheMaxValueSupplied()
        {
            var randomShort = RandomTestValues.Short(12);

            randomShort.ShouldBeInRange((short)0, (short)12);
        }

        [TestMethod]
        public void RandomUShortShouldGenerateANewNumberEachTimeItIsCalled()
        {
            var randomUShort1 = RandomTestValues.UShort();
            var randomUShort2 = RandomTestValues.UShort();

            randomUShort1.ShouldNotEqual(randomUShort2);
        }

        [TestMethod]
        public void RandomLongShouldGenerateANewNumberEachTimeItIsCalled()
        {
            var randomBrendan1 = RandomTestValues.Long();
            var randomBrendan2 = RandomTestValues.Long();

            randomBrendan1.ShouldNotEqual(randomBrendan2);
        }

        [TestMethod]
        public void RandomLongShouldProduceNumbersThatAreLargeThanInts()
        {
            var randomBrendans = new List<long>();

            for (int i = 0; i < 50; i++)
            {
                randomBrendans.Add(RandomTestValues.Long());
            }

            var brendansLargerThanMaxInt = randomBrendans.Where(x => x > int.MaxValue);
            brendansLargerThanMaxInt.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomLongShouldProduceOnlyPositiveNumbers()
        {
            var randomBrendans = new List<long>();

            for (int i = 0; i < 50; i++)
            {
                randomBrendans.Add(RandomTestValues.Long());
            }

            var brendansSmallerThan0 = randomBrendans.Where(x => x < 0);
            brendansSmallerThan0.ShouldBeEmpty();
        }

        [TestMethod]
        public void RandomLongShouldRespectTheMaxValueSupplied()
        {
            var randomBrendan = RandomTestValues.Long(3000);

            randomBrendan.ShouldBeInRange(0, 3000);
        }

        [TestMethod]
        public void RandomULongShouldProductUniqueNumbersEachTimeItIsCalled()
        {
            var randomULong1 = RandomTestValues.ULong();
            var randomULong2 = RandomTestValues.ULong();

            randomULong1.ShouldNotEqual(randomULong2); 
        }

        [TestMethod]
        public void RandomULongShouldProduceSomeNumbersLargerThanMaxLong()
        {
            var randomULongs = new List<ulong>();

            for (int i = 0; i < 50; i++)
            {
                randomULongs.Add(RandomTestValues.ULong());
            }

            var numbersLargerThanMaxLong = randomULongs.Where(x => x > long.MaxValue);
            numbersLargerThanMaxLong.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomULongShouldRespectTheLargestNumberInput()
        {
            var randomULong = RandomTestValues.ULong(2000);

            randomULong.ShouldBeInRange((ulong)0, (ulong)2000);
        }

        [TestMethod]
        public void RandomFloatShouldProductUniqueValuesEachTimeItIsCalled()
        {
            var randomFloat1 = RandomTestValues.Float();
            var randomFloat2 = RandomTestValues.Float();

            randomFloat1.ShouldNotEqual(randomFloat2);
        }
        
        [TestMethod]
        public void RandomDoubleShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomDouble1 = RandomTestValues.Double();
            var randomDouble2 = RandomTestValues.Double();

            randomDouble1.ShouldNotEqual(randomDouble2);
        }

        [TestMethod]
        public void RandomCharProducesAUniqueValueEachTimeItIsCalled()
        {
            var randomChar1 = RandomTestValues.Char();
            var randomChar2 = RandomTestValues.Char();

            randomChar1.ShouldNotEqual(randomChar2);
        }

        [TestMethod]
        public void RandomBoolShouldProduceTrueApprox50PercentOfTheTime()
        {
            var randomBools = new List<bool>();

            for (int i = 0; i < 50; i++)
            {
                randomBools.Add(RandomTestValues.Bool());
            }

            var listOfTrues = randomBools.Where(x => x == true);

            listOfTrues.Count().ShouldBeInRange(15, 35);
        }

        [TestMethod]
        public void RandomDecimalShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomDecimal1 = RandomTestValues.Decimal();
            var randomDecimal2 = RandomTestValues.Decimal();

            randomDecimal1.ShouldNotEqual(randomDecimal2);
        }

        [TestMethod]
        public void RandomObjectOfSupportedValuesWillBePopulated()
        {
            var testClass = RandomTestValues.Object<TestObject>();

            testClass.RString.ShouldNotBeDefault();
            testClass.RDecimal.ShouldNotBeDefault();
            testClass.RDouble.ShouldNotBeDefault();
            testClass.RInt.ShouldNotBeDefault();
            testClass.TestObject2.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomObjectOfSupportedValuesWillReturnNullForUnDeterminable()
        {
            var testClass = RandomTestValues.Object<TestObject>();

            testClass.TestObject2.RObject.ShouldBeType<object>();
        }
    }
}
