using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;
using RandomTestValues.UnitTests.Types;

namespace RandomTestValues.UnitTests
{
    [TestClass]
    public class RandomValueCollectionTests
    {
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
        public void RandomUIntShouldReturnValuesGreaterThanMaxIntSomeTimes()
        {
            var randomUints = new List<uint>();

            for (int i = 0; i < 50; i++)
            {
                randomUints.Add(RandomValue.UInt());
            }

            var uintsLargerThanMaxInt = randomUints.Where(x => x > int.MaxValue);
            uintsLargerThanMaxInt.Any().ShouldBeTrue();
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
            brendansLargerThanMaxInt.Any().ShouldBeTrue();
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
            brendansSmallerThan0.Count().Should().Be(0);
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
        public void RandomEnumShouldHitAllTheValuesOfTheEnumIfIteratedEnough()
        {
            var randomEnums = new List<TestEnum>();

            for (int i = 0; i < 50; i++)
            {
                randomEnums.Add(RandomValue.Enum<TestEnum>());
            }

            randomEnums.Where(x => x == TestEnum.More).Any().ShouldBeTrue();
            randomEnums.Where(x => x == TestEnum.Most).Any().ShouldBeTrue();
            randomEnums.Where(x => x == TestEnum.Mostest).Any().ShouldBeTrue();
            randomEnums.Where(x => x == TestEnum.Mostestest).Any().ShouldBeTrue();
        }

        [TestMethod]
        public void NullableValuesWillBePopulatedWithCollections()
        {
            var listOfNullableInt = RandomValue.List<int?>(25);
            var int1 = listOfNullableInt.ElementAt(0);
            var int2 = listOfNullableInt.ElementAt(1);

            listOfNullableInt.All(x => x.HasValue).ShouldBeTrue();

            int1.ShouldNotEqual(int2);
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
        public void RandomCollectionOfTypeShouldReturnARandomListWithinTheSpecifiedSize()
        {
            var listOfEnums = RandomValue.List<TestEnum>(25);

            listOfEnums.Count.ShouldEqual(25);
            listOfEnums.First().ShouldBeType<TestEnum>();
        }

        [TestMethod]
        public void RandomIEnumerableShouldReturnARandomNumberOfItems()
        {
            var randomEnums = RandomValue.IEnumerable<TestEnum>();

            randomEnums.First().ShouldBeType<TestEnum>();
            randomEnums.Count().ShouldBeInRange(1, 10);
        }

        [TestMethod]
        public void RandomIEnumerablesShouldHaveDifferentCounts()
        {
            var countOfTimesThatTheEnumsWereTheSameLength = 0;

            for (int i = 0; i < 10; i++)
            {
                var randomEnums1 = RandomValue.IEnumerable<TestEnum>();
                var randomEnums2 = RandomValue.IEnumerable<TestEnum>();

                if(randomEnums1.Count() == randomEnums2.Count())
                {
                    countOfTimesThatTheEnumsWereTheSameLength++;
                }
            }

            countOfTimesThatTheEnumsWereTheSameLength.Should().BeLessOrEqualTo(4);
        }

        [TestMethod]
        public void RandomIEnumerableShouldReturnARandomNumberOfItemsWithAMaximumOf1000()
        {
            var length = 1000;

            var randomEnums = RandomValue.IEnumerable<TestEnum>(length);

            randomEnums.First().ShouldBeType<TestEnum>();
            randomEnums.Count().ShouldEqual(length);
        }

        [TestMethod]
        public void RandomLazyIEnumerableShouldReturnALazyRandomCollection()
        {
            var randomCollectionOfBrendans = RandomValue.LazyIEnumerable<long>();

            var randomBrendans = randomCollectionOfBrendans.Take(10);

            randomBrendans.Count().ShouldEqual(10);
            randomBrendans.First().ShouldBeType<long>();
            randomBrendans.First().ShouldNotEqual(randomBrendans.Last());
        }

        [TestMethod]
        public void RandomLazyIEnumerableShouldReturnLazyEnum()
        {
            var randomCollectionOfTestEnums = RandomValue.LazyIEnumerable<TestEnum>();

            var randomEnums = randomCollectionOfTestEnums.Take(1000);

            randomEnums.Count().ShouldEqual(1000);

            randomEnums.Where(x => x == TestEnum.More).Any().ShouldBeTrue();
            randomEnums.Where(x => x == TestEnum.Most).Any().ShouldBeTrue();
            randomEnums.Where(x => x == TestEnum.Mostest).Any().ShouldBeTrue();
            randomEnums.Where(x => x == TestEnum.Mostestest).Any().ShouldBeTrue();
        }

        [TestMethod]
        public void RandomLazyIEnumerableShouldReturnLazyObject()
        {
            var randomCollectionOfTestObjects = RandomValue.LazyIEnumerable<TestObject>();

            var randomObjects = randomCollectionOfTestObjects.Take(4);

            randomObjects.Count().ShouldEqual(4);
            randomObjects.First().RTestObject2List.Any().ShouldBeTrue();
        }

        [TestMethod]
        public void RandomLazyIEnumrableOfIEnumerableShouldReturnAEnumerableOfEnumerablesThatIsntLazy()
        {
            var randomCollectionOfCollections = RandomValue.LazyIEnumerable<IEnumerable<short>>().Take(29);

            randomCollectionOfCollections.Count().ShouldEqual(29);

            randomCollectionOfCollections.First().Count().ShouldBeInRange(0, 10);
        }

        [TestMethod]
        public void RandomLazyIEnumrableOfIEnumerableShouldReturnAEnumerableOfList()
        {
            var randomCollectionOfCollections = RandomValue.LazyIEnumerable<List<uint>>().Take(9);

            randomCollectionOfCollections.Count().ShouldEqual(9);
            randomCollectionOfCollections.First().ShouldBeType<List<uint>>();

            randomCollectionOfCollections.First().Count().ShouldBeInRange(1, 10);
            randomCollectionOfCollections.Last().Count().ShouldBeInRange(1, 10);
        }

        [TestMethod]
        public void RandomLazyIEnumrableOfIEnumerableShouldReturnAEnumerableOfCollection()
        {
            var randomCollectionOfCollections = RandomValue.LazyIEnumerable<ICollection<uint>>().Take(9);

            randomCollectionOfCollections.Count().ShouldEqual(9);
            randomCollectionOfCollections.First().ShouldBeType<Collection<uint>>();

            randomCollectionOfCollections.First().Count().ShouldBeInRange(1, 10);
            randomCollectionOfCollections.Last().Count().ShouldBeInRange(1, 10);
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
        public void AllItemsInTheKeysShouldBeUniqueForADictionaryNewSettingsObject()
        {
            //There should be keys from 1 - 127.
            var length = 127;

            var result = RandomValue.Dictionary<sbyte, Guid>(new RandomValueSettings { LengthOfCollection = length });

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
        public void TheValuesShouldBeUniqueForIDictionaryWithDateTimeOffset()
        {
            var result = RandomValue.IDictionary<DateTimeOffset, ulong>();

            var distinctValues = result.Values.Distinct();

            distinctValues.Count().ShouldEqual(result.Count());

            result.Keys.First().ShouldBeType<DateTimeOffset>();
            result.Values.First().ShouldBeType<ulong>();
        }
    }
}
