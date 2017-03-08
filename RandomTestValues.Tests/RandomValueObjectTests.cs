using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using RandomTestValues.Tests.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RandomTestValues.Tests
{
    [TestClass]
    public class RandomValueObjectTests
    {
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
            testClass.Shorts.ShouldNotBeEmpty();
            testClass.Shorts.Count().ShouldBeInRange(0, 10);
            testClass.Strings.ShouldNotBeEmpty();
            testClass.RTestObject2Array.ShouldNotBeEmpty();
            testClass.TimeSpan.ShouldNotBeDefault();
            testClass.DateTimeOffset.ShouldNotEqual(new DateTimeOffset());

            var isEnum = ((int)testClass.REnum == (int)TestEnum.More
                || (int)testClass.REnum == (int)TestEnum.Most
                || (int)testClass.REnum == (int)TestEnum.Mostest
                || (int)testClass.REnum == (int)TestEnum.Mostestest);

            isEnum.ShouldBeTrue();
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
            testClass.Shorts.ShouldNotBeEmpty();
            testClass.Shorts.Count().ShouldBeInRange(0, 10);

            var isEnum = ((int)testClass.REnum == (int)TestEnum.More
                || (int)testClass.REnum == (int)TestEnum.Most
                || (int)testClass.REnum == (int)TestEnum.Mostest
                || (int)testClass.REnum == (int)TestEnum.Mostestest);

            isEnum.ShouldBeTrue();
        }

        [TestMethod]
        public void RandomObjectWillSupportACrazyCollectionOfCollections()
        {
            var testClass = RandomValue.Object<TestObject>();

            var enumeration = testClass.CrazyBools;

            enumeration.Count().ShouldBeInRange(1, 10);
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

        [TestMethod]
        public void ThereShouldntBeAOutOfMemoryExceptionWhenAnObjectIsRecursive()
        {
            var result = RandomValue.Object<ObjectWithRecursiveProperty>();

            result.RecursiveProperty.ShouldEqual(null);
            result.RecursiveProperty2.ShouldEqual(null);
            result.Int.ShouldNotBeDefault();
        }
    }
}
