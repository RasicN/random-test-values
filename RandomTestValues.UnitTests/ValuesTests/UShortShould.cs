using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class UShortShould
    {
        [TestMethod]
        public void GenerateANewNumberEachTimeItIsCalled()
        {
            var randomUShort1 = RandomValue.UShort();
            var randomUShort2 = RandomValue.UShort();

            randomUShort1.ShouldNotEqual(randomUShort2);
        }

        [TestMethod]
        public void RespectTheMaxValueSupplied()
        {
            var randomUShort = (short)RandomValue.UShort(12);
            
            randomUShort.ShouldBeInRange(0, 12);
        }
    }
}