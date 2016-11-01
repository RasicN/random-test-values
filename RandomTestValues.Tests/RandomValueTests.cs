using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using Should;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public void RandomSbyteShouldReturnSomethingDifferentMostOfTheTimeItIsCalled()
        {
            //Just comparing two would break occasionally. There are only 256 values in sbyte
            var randomSBytes = new List<sbyte>();

            for (int i = 0; i < 20; i++)
            {
                randomSBytes.Add(RandomValue.SByte());
            }

            var groupedSbytes = randomSBytes.GroupBy(x => x);
            groupedSbytes.Count().ShouldBeGreaterThan(10);
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
        public void RandomUIntShouldReturnValuesGreaterThanMaxIntSomeTimes()
        {
            var randomUints = new List<uint>();

            for (int i = 0; i < 50; i++)
            {
                randomUints.Add(RandomValue.UInt());
            }

            var uintsLargerThanMaxInt = randomUints.Where(x => x > int.MaxValue);
            uintsLargerThanMaxInt.ShouldNotBeEmpty();
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
        public void RandomLongShouldProduceNumbersThatAreLargeThanInts()
        {
            var randomBrendans = new List<long>();

            for (int i = 0; i < 50; i++)
            {
                randomBrendans.Add(RandomValue.Long());
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
                randomBrendans.Add(RandomValue.Long());
            }

            var brendansSmallerThan0 = randomBrendans.Where(x => x < 0);
            brendansSmallerThan0.ShouldBeEmpty();
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
        public void RandomBoolShouldProduceTrueApprox50PercentOfTheTime()
        {
            var randomBools = new List<bool>();

            for (int i = 0; i < 1000; i++)
            {
                randomBools.Add(RandomValue.Bool());
            }

            var listOfTrues = randomBools.Where(x => x == true);

            listOfTrues.Count().ShouldBeInRange(400, 600);
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
        public void RandomEnumShouldHitAllTheValuesOfTheEnumIfIteratedEnough()
        {
            var randomEnums = new List<TestEnum>();

            for (int i = 0; i < 50; i++)
            {
                randomEnums.Add(RandomValue.Enum<TestEnum>());
            }

            randomEnums.Where(x => x == TestEnum.More).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Most).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Mostest).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Mostestest).ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomObjectOfSupportedValuesWillBePopulated()
        {
            var testClass = RandomValue.Object<TestObject>();

            testClass.RString.ShouldNotBeDefault();
            testClass.RDecimal.ShouldNotBeDefault();
            testClass.RDouble.ShouldNotBeDefault();
            testClass.RInt.ShouldNotBeDefault();
            testClass.RCollection.ShouldNotBeEmpty();
            testClass.RCollection2.ShouldNotBeEmpty();
            testClass.RList.ShouldNotBeEmpty();
            testClass.RList2.ShouldNotBeEmpty();
            testClass.TestObject2.ShouldNotBeDefault();
            testClass.RTestObject2List.ShouldNotBeEmpty();
            testClass.RDateTime.ShouldNotBeDefault();
            testClass.RTestObject2Collection.ShouldNotBeEmpty();
            testClass.RGuid.ShouldNotBeDefault();
            testClass.REnumList.ShouldNotBeEmpty();
            testClass.TestObject3.ShouldNotBeDefault();
            testClass.RInt2.ShouldNotBeDefault();
            testClass.RString2.ShouldNotBeDefault();
            testClass.RDecimal2.ShouldNotBeDefault();
            testClass.RDouble2.ShouldNotBeDefault();
            testClass.REnumCollection.ShouldNotBeEmpty();
            testClass.LazyShorts.ShouldNotBeEmpty();
            testClass.LazyShorts.Take(10).Count().ShouldEqual(10);
            testClass.Strings.ShouldNotBeEmpty();
            testClass.RTestObject2Array.ShouldNotBeEmpty();
            testClass.TimeSpan.ShouldNotBeDefault();

            Should.Core.Assertions.Assert.True(
                (int) testClass.REnum == (int) TestEnum.More
                || (int) testClass.REnum == (int) TestEnum.Most
                || (int) testClass.REnum == (int) TestEnum.Mostest
                || (int) testClass.REnum == (int) TestEnum.Mostestest);
        }

        [TestMethod]
        public void NullableValuesWillBePopulatedWithCollections()
        {
            var listOfNullableInt = RandomValue.List<int?>(25);
            var int1 = listOfNullableInt.ElementAt(0);
            var int2 = listOfNullableInt.ElementAt(1);
            
            Should.Core.Assertions.Assert.True(listOfNullableInt.All(x => x.HasValue));
            
            int1.ShouldNotEqual(int2);
        }

        [TestMethod]
        public void NullableValuesWillBePopulatedWithObject()
        {
            var testClass = RandomValue.Object<NullableTestObject>();

            testClass.RDecimal.ShouldNotBeDefault();
            testClass.RDouble.ShouldNotBeDefault();
            testClass.RInt.ShouldNotBeDefault();
            testClass.RCollection.ShouldNotBeEmpty();
            testClass.RCollection2.ShouldNotBeEmpty();
            testClass.RList.ShouldNotBeEmpty();
            testClass.RDateTime.ShouldNotBeDefault();
            testClass.RGuid.ShouldNotBeDefault();
            testClass.REnumList.ShouldNotBeEmpty();
            testClass.RInt2.ShouldNotBeDefault();
            testClass.RDecimal2.ShouldNotBeDefault();
            testClass.RDouble2.ShouldNotBeDefault();
            testClass.REnumCollection.ShouldNotBeEmpty();
            testClass.LazyShorts.ShouldNotBeEmpty();
            testClass.LazyShorts.Take(10).Count().ShouldEqual(10);

            Should.Core.Assertions.Assert.True(
                (int)testClass.REnum == (int)TestEnum.More
                || (int)testClass.REnum == (int)TestEnum.Most
                || (int)testClass.REnum == (int)TestEnum.Mostest
                || (int)testClass.REnum == (int)TestEnum.Mostestest);
        }

        [TestMethod]
        public void RandomObjectWillSupportACrazyCollectionOfCollections()
        {
            var testClass = RandomValue.Object<TestObject>();

            var enumeration = testClass.CrazyBools.Take(3);

            enumeration.Count().ShouldEqual(3);
            enumeration.First().ShouldBeType<List<Collection<bool>>>();
        }

        [TestMethod]
        public void RandomObjectOfSupportedValuesWillReturnNullForUnDeterminable()
        {
            var testClass = RandomValue.Object<TestObject>();

            testClass.TestObject2.RObject.ShouldBeType<object>();
        }

        [TestMethod]
        public void RandomObjectOfSupportedValuesWillReturnGoodValuesInObjectsThatAreRecursivelyFound()
        {
            var testClass = RandomValue.Object<TestObject>();

            testClass.TestObject2.RObject.ShouldBeType<object>();
            testClass.TestObject2.RInt2.ShouldNotBeDefault();
            testClass.TestObject2.RString2.ShouldNotBeDefault();
            testClass.TestObject2.RDouble2.ShouldNotBeDefault();
            testClass.TestObject2.RDecimal2.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnADifferentCollectionEachTime()
        {
            var stringCollection1 = RandomValue.Collection<string>();
            var stringCollection2 = RandomValue.Collection<string>();

            var intCollection1 = RandomValue.Collection<int>();
            var intCollection2 = RandomValue.Collection<int>();

            stringCollection1.ShouldNotEqual(stringCollection2);
            intCollection1.ShouldNotEqual(intCollection2);
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnARandomCollectionOfTheSpecifiedSize()
        {
            var stringCollection = RandomValue.Collection<string>(25);
            
            stringCollection.Count.ShouldEqual(25);
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnADifferentICollectionEachTime()
        {
            var stringCollection1 = RandomValue.ICollection<string>();
            var stringCollection2 = RandomValue.ICollection<string>();

            var intCollection1 = RandomValue.ICollection<int>();
            var intCollection2 = RandomValue.ICollection<int>();

            stringCollection1.ShouldNotEqual(stringCollection2);
            intCollection1.ShouldNotEqual(intCollection2);
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnARandomICollectionOfTheSpecifiedSize()
        {
            var stringCollection = RandomValue.ICollection<string>(25);

            stringCollection.Count.ShouldEqual(25);
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnADifferentIListEachTime()
        {
            var stringList1 = RandomValue.IList<string>();
            var stringList2 = RandomValue.IList<string>();

            var intList1 = RandomValue.IList<int>();
            var intList2 = RandomValue.IList<int>();

            stringList1.ShouldNotEqual(stringList2);
            intList1.ShouldNotEqual(intList2);
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnARandomIListOfTheSpecifiedSize()
        {
            var enumCollection = RandomValue.IList<TestEnum>(25);

            enumCollection.Count.ShouldEqual(25);
            enumCollection.First().ShouldBeType<TestEnum>();
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnADifferentListEachTime()
        {
            var stringList1 = RandomValue.List<string>();
            var stringList2 = RandomValue.List<string>();

            var intList1 = RandomValue.List<int>();
            var intList2 = RandomValue.List<int>();

            stringList1.ShouldNotEqual(stringList2);
            intList1.ShouldNotEqual(intList2);
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnARandomListOfTheSpecifiedSize()
        {
            var enumCollection = RandomValue.List<TestEnum>(25);

            enumCollection.Count.ShouldEqual(25);
            enumCollection.First().ShouldBeType<TestEnum>();
        }

        [TestMethod]
        public void RandomIEnumerableShouldReturnALazyRandomCollection()
        {
            var randomCollectionOfBrendans = RandomValue.IEnumerable<long>();

            var randomBrendans = randomCollectionOfBrendans.Take(10);

            randomBrendans.Count().ShouldEqual(10);
            randomBrendans.First().ShouldBeType<long>();
            randomBrendans.First().ShouldNotEqual(randomBrendans.Last());
        }

        [TestMethod]
        public void RandomIEnumerableShouldReturnLazyEnum()
        {
            var randomCollectionOfTestEnums = RandomValue.IEnumerable<TestEnum>();

            var randomEnums = randomCollectionOfTestEnums.Take(1000);

            randomEnums.Count().ShouldEqual(1000);

            randomEnums.Where(x => x == TestEnum.More).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Most).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Mostest).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Mostestest).ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomIEnumerableShouldReturnLazyObject()
        {
            var randomCollectionOfTestObjects = RandomValue.IEnumerable<TestObject>();

            var randomObjects = randomCollectionOfTestObjects.Take(4);

            randomObjects.Count().ShouldEqual(4);
            randomObjects.First().RTestObject2List.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void RandomIEnumrableOfIEnumerableShouldReturnAEnumerableOfEnumerables()
        {
            var randomCollectionOfCollections = RandomValue.IEnumerable<IEnumerable<short>>().Take(29);

            randomCollectionOfCollections.Count().ShouldEqual(29);

            var itemsInRandomCollection = randomCollectionOfCollections.First().Where(x => x < 3000).Take(10);

            itemsInRandomCollection.Count().ShouldEqual(10);
            itemsInRandomCollection.Where(x => x >= 3000).ShouldBeEmpty();

            var itemsInSecondRandomCollection = randomCollectionOfCollections.Last().Where(x => x < 3000 & x > 1000).Take(100);

            itemsInSecondRandomCollection.TakeWhile(x => x < 3000 & x > 1000).Count().ShouldEqual(100);
        }

        [TestMethod]
        public void RandomIEnumrableOfIEnumerableShouldReturnAEnumerableOfList()
        {
            var randomCollectionOfCollections = RandomValue.IEnumerable<List<uint>>().Take(9);

            randomCollectionOfCollections.Count().ShouldEqual(9);
            randomCollectionOfCollections.First().ShouldBeType<List<uint>>();

            randomCollectionOfCollections.First().Count().ShouldBeInRange(1, 10);
            randomCollectionOfCollections.Last().Count().ShouldBeInRange(1, 10);
        }

        [TestMethod]
        public void RandomIEnumrableOfIEnumerableShouldReturnAEnumerableOfCollection()
        {
            var randomCollectionOfCollections = RandomValue.IEnumerable<ICollection<uint>>().Take(9);

            randomCollectionOfCollections.Count().ShouldEqual(9);
            randomCollectionOfCollections.First().ShouldBeType<Collection<uint>>();

            randomCollectionOfCollections.First().Count().ShouldBeInRange(1, 10);
            randomCollectionOfCollections.Last().Count().ShouldBeInRange(1, 10);
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
        public void AllItemsInTheKeysShouldBeUniqueForADictionary()
        {
            //There should be keys from 1 - 127.
            var length = 127;

            var result = RandomValue.Dictionary<sbyte, Guid>(length);

            for (int i = 0; i < length; i++)
            {
                result.ContainsKey((sbyte)i).ShouldBeTrue();
            }

            result.Keys.First().ShouldBeType<sbyte>();
            result.Values.First().ShouldBeType<Guid>();
        }

        [TestMethod]
        public void TheLengthShouldBeBetween1and10ForDictionary()
        {
            var result = RandomValue.Dictionary<long, sbyte>();

            result.Count().ShouldBeInRange(1, 10);

            result.Keys.First().ShouldBeType<long>();
            result.Values.First().ShouldBeType<sbyte>();
        }

        [TestMethod]
        public void TheValuesShouldBeUniquForDictionary()
        {
            var result = RandomValue.Dictionary<int, Guid>();

            var distinctValues = result.Values.Distinct();

            distinctValues.Count().ShouldEqual(result.Count());

            result.Keys.First().ShouldBeType<int>();
            result.Values.First().ShouldBeType<Guid>();
        }

        [TestMethod]
        public void AllItemsInTheKeysShouldBeUniqueForAIDictionary()
        {
            //There should be keys from 1 - 127.
            var length = 127;

            var result = RandomValue.IDictionary<sbyte, short>(length);

            for (int i = 0; i < length; i++)
            {
                result.ContainsKey((sbyte)i).ShouldBeTrue();
            }

            result.Keys.First().ShouldBeType<sbyte>();
            result.Values.First().ShouldBeType<short>();
        }

        [TestMethod]
        public void TheLengthShouldBeBetween1and10ForIDictionary()
        {
            var result = RandomValue.IDictionary<DateTime, sbyte>();

            result.Count().ShouldBeInRange(1, 10);

            result.Keys.First().ShouldBeType<DateTime>();
            result.Values.First().ShouldBeType<sbyte>();
        }

        [TestMethod]
        public void TheValuesShouldBeUniqueForIDictionary()
        {
            var result = RandomValue.IDictionary<TimeSpan, ulong>();

            var distinctValues = result.Values.Distinct();

            distinctValues.Count().ShouldEqual(result.Count());

            result.Keys.First().ShouldBeType<TimeSpan>();
            result.Values.First().ShouldBeType<ulong>();
        }

        [TestMethod]
        public void TheDictionaryShouldBeSetUpCorrectlyOnTheTestObject()
        {
            var result = RandomValue.Object<TestObject>();

            result.RDictionary.Count().ShouldBeGreaterThanOrEqualTo(1);
            result.RDictionary.Keys.First().ShouldBeType<DateTime>();
            result.RDictionary.Values.First().ShouldBeType<int>();
        }

        [TestMethod]
        public void TheIDictionaryShouldBeSetUpCorrectlyOnTheTestObject()
        {
            var result = RandomValue.Object<TestObject>();

            result.RIDictionary.Count().ShouldBeGreaterThanOrEqualTo(1);
            result.RIDictionary.Keys.First().ShouldBeType<TimeSpan>();
            result.RIDictionary.Values.First().ShouldBeType<Collection<bool>>();
        }
    }
}
