using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class ShortShould
    {
        [TestMethod]
        public void ReturnAUniqueNumberEachTimeItIsCalled()
        {
            var randomShort1 = RandomValue.Short();
            var randomShort2 = RandomValue.Short();

            randomShort1.ShouldNotEqual(randomShort2);
        }

        [TestMethod]
        public void RespectTheMaxValueSupplied()
        {
            var randomShort = RandomValue.Short(12);

            randomShort.ShouldBeInRange((short)0, (short)12);
        }
    }
}