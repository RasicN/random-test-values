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
        public void NullableValuesWillAlwaysBePopulatedWithObjectWhenNotAllowingNulls()
        {
            RandomValue.IncludeNullAsPossibleValueForNullables = false;
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
        public void NullableValuesWillSometimesBePopulatedWithNullWhenAllowingNulls()
        {
            RandomValue.IncludeNullAsPossibleValueForNullables = true;

            bool decimalWasNullAtleastOnce = false;
            bool doubleWasNullAtleastOnce = false;
            bool intWasNullAtleastOnce = false;
            bool intCollectionValueWasNullAtleastOnce = false;
            bool boolCollectionValueWasNullAtleastOnce = false;
            bool doubleListValueWasNullAtleastOnce = false;
            bool dateTimeWasNullAtleastOnce = false;
            bool guidWasNullAtleastOnce = false;
            bool enumListValueWasNullAtleastOnce = false;
            bool int2WasNullAtleastOnce = false;
            bool decimal2WasNullAtleastOnce = false;
            bool double2WasNullAtleastOnce = false;
            bool enumCollectionValueWasNullAtleastOnce = false;
            bool enumerableShortValueWasNullAtleastOnce = false;
            bool enumWasNullAtleastOnce = false;

            bool decimalWasNotNullAtleastOnce = false;
            bool doubleWasNotNullAtleastOnce = false;
            bool intWasNotNullAtleastOnce = false;
            bool intCollectionValueWasNotNullAtleastOnce = false;
            bool boolCollectionValueWasNotNullAtleastOnce = false;
            bool doubleListValueWasNotNullAtleastOnce = false;
            bool dateTimeWasNotNullAtleastOnce = false;
            bool guidWasNotNullAtleastOnce = false;
            bool enumListValueWasNotNullAtleastOnce = false;
            bool int2WasNotNullAtleastOnce = false;
            bool decimal2WasNotNullAtleastOnce = false;
            bool double2WasNotNullAtleastOnce = false;
            bool enumCollectionValueWasNotNullAtleastOnce = false;
            bool enumerableShortValueWasNotNullAtleastOnce = false;
            bool enumWasNotNullAtleastOnce = false;

            for ( int n = 0; n < 100; n++)
            {
                var testClass = RandomValue.Object<NullableTestObject>();

                decimalWasNullAtleastOnce |= testClass.RDecimal == null;
                doubleWasNullAtleastOnce |= testClass.RDouble == null;
                intWasNullAtleastOnce |= testClass.RInt == null;
                intCollectionValueWasNullAtleastOnce |= testClass.RCollection.Any(i => i == null);
                boolCollectionValueWasNullAtleastOnce |= testClass.RCollection2.Any(b => b == null);
                doubleListValueWasNullAtleastOnce |= testClass.RList.Any(d => d == null);
                dateTimeWasNullAtleastOnce |= testClass.RDateTime == null;
                guidWasNullAtleastOnce |= testClass.RGuid == null;
                enumListValueWasNullAtleastOnce |= testClass.REnumList.Any(e => e == null);
                int2WasNullAtleastOnce |= testClass.RInt2 == null;
                decimal2WasNullAtleastOnce |= testClass.RDecimal2 == null;
                double2WasNullAtleastOnce |= testClass.RDouble2 == null;
                enumCollectionValueWasNullAtleastOnce |= testClass.REnumCollection.Any(e => e == null);
                enumerableShortValueWasNullAtleastOnce |= testClass.Shorts.Any(s => s == null);
                enumWasNullAtleastOnce |= testClass.REnum == null;


                decimalWasNotNullAtleastOnce |= testClass.RDecimal != null;
                doubleWasNotNullAtleastOnce |= testClass.RDouble != null;
                intWasNotNullAtleastOnce |= testClass.RInt != null;
                intCollectionValueWasNotNullAtleastOnce |= testClass.RCollection.Any(i => i != null);
                boolCollectionValueWasNotNullAtleastOnce |= testClass.RCollection2.Any(b => b != null);
                doubleListValueWasNotNullAtleastOnce |= testClass.RList.Any(d => d != null);
                dateTimeWasNotNullAtleastOnce |= testClass.RDateTime != null;
                guidWasNotNullAtleastOnce |= testClass.RGuid != null;
                enumListValueWasNotNullAtleastOnce |= testClass.REnumList.Any(e => e != null);
                int2WasNotNullAtleastOnce |= testClass.RInt2 != null;
                decimal2WasNotNullAtleastOnce |= testClass.RDecimal2 != null;
                double2WasNotNullAtleastOnce |= testClass.RDouble2 != null;
                enumCollectionValueWasNotNullAtleastOnce |= testClass.REnumCollection.Any(e => e != null);
                enumerableShortValueWasNotNullAtleastOnce |= testClass.Shorts.Any(s => s != null);
                enumWasNotNullAtleastOnce |= testClass.REnum != null;
            }

            decimalWasNullAtleastOnce.ShouldBeTrue();
            doubleWasNullAtleastOnce.ShouldBeTrue();
            intWasNullAtleastOnce.ShouldBeTrue();
            intCollectionValueWasNullAtleastOnce.ShouldBeTrue();
            boolCollectionValueWasNullAtleastOnce.ShouldBeTrue();
            doubleListValueWasNullAtleastOnce.ShouldBeTrue();
            dateTimeWasNullAtleastOnce.ShouldBeTrue();
            guidWasNullAtleastOnce.ShouldBeTrue();
            enumListValueWasNullAtleastOnce.ShouldBeTrue();
            int2WasNullAtleastOnce.ShouldBeTrue();
            decimal2WasNullAtleastOnce.ShouldBeTrue();
            double2WasNullAtleastOnce.ShouldBeTrue();
            enumCollectionValueWasNullAtleastOnce.ShouldBeTrue();
            enumerableShortValueWasNullAtleastOnce.ShouldBeTrue();
            enumWasNullAtleastOnce.ShouldBeTrue();

            decimalWasNotNullAtleastOnce.ShouldBeTrue();
            doubleWasNotNullAtleastOnce.ShouldBeTrue();
            intWasNotNullAtleastOnce.ShouldBeTrue();
            intCollectionValueWasNotNullAtleastOnce.ShouldBeTrue();
            boolCollectionValueWasNotNullAtleastOnce.ShouldBeTrue();
            doubleListValueWasNotNullAtleastOnce.ShouldBeTrue();
            dateTimeWasNotNullAtleastOnce.ShouldBeTrue();
            guidWasNotNullAtleastOnce.ShouldBeTrue();
            enumListValueWasNotNullAtleastOnce.ShouldBeTrue();
            int2WasNotNullAtleastOnce.ShouldBeTrue();
            decimal2WasNotNullAtleastOnce.ShouldBeTrue();
            double2WasNotNullAtleastOnce.ShouldBeTrue();
            enumCollectionValueWasNotNullAtleastOnce.ShouldBeTrue();
            enumerableShortValueWasNotNullAtleastOnce.ShouldBeTrue();
            enumWasNotNullAtleastOnce.ShouldBeTrue();
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

        [TestMethod]
        public void RandomObjectWithRecursivePropertyWillGenerateChildObjectsToTheSpecifiedDepth()
        {
            var result = RandomValue.Object<ObjectWithRecursiveProperty>(recursiveDepth:2);

            // 1 level depth
            result.RecursiveProperty.ShouldNotBeDefault();
            result.RecursiveProperty2.ShouldNotBeDefault();

            // 2 level depth
            result.RecursiveProperty.RecursiveProperty.ShouldNotBeDefault();
            result.RecursiveProperty2.RecursiveProperty2.ShouldNotBeDefault();

            // 3 level depth (should now be null as recursiveDepth:2)
            result.RecursiveProperty.RecursiveProperty.RecursiveProperty.ShouldEqual(null);
            result.RecursiveProperty2.RecursiveProperty2.RecursiveProperty2.ShouldEqual(null);
            result.RecursiveProperty.RecursiveProperty.Int.ShouldNotBeDefault();
            result.RecursiveProperty2.RecursiveProperty2.Int.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomObjectWithRecursiveListWillGenerateChildObjectsToTheSpecifiedDepth()
        {
            var result = RandomValue.Object<ObjectWithRecursiveList>(recursiveDepth: 2);

            // 1 level depth
            result.RecursiveList.ShouldNotBeDefault();
            result.Int.ShouldNotBeDefault();

            // 2 level depth
            result.RecursiveList[0].RecursiveList.ShouldNotBeDefault();
            result.RecursiveList[0].Int.ShouldNotBeDefault();

            // 3 level depth (should now be null as recursiveDepth:2)
            result.RecursiveList[0].RecursiveList[0].RecursiveList.ShouldEqual(null);
            result.RecursiveList[0].RecursiveList[0].Int.ShouldNotBeDefault();
        }
    }
}
