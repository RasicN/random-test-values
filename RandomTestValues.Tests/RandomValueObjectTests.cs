using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using RandomTestValues.Tests.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace RandomTestValues.Tests
{
    [TestClass]
    public class RandomValueObjectTests
    {
        [TestMethod]
        public void RandomObjectOfSupportedValuesWillBePopulated()
        {
            InstanceAssertions(RandomValue.Object<TestObject>());
            InstanceAssertions((TestObject)RandomValue.Object(typeof(TestObject)));

            void InstanceAssertions(TestObject testInstance)
            {
                testInstance.RString.ShouldNotBeDefault();
                testInstance.RDecimal.ShouldNotBeDefault();
                testInstance.RDouble.ShouldNotBeDefault();
                testInstance.RInt.ShouldNotBeDefault();
                testInstance.RCollection.ShouldNotBeEmpty();
                testInstance.RCollection2.ShouldNotBeEmpty();
                testInstance.RList.ShouldNotBeEmpty();
                testInstance.RList2.ShouldNotBeEmpty();
                testInstance.TestObject2.ShouldNotBeDefault();
                testInstance.RTestObject2List.ShouldNotBeEmpty();
                testInstance.RDateTime.ShouldNotBeDefault();
                testInstance.RTestObject2Collection.ShouldNotBeEmpty();
                testInstance.RGuid.ShouldNotBeDefault();
                testInstance.REnumList.ShouldNotBeEmpty();
                testInstance.TestObject3.ShouldNotBeDefault();
                testInstance.RInt2.ShouldNotBeDefault();
                testInstance.RString2.ShouldNotBeDefault();
                testInstance.RDecimal2.ShouldNotBeDefault();
                testInstance.RDouble2.ShouldNotBeDefault();
                testInstance.REnumCollection.ShouldNotBeEmpty();
                testInstance.Shorts.ShouldNotBeEmpty();
                testInstance.Shorts.Count().ShouldBeInRange(0, 10);
                testInstance.Strings.ShouldNotBeEmpty();
                testInstance.RTestObject2Array.ShouldNotBeEmpty();
                testInstance.TimeSpan.ShouldNotBeDefault();
                testInstance.DateTimeOffset.ShouldNotEqual(new DateTimeOffset());
                testInstance.RUri.ShouldNotBeDefault();

                var isEnum = ((int) testInstance.REnum == (int) TestEnum.More
                              || (int) testInstance.REnum == (int) TestEnum.Most
                              || (int) testInstance.REnum == (int) TestEnum.Mostest
                              || (int) testInstance.REnum == (int) TestEnum.Mostestest);

                isEnum.ShouldBeTrue();
            }
        }

        [TestMethod]
        public void NullableValuesWillBePopulatedWithObject()
        {
            InstanceAssertions(RandomValue.Object<NullableTestObject>());
            InstanceAssertions((NullableTestObject)RandomValue.Object(typeof(NullableTestObject)));

            void InstanceAssertions(NullableTestObject testInstance)
            {
                testInstance.RDecimal.ShouldNotBeDefault();
                testInstance.RDouble.ShouldNotBeDefault();
                testInstance.RInt.ShouldNotBeDefault();
                testInstance.RCollection.ShouldNotBeEmpty();
                testInstance.RCollection2.ShouldNotBeEmpty();
                testInstance.RList.ShouldNotBeEmpty();
                testInstance.RDateTime.ShouldNotBeDefault();
                testInstance.RGuid.ShouldNotBeDefault();
                testInstance.REnumList.ShouldNotBeEmpty();
                testInstance.RInt2.ShouldNotBeDefault();
                testInstance.RDecimal2.ShouldNotBeDefault();
                testInstance.RDouble2.ShouldNotBeDefault();
                testInstance.REnumCollection.ShouldNotBeEmpty();
                testInstance.Shorts.ShouldNotBeEmpty();
                testInstance.Shorts.Count().ShouldBeInRange(0, 10);

                var isEnum = ((int) testInstance.REnum == (int) TestEnum.More
                              || (int) testInstance.REnum == (int) TestEnum.Most
                              || (int) testInstance.REnum == (int) TestEnum.Mostest
                              || (int) testInstance.REnum == (int) TestEnum.Mostestest);

                isEnum.ShouldBeTrue();
            }
        }

        [TestMethod]
        public void RandomObjectWillSupportACrazyCollectionOfCollections()
        {
            InstanceAssertions(RandomValue.Object<TestObject>());
            InstanceAssertions((TestObject)RandomValue.Object(typeof(TestObject)));

            void InstanceAssertions(TestObject testInstance)
            {
                var enumeration = testInstance.CrazyBools.ToArray();

                enumeration.Length.ShouldBeInRange(1, 10);
                enumeration.First().ShouldBeType<List<Collection<bool>>>();
            }
        }

        [TestMethod]
        public void RandomObjectOfSupportedValuesWillReturnNullForUnDeterminable()
        {
            InstanceAssertions(RandomValue.Object<TestObject>());
            InstanceAssertions((TestObject)RandomValue.Object(typeof(TestObject)));

            void InstanceAssertions(TestObject testInstance)
            {
                testInstance.TestObject2.RObject.ShouldBeType<object>();
            }
        }

        [TestMethod]
        public void RandomObjectOfSupportedValuesWillReturnGoodValuesInObjectsThatAreRecursivelyFound()
        {
            InstanceAssertions(RandomValue.Object<TestObject>());
            InstanceAssertions((TestObject)RandomValue.Object(typeof(TestObject)));

            void InstanceAssertions(TestObject testInstance)
            {
                testInstance.TestObject2.RObject.ShouldBeType<object>();
                testInstance.TestObject2.RInt2.ShouldNotBeDefault();
                testInstance.TestObject2.RString2.ShouldNotBeDefault();
                testInstance.TestObject2.RDouble2.ShouldNotBeDefault();
                testInstance.TestObject2.RDecimal2.ShouldNotBeDefault();
            }
        }

        [TestMethod]
        public void TheDictionaryShouldBeSetUpCorrectlyOnTheTestObject()
        {
            InstanceAssertions(RandomValue.Object<TestObject>());
            InstanceAssertions((TestObject)RandomValue.Object(typeof(TestObject)));

            void InstanceAssertions(TestObject testInstance)
            {
                testInstance.RDictionary.Count.ShouldBeGreaterThanOrEqualTo(1);
                testInstance.RDictionary.Keys.First().ShouldBeType<DateTime>();
                testInstance.RDictionary.Values.First().ShouldBeType<int>();
            }
        }

        [TestMethod]
        public void TheIDictionaryShouldBeSetUpCorrectlyOnTheTestObject()
        {
            InstanceAssertions(RandomValue.Object<TestObject>());
            InstanceAssertions((TestObject) RandomValue.Object(typeof(TestObject)));

            void InstanceAssertions(TestObject testInstance)
            {
                testInstance.RIDictionary.Count.ShouldBeGreaterThanOrEqualTo(1);
                testInstance.RIDictionary.Keys.First().ShouldBeType<TimeSpan>();
                testInstance.RIDictionary.Values.First().ShouldBeType<Collection<bool>>();
            }
        }

        [TestMethod]
        public void ThereShouldntBeAOutOfMemoryExceptionWhenAnObjectIsRecursive()
        {
            InstanceAssertions(RandomValue.Object<ObjectWithRecursiveProperty>());
            InstanceAssertions((ObjectWithRecursiveProperty)RandomValue.Object(typeof(ObjectWithRecursiveProperty)));

            void InstanceAssertions(ObjectWithRecursiveProperty testInstance)
            {
                testInstance.RecursiveProperty.ShouldEqual(null);
                testInstance.RecursiveProperty2.ShouldEqual(null);
                testInstance.Int.ShouldNotBeDefault();
            }
        }

        [TestMethod]
        public void RandomObjectWithRecursivePropertyWillGenerateChildObjectsToTheSpecifiedDepth()
        {
            InstanceAssertions(RandomValue.Object<ObjectWithRecursiveProperty>(recursiveDepth: 2));
            InstanceAssertions((ObjectWithRecursiveProperty)RandomValue.Object(typeof(ObjectWithRecursiveProperty), recursiveDepth: 2));

            void InstanceAssertions(ObjectWithRecursiveProperty testInstance)
            {
                // 1 level depth
                testInstance.RecursiveProperty.ShouldNotBeDefault();
                testInstance.RecursiveProperty2.ShouldNotBeDefault();

                // 2 level depth
                testInstance.RecursiveProperty.RecursiveProperty.ShouldNotBeDefault();
                testInstance.RecursiveProperty2.RecursiveProperty2.ShouldNotBeDefault();

                // 3 level depth (should now be null as recursiveDepth:2)
                testInstance.RecursiveProperty.RecursiveProperty.RecursiveProperty.ShouldEqual(null);
                testInstance.RecursiveProperty2.RecursiveProperty2.RecursiveProperty2.ShouldEqual(null);
                testInstance.RecursiveProperty.RecursiveProperty.Int.ShouldNotBeDefault();
                testInstance.RecursiveProperty2.RecursiveProperty2.Int.ShouldNotBeDefault();
            }
        }

        [TestMethod]
        public void RandomObjectWithRecursiveListWillGenerateChildObjectsToTheSpecifiedDepth()
        {
            InstanceAssertions(RandomValue.Object<ObjectWithRecursiveCollections>(recursiveDepth: 2));
            InstanceAssertions((ObjectWithRecursiveCollections)RandomValue.Object(typeof(ObjectWithRecursiveCollections), recursiveDepth: 2));

            void InstanceAssertions(ObjectWithRecursiveCollections testInstance)
            {
                // 1 level depth
                testInstance.RecursiveList.ShouldNotBeDefault();
                testInstance.Int.ShouldNotBeDefault();

                // 2 level depth
                testInstance.RecursiveList[0].RecursiveList.ShouldNotBeDefault();
                testInstance.RecursiveList[0].Int.ShouldNotBeDefault();

                // 3 level depth (should now be null as recursiveDepth:2)
                testInstance.RecursiveList[0].RecursiveList[0].RecursiveList.ShouldEqual(null);
                testInstance.RecursiveList[0].RecursiveList[0].Int.ShouldNotBeDefault();
            }
        }

        [TestMethod]
        public void RandomObjectWithRecursivePropertyWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            InstanceAssertions(RandomValue.Object<ObjectWithRecursiveProperty>(new RandomValueSettings { RecursiveDepth = 2 }));
            InstanceAssertions((ObjectWithRecursiveProperty)RandomValue.Object(typeof(ObjectWithRecursiveProperty), new RandomValueSettings { RecursiveDepth = 2 }));

            void InstanceAssertions(ObjectWithRecursiveProperty testInstance)
            {
                // 1 level depth
                testInstance.RecursiveProperty.ShouldNotBeDefault();
                testInstance.RecursiveProperty2.ShouldNotBeDefault();

                // 2 level depth
                testInstance.RecursiveProperty.RecursiveProperty.ShouldNotBeDefault();
                testInstance.RecursiveProperty2.RecursiveProperty2.ShouldNotBeDefault();

                // 3 level depth (should now be null as recursiveDepth:2)
                testInstance.RecursiveProperty.RecursiveProperty.RecursiveProperty.ShouldEqual(null);
                testInstance.RecursiveProperty2.RecursiveProperty2.RecursiveProperty2.ShouldEqual(null);
                testInstance.RecursiveProperty.RecursiveProperty.Int.ShouldNotBeDefault();
                testInstance.RecursiveProperty2.RecursiveProperty2.Int.ShouldNotBeDefault();
            }
        }

        [TestMethod]
        public void RandomObjectWithRecursiveListWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            InstanceAssertions(RandomValue.Object<ObjectWithRecursiveCollections>(new RandomValueSettings { RecursiveDepth = 2 }));
            InstanceAssertions((ObjectWithRecursiveCollections)RandomValue.Object(typeof(ObjectWithRecursiveCollections), new RandomValueSettings { RecursiveDepth = 2 }));

            void InstanceAssertions(ObjectWithRecursiveCollections testInstance)
            {
                // 1 level depth
                testInstance.RecursiveList.ShouldNotBeDefault();
                testInstance.Int.ShouldNotBeDefault();

                // 2 level depth
                testInstance.RecursiveList[0].RecursiveList.ShouldNotBeDefault();
                testInstance.RecursiveList[0].Int.ShouldNotBeDefault();

                // 3 level depth (should now be null as recursiveDepth:2)
                testInstance.RecursiveList[0].RecursiveList[0].RecursiveList.ShouldEqual(null);
                testInstance.RecursiveList[0].RecursiveList[0].Int.ShouldNotBeDefault();
            }
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
