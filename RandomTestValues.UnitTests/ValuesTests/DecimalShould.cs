using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class DecimalShould
    {
        [TestMethod]
        public void ReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomDecimal1 = RandomValue.Decimal();
            var randomDecimal2 = RandomValue.Decimal();

            randomDecimal1.ShouldNotEqual(randomDecimal2);
        }

        [TestMethod]
        public void ReturnValuesSmallerThanMaximumEveryTimeIsCalled()
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
        public void ReturnARelevantValueWhenCalledWithAMaximumDecimal()
        {
            var maxDecimal1 = 520.3m;
            var maxDecimal2 = 356.5m;

            var randomDecimal1 = RandomValue.Decimal(maxDecimal1);
            var randomDecimal2 = RandomValue.Decimal(maxDecimal2);

            randomDecimal1.ShouldBeGreaterThan(1);
            randomDecimal2.ShouldBeGreaterThan(1);
        }
    }
}