using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class IntShould
    {
        [TestMethod]
        public void ReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomInt1 = RandomValue.Int();
            var randomInt2 = RandomValue.Int();

            randomInt1.ShouldNotEqual(randomInt2);
        }

        [TestMethod]
        public void NotExceedMaximumValuePassedIn()
        {
            var randomInt = RandomValue.Int(4);

            randomInt.ShouldBeInRange(0, 4);
        }

        [TestMethod]
        public void ReturnAPositiveNumberIfANegativeMaxIsPassedIn()
        {
            var randomInt = RandomValue.Int(-4);

            randomInt.ShouldBeInRange(0, 4);
        }

        [TestMethod]
        public void BeWithinRangesOfMinimumANdMaximumPossibleValuesPassedIn()
        {
            var randomInt = RandomValue.Int(1000, 990);
            var randomInt2 = RandomValue.Int(10000, 9000);
            var randomInt3 = RandomValue.Int(10, 9);

            randomInt.ShouldBeInRange(990, 1000);
            randomInt2.ShouldBeInRange(9000, 10000);
            randomInt3.ShouldBeInRange(9, 10);
        }

        [TestMethod]
        public void OmitMinumumossibleValueIfIsHigherThanTheMaximumExpected()
        {
            var randomInt = RandomValue.Int(5, 15);
            var randomInt2 = RandomValue.Int(10, 200);
            var randomInt3 = RandomValue.Int(100, 30000);

            randomInt.ShouldBeInRange(0, 5);
            randomInt2.ShouldBeInRange(0, 10);
            randomInt3.ShouldBeInRange(0, 100);
        }

        [TestMethod]
        public void OmitMinumumossibleValueIfIsLowerThan0()
        {
            var randomInt = RandomValue.Int(5, -15);
            var randomInt2 = RandomValue.Int(10, -200);
            var randomInt3 = RandomValue.Int(100, -30000);

            randomInt.ShouldBeInRange(0, 5);
            randomInt2.ShouldBeInRange(0, 10);
            randomInt3.ShouldBeInRange(0, 100);
        }


    }
}