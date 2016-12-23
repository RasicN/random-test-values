﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RandomTestValues.Tests
{
    [TestClass]
    public class RandomValueCollection
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
            uintsLargerThanMaxInt.ShouldNotBeEmpty();
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

            randomEnums.Where(x => x == TestEnum.More).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Most).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Mostest).ShouldNotBeEmpty();
            randomEnums.Where(x => x == TestEnum.Mostestest).ShouldNotBeEmpty();
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
    }
}