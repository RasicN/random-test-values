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
            testClass.RCollection.Count.ShouldBeGreaterThan(0);
            testClass.RCollection2.Count.ShouldBeGreaterThan(0);
            testClass.RList.Count.ShouldBeGreaterThan(0);
            testClass.RList2.Count.ShouldBeGreaterThan(0);
            testClass.TestObject2.ShouldNotBeDefault();
            testClass.RTestObject2List.Count.ShouldBeGreaterThan(0);
            testClass.RDateTime.ShouldNotBeDefault();
            testClass.RTestObject2Collection.Count.ShouldBeGreaterThan(0);
            testClass.RGuid.ShouldNotBeDefault();
            testClass.REnumList.Count.ShouldBeGreaterThan(0);
            testClass.TestObject3.ShouldNotBeDefault();
            testClass.RInt2.ShouldNotBeDefault();
            testClass.RString2.ShouldNotBeDefault();
            testClass.RDecimal2.ShouldNotBeDefault();
            testClass.RDouble2.ShouldNotBeDefault();
            testClass.REnumCollection.Count.ShouldBeGreaterThan(0);
            testClass.Shorts.Any().ShouldBeTrue();
            testClass.Shorts.Count().ShouldBeInRange(0, 10);
            testClass.Strings.Length.ShouldBeGreaterThan(0);
            testClass.RTestObject2Array.Length.ShouldBeGreaterThan(0);
            testClass.TimeSpan.ShouldNotBeDefault();
            testClass.DateTimeOffset.ShouldNotEqual(new DateTimeOffset());
            testClass.RUri.ShouldNotBeDefault();

            var isEnum = ((int)testClass.REnum == (int)TestEnum.More
                || (int)testClass.REnum == (int)TestEnum.Most
                || (int)testClass.REnum == (int)TestEnum.Mostest
                || (int)testClass.REnum == (int)TestEnum.Mostestest);

            isEnum.ShouldBeTrue();
        }

        [TestMethod]
        public void InstanceOfRandomObjectOfSupportedValuesWillBePopulated()
        {
            var testClass = new TestObject();
            RandomValue.Object<TestObject>(testClass);

            testClass.RString.ShouldNotBeDefault();
            testClass.RDecimal.ShouldNotBeDefault();
            testClass.RDouble.ShouldNotBeDefault();
            testClass.RInt.ShouldNotBeDefault();
            testClass.RCollection.Count.ShouldBeGreaterThan(0);
            testClass.RCollection2.Count.ShouldBeGreaterThan(0);
            testClass.RList.Count.ShouldBeGreaterThan(0);
            testClass.RList2.Count.ShouldBeGreaterThan(0);
            testClass.TestObject2.ShouldNotBeDefault();
            testClass.RTestObject2List.Count.ShouldBeGreaterThan(0);
            testClass.RDateTime.ShouldNotBeDefault();
            testClass.RTestObject2Collection.Count.ShouldBeGreaterThan(0);
            testClass.RGuid.ShouldNotBeDefault();
            testClass.REnumList.Count.ShouldBeGreaterThan(0);
            testClass.TestObject3.ShouldNotBeDefault();
            testClass.RInt2.ShouldNotBeDefault();
            testClass.RString2.ShouldNotBeDefault();
            testClass.RDecimal2.ShouldNotBeDefault();
            testClass.RDouble2.ShouldNotBeDefault();
            testClass.REnumCollection.Count.ShouldBeGreaterThan(0);
            testClass.Shorts.Any().ShouldBeTrue();
            testClass.Shorts.Count().ShouldBeInRange(0, 10);
            testClass.Strings.Length.ShouldBeGreaterThan(0);
            testClass.RTestObject2Array.Length.ShouldBeGreaterThan(0);
            testClass.TimeSpan.ShouldNotBeDefault();
            testClass.DateTimeOffset.ShouldNotEqual(new DateTimeOffset());
            testClass.RUri.ShouldNotBeDefault();

            var isEnum = ((int)testClass.REnum == (int)TestEnum.More
                || (int)testClass.REnum == (int)TestEnum.Most
                || (int)testClass.REnum == (int)TestEnum.Mostest
                || (int)testClass.REnum == (int)TestEnum.Mostestest);

            isEnum.ShouldBeTrue();
        }

        [TestMethod]
        public void InstanceOfRandomObjectWithoutAParameterlessConstructorWillBeRandomized()
        {
            var testInt = RandomValue.Int();
            var testString = RandomValue.String();
            var testClass = new TestObjectWithConstructor(testInt, testString);
            var result = RandomValue.Object(testClass);

            result.TestInt.Should().NotBe(testInt);
            result.TestString.Should().NotBe(testString);
            result.TestGuid.ShouldNotBeDefault();
        }

        [TestMethod]
        public void NullableValuesWillBePopulatedWithObject()
        {
            var testClass = RandomValue.Object<NullableTestObject>();

            testClass.RDecimal.ShouldNotBeDefault();
            testClass.RDouble.ShouldNotBeDefault();
            testClass.RInt.ShouldNotBeDefault();
            testClass.RCollection.Count.ShouldBeGreaterThan(0);
            testClass.RCollection2.Count.ShouldBeGreaterThan(0);
            testClass.RList.Count.ShouldBeGreaterThan(0);
            testClass.RDateTime.ShouldNotBeDefault();
            testClass.RGuid.ShouldNotBeDefault();
            testClass.REnumList.Count.ShouldBeGreaterThan(0);
            testClass.RInt2.ShouldNotBeDefault();
            testClass.RDecimal2.ShouldNotBeDefault();
            testClass.RDouble2.ShouldNotBeDefault();
            testClass.REnumCollection.Count.ShouldBeGreaterThan(0);
            testClass.Shorts.Any().ShouldBeTrue();
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

        [TestMethod]
        public void RandomObjectWithRecursivePropertyWillGenerateChildObjectsToTheSpecifiedDepth()
        {
            var result = RandomValue.Object<ObjectWithRecursiveProperty>(recursiveDepth: 2);

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
        public void InstanceOfRandomObjectWithRecursivePropertyWillGenerateChildObjectsToTheSpecifiedDepth()
        {
            var result = new ObjectWithRecursiveProperty(); 
            RandomValue.Object<ObjectWithRecursiveProperty>(result, recursiveDepth: 2);

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
            var result = RandomValue.Object<ObjectWithRecursiveCollections>(recursiveDepth: 2);

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

        [TestMethod]
        public void InstanceOfRandomObjectWithRecursiveListWillGenerateChildObjectsToTheSpecifiedDepth()
        {
            var result = new ObjectWithRecursiveCollections();
            RandomValue.Object<ObjectWithRecursiveCollections>(result, recursiveDepth: 2);

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

        [TestMethod]
        public void RandomObjectWithRecursivePropertyWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.Object<ObjectWithRecursiveProperty>(new RandomValueSettings { RecursiveDepth = 2 });

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
        public void InstanceOfRandomObjectWithRecursivePropertyWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = new ObjectWithRecursiveProperty();
            RandomValue.Object<ObjectWithRecursiveProperty>(result, new RandomValueSettings { RecursiveDepth = 2 });

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
        public void RandomObjectWithRecursiveListWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.Object<ObjectWithRecursiveCollections>(new RandomValueSettings { RecursiveDepth = 2 });

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

        [TestMethod]
        public void InstanceOfRandomObjectWithRecursiveListWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = new ObjectWithRecursiveCollections();
            RandomValue.Object<ObjectWithRecursiveCollections>(result, new RandomValueSettings { RecursiveDepth = 2 });

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

        [TestMethod]
        public void NullableValuesWillSometimesBePopulatedWithNullWhenAllowingNulls()
        {
            var decimalWasNullAtleastOnce = false;
            var doubleWasNullAtleastOnce = false;
            var intWasNullAtleastOnce = false;
            var dateTimeWasNullAtleastOnce = false;
            var guidWasNullAtleastOnce = false;
            var int2WasNullAtleastOnce = false;
            var decimal2WasNullAtleastOnce = false;
            var double2WasNullAtleastOnce = false;
            var enumWasNullAtleastOnce = false;


            var settings = new RandomValueSettings { IncludeNullAsPossibleValueForNullables = true };

            for (int n = 0; n < 100; n++)
            {
                var testClass = RandomValue.Object<NullableTestObject>(settings);

                decimalWasNullAtleastOnce |= testClass.RDecimal == null;
                doubleWasNullAtleastOnce |= testClass.RDouble == null;
                intWasNullAtleastOnce |= testClass.RInt == null;
                dateTimeWasNullAtleastOnce |= testClass.RDateTime == null;
                guidWasNullAtleastOnce |= testClass.RGuid == null;
                int2WasNullAtleastOnce |= testClass.RInt2 == null;
                decimal2WasNullAtleastOnce |= testClass.RDecimal2 == null;
                double2WasNullAtleastOnce |= testClass.RDouble2 == null;
                enumWasNullAtleastOnce |= testClass.REnum == null;
            }

            decimalWasNullAtleastOnce.ShouldBeTrue();
            doubleWasNullAtleastOnce.ShouldBeTrue();
            intWasNullAtleastOnce.ShouldBeTrue();
            dateTimeWasNullAtleastOnce.ShouldBeTrue();
            guidWasNullAtleastOnce.ShouldBeTrue();
            int2WasNullAtleastOnce.ShouldBeTrue();
            decimal2WasNullAtleastOnce.ShouldBeTrue();
            double2WasNullAtleastOnce.ShouldBeTrue();
            enumWasNullAtleastOnce.ShouldBeTrue();
        }

        [TestMethod]
        public void NullableValuesWillSometimesNotBePopulatedWithNullWhenAllowingNulls()
        {
            var decimalWasNotNullAtleastOnce = false;
            var doubleWasNotNullAtleastOnce = false;
            var intWasNotNullAtleastOnce = false;
            var int2WasNotNullAtleastOnce = false;
            var decimal2WasNotNullAtleastOnce = false;
            var dateTimeWasNotNullAtleastOnce = false;
            var guidWasNotNullAtleastOnce = false;
            var double2WasNotNullAtleastOnce = false;
            var enumWasNotNullAtleastOnce = false;

            var settings = new RandomValueSettings { IncludeNullAsPossibleValueForNullables = true };

            for (int n = 0; n < 100; n++)
            {
                var testClass = RandomValue.Object<NullableTestObject>(settings);

                decimalWasNotNullAtleastOnce |= testClass.RDecimal != null;
                doubleWasNotNullAtleastOnce |= testClass.RDouble != null;
                intWasNotNullAtleastOnce |= testClass.RInt != null;
                dateTimeWasNotNullAtleastOnce |= testClass.RDateTime != null;
                guidWasNotNullAtleastOnce |= testClass.RGuid != null;
                int2WasNotNullAtleastOnce |= testClass.RInt2 != null;
                decimal2WasNotNullAtleastOnce |= testClass.RDecimal2 != null;
                double2WasNotNullAtleastOnce |= testClass.RDouble2 != null;
                enumWasNotNullAtleastOnce |= testClass.REnum != null;
            }

            decimalWasNotNullAtleastOnce.ShouldBeTrue();
            doubleWasNotNullAtleastOnce.ShouldBeTrue();
            intWasNotNullAtleastOnce.ShouldBeTrue();
            dateTimeWasNotNullAtleastOnce.ShouldBeTrue();
            guidWasNotNullAtleastOnce.ShouldBeTrue();
            int2WasNotNullAtleastOnce.ShouldBeTrue();
            decimal2WasNotNullAtleastOnce.ShouldBeTrue();
            double2WasNotNullAtleastOnce.ShouldBeTrue();
            enumWasNotNullAtleastOnce.ShouldBeTrue();
        }

        [TestMethod]
        public void NullableCollectionsWillSometimesNotBePopulatedWithNullWhenAllowingNulls()
        {
            var intCollectionValueWasNotNullAtleastOnce = false;
            var boolCollectionValueWasNotNullAtleastOnce = false;
            var doubleListValueWasNotNullAtleastOnce = false;
            var enumListValueWasNotNullAtleastOnce = false;
            var enumCollectionValueWasNotNullAtleastOnce = false;
            var enumerableShortValueWasNotNullAtleastOnce = false;

            var settings = new RandomValueSettings { IncludeNullAsPossibleValueForNullables = true };

            for (int n = 0; n < 100; n++)
            {
                var testClass = RandomValue.Object<NullableTestObject>(settings);

                enumCollectionValueWasNotNullAtleastOnce |= testClass.REnumCollection.Any(e => e != null);
                enumerableShortValueWasNotNullAtleastOnce |= testClass.Shorts.Any(s => s != null);
                intCollectionValueWasNotNullAtleastOnce |= testClass.RCollection.Any(i => i != null);
                boolCollectionValueWasNotNullAtleastOnce |= testClass.RCollection2.Any(b => b != null);
                doubleListValueWasNotNullAtleastOnce |= testClass.RList.Any(d => d != null);
                enumListValueWasNotNullAtleastOnce |= testClass.REnumList.Any(e => e != null);
            }

            enumListValueWasNotNullAtleastOnce.ShouldBeTrue();
            enumCollectionValueWasNotNullAtleastOnce.ShouldBeTrue();
            enumerableShortValueWasNotNullAtleastOnce.ShouldBeTrue();
            intCollectionValueWasNotNullAtleastOnce.ShouldBeTrue();
            boolCollectionValueWasNotNullAtleastOnce.ShouldBeTrue();
            doubleListValueWasNotNullAtleastOnce.ShouldBeTrue();
        }

        [TestMethod]
        public void NullableCollectionsWillSometimesBePopulatedWithNullWhenAllowingNulls()
        {
            var intCollectionValueWasNullAtleastOnce = false;
            var boolCollectionValueWasNullAtleastOnce = false;
            var doubleListValueWasNullAtleastOnce = false;
            var enumListValueWasNullAtleastOnce = false;
            var enumCollectionValueWasNullAtleastOnce = false;
            var enumerableShortValueWasNullAtleastOnce = false;

            var settings = new RandomValueSettings { IncludeNullAsPossibleValueForNullables = true };

            for (int n = 0; n < 100; n++)
            {
                var testClass = RandomValue.Object<NullableTestObject>(settings);

                intCollectionValueWasNullAtleastOnce |= testClass.RCollection.Any(i => i == null);
                boolCollectionValueWasNullAtleastOnce |= testClass.RCollection2.Any(b => b == null);
                doubleListValueWasNullAtleastOnce |= testClass.RList.Any(d => d == null);
                enumCollectionValueWasNullAtleastOnce |= testClass.REnumCollection.Any(e => e == null);
                enumerableShortValueWasNullAtleastOnce |= testClass.Shorts.Any(s => s == null);
                enumListValueWasNullAtleastOnce |= testClass.REnumList.Any(e => e == null);

            }

            enumListValueWasNullAtleastOnce.ShouldBeTrue();
            enumCollectionValueWasNullAtleastOnce.ShouldBeTrue();
            enumerableShortValueWasNullAtleastOnce.ShouldBeTrue();
            boolCollectionValueWasNullAtleastOnce.ShouldBeTrue();
            intCollectionValueWasNullAtleastOnce.ShouldBeTrue();
            doubleListValueWasNullAtleastOnce.ShouldBeTrue();
        }

        [TestMethod]
        public void IgnoreExtensionDataObject()
        {
            var result = RandomValue.Object<TestObjectWithExtensionDataObject>();
         
            result.String1.ShouldNotBeDefault();
        }

        [TestMethod]
        public void CircularObjectsObeyRecursionLimit()
        {
            //var result = RandomValue.Object<CircularTypes1>(3);

            //result.CircularType2.CircularType1.CircularType2.ShouldEqual(null);
        }

    }
}
