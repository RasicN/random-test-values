using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RandomTestValues.Tests
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
            CollectionAssertions(RandomValue.List<int?>(25));
            CollectionAssertions(RandomValue.List(typeof(int?), 25).Cast<int?>().ToArray());

            void CollectionAssertions(IList<int?> collection)
            {
                var int1 = collection.ElementAt(0);
                var int2 = collection.ElementAt(1);

                collection.All(x => x.HasValue).ShouldBeTrue();

                int1.ShouldNotEqual(int2);
            }
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnADifferentCollectionEachTime()
        {
            StringCollectionAssertions(RandomValue.Collection<string>(), RandomValue.Collection<string>());
            StringCollectionAssertions(
                RandomValue.Collection(typeof(string)).Cast<string>().ToArray(), 
                RandomValue.Collection(typeof(string)).Cast<string>().ToArray());

            IntCollectionAssertions(RandomValue.Collection<int>(), RandomValue.Collection<int>());
            IntCollectionAssertions(
                RandomValue.Collection(typeof(int)).Cast<int>().ToArray(), 
                RandomValue.Collection(typeof(int)).Cast<int>().ToArray());

            void StringCollectionAssertions(ICollection<string> stringCollection1, ICollection<string> stringCollection2)
            {
                stringCollection1.ShouldNotEqual(stringCollection2);
            }

            void IntCollectionAssertions(ICollection<int> intCollection1, ICollection<int> intCollection2)
            {
                intCollection1.ShouldNotEqual(intCollection2);
            }
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnARandomCollectionOfTheSpecifiedSize()
        {
            CollectionAssertions(RandomValue.Collection<string>(25));
            CollectionAssertions(RandomValue.Collection(typeof(string), 25).Cast<string>().ToArray());

            void CollectionAssertions(ICollection<string> stringCollection)
            {
                stringCollection.Count.ShouldEqual(25);
            }
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnADifferentICollectionEachTime()
        {
            StringCollectionAssertions(RandomValue.ICollection<string>(), RandomValue.ICollection<string>());
            StringCollectionAssertions(
                RandomValue.ICollection(typeof(string)).Cast<string>().ToArray(),
                RandomValue.ICollection(typeof(string)).Cast<string>().ToArray());

            IntCollectionAssertions(RandomValue.ICollection<int>(), RandomValue.ICollection<int>());
            IntCollectionAssertions(
                RandomValue.ICollection(typeof(int)).Cast<int>().ToArray(),
                RandomValue.ICollection(typeof(int)).Cast<int>().ToArray());

            void StringCollectionAssertions(ICollection<string> stringCollection1, ICollection<string> stringCollection2)
            {
                stringCollection1.ShouldNotEqual(stringCollection2);
            }

            void IntCollectionAssertions(ICollection<int> intCollection1, ICollection<int> intCollection2)
            {
                intCollection1.ShouldNotEqual(intCollection2);
            }
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnARandomICollectionOfTheSpecifiedSize()
        {
            CollectionAssertions(RandomValue.ICollection<string>(25));
            CollectionAssertions(RandomValue.ICollection(typeof(string), 25).Cast<string>().ToArray());

            void CollectionAssertions(ICollection<string> stringCollection)
            {
                stringCollection.Count.ShouldEqual(25);
            }
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnADifferentIListEachTime()
        {
            StringCollectionAssertions(RandomValue.IList<string>(), RandomValue.IList<string>());
            StringCollectionAssertions(
                RandomValue.IList(typeof(string)).Cast<string>().ToArray(),
                RandomValue.IList(typeof(string)).Cast<string>().ToArray());

            IntCollectionAssertions(RandomValue.IList<int>(), RandomValue.IList<int>());
            IntCollectionAssertions(
                RandomValue.IList(typeof(int)).Cast<int>().ToArray(),
                RandomValue.IList(typeof(int)).Cast<int>().ToArray());

            void StringCollectionAssertions(IList<string> stringList1, IList<string> stringList2)
            {
                stringList1.ShouldNotEqual(stringList2);
            }

            void IntCollectionAssertions(IList<int> intList1, IList<int> intList2)
            {
                intList1.ShouldNotEqual(intList2);
            }
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnARandomIListOfTheSpecifiedSize()
        {
            CollectionAssertions(RandomValue.IList<TestEnum>(25));
            CollectionAssertions(RandomValue.IList(typeof(TestEnum), 25).Cast<TestEnum>().ToArray());

            void CollectionAssertions(ICollection<TestEnum> enumCollection)
            {
                enumCollection.Count.ShouldEqual(25);
                enumCollection.First().ShouldBeType<TestEnum>();
            }
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnADifferentListEachTime()
        {
            StringCollectionAssertions(RandomValue.List<string>(), RandomValue.List<string>());
            StringCollectionAssertions(
                RandomValue.List(typeof(string)).Cast<string>().ToArray(),
                RandomValue.List(typeof(string)).Cast<string>().ToArray());

            IntCollectionAssertions(RandomValue.List<int>(), RandomValue.List<int>());
            IntCollectionAssertions(
                RandomValue.List(typeof(int)).Cast<int>().ToArray(),
                RandomValue.List(typeof(int)).Cast<int>().ToArray());

            void StringCollectionAssertions(IList<string> stringList1, IList<string> stringList2)
            {
                stringList1.ShouldNotEqual(stringList2);
            }

            void IntCollectionAssertions(IList<int> intList1, IList<int> intList2)
            {
                intList1.ShouldNotEqual(intList2);
            }
        }

        [TestMethod]
        public void RandomCollectionOfTypeShouldReturnARandomListWithinTheSpecifiedSize()
        {
            CollectionAssertions(RandomValue.List<TestEnum>(25));
            CollectionAssertions(RandomValue.List(typeof(TestEnum), 25).Cast<TestEnum>().ToArray());

            void CollectionAssertions(ICollection<TestEnum> listOfEnums)
            {
                listOfEnums.Count.ShouldEqual(25);
                listOfEnums.First().ShouldBeType<TestEnum>();
            }
        }

        [TestMethod]
        public void RandomIEnumerableShouldReturnARandomNumberOfItems()
        {
            CollectionAssertions(RandomValue.IEnumerable<TestEnum>());
            CollectionAssertions(RandomValue.IEnumerable(typeof(TestEnum)).Cast<TestEnum>());

            void CollectionAssertions(IEnumerable<TestEnum> randomEnums)
            {
                randomEnums.First().ShouldBeType<TestEnum>();
                randomEnums.Count().ShouldBeInRange(1, 10);
            }
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
            const int length = 1000;

            CollectionAssertions(RandomValue.IEnumerable<TestEnum>(length));
            CollectionAssertions(RandomValue.IEnumerable(typeof(TestEnum), length).Cast<TestEnum>());

            void CollectionAssertions(IEnumerable<TestEnum> randomEnums)
            {
                randomEnums.First().ShouldBeType<TestEnum>();
                randomEnums.Count().ShouldEqual(length);
            }
        }

        [TestMethod]
        public void RandomLazyIEnumerableShouldReturnALazyRandomCollection()
        {
            CollectionAssertions(RandomValue.LazyIEnumerable<long>());
            CollectionAssertions(RandomValue.LazyIEnumerable(typeof(long)).Cast<long>());

            void CollectionAssertions(IEnumerable<long> collection)
            {
                const int count = 10;

                var randomLongs = collection.Take(count);

                randomLongs.Count().ShouldEqual(count);
                randomLongs.First().ShouldBeType<long>();
                randomLongs.First().ShouldNotEqual(randomLongs.Last());
            }
        }

        [TestMethod]
        public void RandomLazyIEnumerableShouldReturnLazyEnum()
        {
            CollectionAssertions(RandomValue.LazyIEnumerable<TestEnum>());
            CollectionAssertions(RandomValue.LazyIEnumerable(typeof(TestEnum)).Cast<TestEnum>());

            void CollectionAssertions(IEnumerable<TestEnum> collection)
            {
                var randomEnums = collection.Take(1000);

                randomEnums.Count().ShouldEqual(1000);

                randomEnums.Where(x => x == TestEnum.More).ShouldNotBeEmpty();
                randomEnums.Where(x => x == TestEnum.Most).ShouldNotBeEmpty();
                randomEnums.Where(x => x == TestEnum.Mostest).ShouldNotBeEmpty();
                randomEnums.Where(x => x == TestEnum.Mostestest).ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void RandomLazyIEnumerableShouldReturnLazyObject()
        {
            CollectionAssertions(RandomValue.LazyIEnumerable<TestObject>());
            CollectionAssertions(RandomValue.LazyIEnumerable(typeof(TestObject)).Cast<TestObject>());

            void CollectionAssertions(IEnumerable<TestObject> collection)
            {
                const int count = 4;

                var randomObjects = collection.Take(count);

                randomObjects.Count().ShouldEqual(count);
                randomObjects.First().RTestObject2List.ShouldNotBeEmpty();
            }
        }

        [TestMethod]
        public void RandomLazyIEnumerableOfIEnumerableShouldReturnAEnumerableOfEnumerablesThatIsntLazy()
        {
            const int count = 29;
            
            CollectionAssertions(RandomValue.LazyIEnumerable<IEnumerable<short>>().Take(count));
            CollectionAssertions(RandomValue.LazyIEnumerable(typeof(IEnumerable<short>)).Cast<IEnumerable<short>>().Take(count));

            void CollectionAssertions(IEnumerable<IEnumerable<short>> collection)
            {
                collection.Count().ShouldEqual(count);
                collection.First().Count().ShouldBeInRange(0, 10);
            }
        }

        [TestMethod]
        public void RandomLazyIEnumerableOfIEnumerableShouldReturnAEnumerableOfList()
        {
            const int count = 9;

            CollectionAssertions(RandomValue.LazyIEnumerable<List<uint>>().Take(count));
            CollectionAssertions(RandomValue.LazyIEnumerable(typeof(List<uint>)).Cast<List<uint>>().Take(count));

            void CollectionAssertions(IEnumerable<List<uint>> collection)
            {
                collection.Count().ShouldEqual(count);
                collection.First().ShouldBeType<List<uint>>();

                collection.First().Count.ShouldBeInRange(1, 10);
                collection.Last().Count.ShouldBeInRange(1, 10);
            }
        }

        [TestMethod]
        public void RandomLazyIEnumerableOfIEnumerableShouldReturnAEnumerableOfCollection()
        {
            const int count = 9;
            
            CollectionAssertions(RandomValue.LazyIEnumerable<ICollection<uint>>().Take(count));
            CollectionAssertions(RandomValue.LazyIEnumerable(typeof(ICollection<uint>)).Cast<ICollection<uint>>().Take(count));

            void CollectionAssertions(IEnumerable<ICollection<uint>> collection)
            {
                collection.Count().ShouldEqual(count);
                collection.First().ShouldBeType<Collection<uint>>();

                collection.First().Count.ShouldBeInRange(1, 10);
                collection.Last().Count.ShouldBeInRange(1, 10);
            }
        }

        [TestMethod]
        public void AllItemsInTheKeysShouldBeUniqueForADictionary()
        {
            //There should be keys from 1 - 127.
            const int length = 127;
            
            DictionaryAssertions(RandomValue.Dictionary<sbyte, Guid>(length));
            DictionaryAssertions(RandomValue.Dictionary(typeof(sbyte), typeof(Guid), length)
                .ToDictionary(x => (sbyte)x.Key, y => (Guid)y.Value));

            void DictionaryAssertions(IDictionary<sbyte, Guid> dictionary)
            {
                for (var i = 0; i < length; i++)
                {
                    dictionary.ContainsKey((sbyte) i).ShouldBeTrue();
                }

                dictionary.Keys.First().ShouldBeType<sbyte>();
                dictionary.Values.First().ShouldBeType<Guid>();
            }
        }

        [TestMethod]
        public void AllItemsInTheKeysShouldBeUniqueForADictionaryNewSettingsObject()
        {
            //There should be keys from 1 - 127.
            const int length = 127;
            
            DictionaryAssertions(RandomValue.Dictionary<sbyte, Guid>(new RandomValueSettings { LengthOfCollection = length }));
            DictionaryAssertions(RandomValue.Dictionary(typeof(sbyte), typeof(Guid), new RandomValueSettings { LengthOfCollection = length })
                .ToDictionary(x => (sbyte)x.Key, y => (Guid)y.Value)); 

            void DictionaryAssertions(IDictionary<sbyte, Guid> dictionary)
            {
                for (var i = 0; i < length; i++)
                {
                    dictionary.ContainsKey((sbyte) i).ShouldBeTrue();
                }

                dictionary.Keys.First().ShouldBeType<sbyte>();
                dictionary.Values.First().ShouldBeType<Guid>();
            }
        }

        [TestMethod]
        public void TheLengthShouldBeBetween1and10ForDictionary()
        {
            DictionaryAssertions(RandomValue.Dictionary<long, sbyte>());
            DictionaryAssertions(RandomValue.Dictionary(typeof(long), typeof(sbyte))
                .ToDictionary(x => (long)x.Key, y => (sbyte)y.Value));

            void DictionaryAssertions(IDictionary<long, sbyte> dictionary)
            {
                dictionary.Count.ShouldBeInRange(1, 10);

                dictionary.Keys.First().ShouldBeType<long>();
                dictionary.Values.First().ShouldBeType<sbyte>();
            }
        }

        [TestMethod]
        public void TheValuesShouldBeUniqueForDictionary()
        {
            DictionaryAssertions(RandomValue.Dictionary<int, Guid>());
            DictionaryAssertions(RandomValue.Dictionary(typeof(int), typeof(Guid))
                .ToDictionary(x => (int)x.Key, y => (Guid)y.Value));

            void DictionaryAssertions(IDictionary<int, Guid> dictionary)
            {
                var distinctValues = dictionary.Values.Distinct();

                distinctValues.Count().ShouldEqual(dictionary.Count);

                dictionary.Keys.First().ShouldBeType<int>();
                dictionary.Values.First().ShouldBeType<Guid>();
            }
        }

        [TestMethod]
        public void AllItemsInTheKeysShouldBeUniqueForAIDictionary()
        {
            //There should be keys from 1 - 127.
            const int length = 127;

            DictionaryAssertions(RandomValue.IDictionary<sbyte, short>(length));
            DictionaryAssertions(RandomValue.IDictionary(typeof(sbyte), typeof(short), length)
                .ToDictionary(x => (sbyte)x.Key, y => (short)y.Value));

            void DictionaryAssertions(IDictionary<sbyte, short> dictionary)
            {
                for (var i = 0; i < length; i++)
                {
                    dictionary.ContainsKey((sbyte) i).ShouldBeTrue();
                }

                dictionary.Keys.First().ShouldBeType<sbyte>();
                dictionary.Values.First().ShouldBeType<short>();
            }
        }

        [TestMethod]
        public void TheLengthShouldBeBetween1and10ForIDictionary()
        {
            DictionaryAssertions(RandomValue.IDictionary<DateTime, sbyte>());
            DictionaryAssertions(RandomValue.IDictionary(typeof(DateTime), typeof(sbyte))
                .ToDictionary(x => (DateTime)x.Key, y => (sbyte)y.Value));

            void DictionaryAssertions(IDictionary<DateTime, sbyte> dictionary)
            {
                dictionary.Count.ShouldBeInRange(1, 10);

                dictionary.Keys.First().ShouldBeType<DateTime>();
                dictionary.Values.First().ShouldBeType<sbyte>();
            }
        }

        [TestMethod]
        public void TheValuesShouldBeUniqueForIDictionary()
        {
            DictionaryAssertions(RandomValue.IDictionary<TimeSpan, ulong>());
            DictionaryAssertions(RandomValue.IDictionary(typeof(TimeSpan), typeof(ulong))
                .ToDictionary(x => (TimeSpan)x.Key, y => (ulong)y.Value));

            void DictionaryAssertions(IDictionary<TimeSpan, ulong> dictionary)
            {
                var distinctValues = dictionary.Values.Distinct();

                distinctValues.Count().ShouldEqual(dictionary.Count);

                dictionary.Keys.First().ShouldBeType<TimeSpan>();
                dictionary.Values.First().ShouldBeType<ulong>();
            }
        }

        [TestMethod]
        public void TheValuesShouldBeUniqueForIDictionaryWithDateTimeOffset()
        {
            DictionaryAssertions(RandomValue.IDictionary<DateTimeOffset, ulong>());
            DictionaryAssertions(RandomValue.IDictionary(typeof(DateTimeOffset), typeof(ulong))
                .ToDictionary(x => (DateTimeOffset)x.Key, y => (ulong)y.Value));

            void DictionaryAssertions(IDictionary<DateTimeOffset, ulong> dictionary)
            {
                var distinctValues = dictionary.Values.Distinct();

                distinctValues.Count().ShouldEqual(dictionary.Count);

                dictionary.Keys.First().ShouldBeType<DateTimeOffset>();
                dictionary.Values.First().ShouldBeType<ulong>();
            }
        }
    }
}
