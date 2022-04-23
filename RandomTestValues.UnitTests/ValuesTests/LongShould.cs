using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class LongShould
    {
        [TestMethod]
        public void RandomLongShouldGenerateANewNumberEachTimeItIsCalled()
        {
            var randomBrendan1 = RandomValue.Long();
            var randomBrendan2 = RandomValue.Long();

            randomBrendan1.ShouldNotEqual(randomBrendan2);
        }

        [TestMethod]
        public void RandomLongShouldRespectTheMaxValueSupplied()
        {
            var randomBrendan = RandomValue.Long(3000);

            randomBrendan.ShouldBeInRange(0, 3000);
        }
    }
}