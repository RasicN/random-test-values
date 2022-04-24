using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class DoubleShould
    {
        [TestMethod]
        public void RandomDoubleShouldReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomDouble1 = RandomValue.Double();
            var randomDouble2 = RandomValue.Double();

            randomDouble1.ShouldNotEqual(randomDouble2);
        }
    }
}