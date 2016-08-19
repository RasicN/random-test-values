using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using Should;

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
        public void RandomDoubleShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomDouble1 = RandomTestValues.Double();
            var randomDouble2 = RandomTestValues.Double();

            randomDouble1.ShouldNotEqual(randomDouble2);
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
