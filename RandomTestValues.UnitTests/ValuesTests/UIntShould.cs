using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class UIntShould
    {
        [TestMethod]
        public void ReturnSomethingDifferentWithEachCall()
        {
            var randomUInt1 = RandomValue.UInt();
            var randomUInt2 = RandomValue.UInt();

            randomUInt1.ShouldNotEqual(randomUInt2);
        }

        [TestMethod]
        public void ReturnValueWithinTheRangeOf0AndTheMaxValueProvided()
        {
            var randomUint = RandomValue.UInt(23);

            randomUint.ShouldBeInRange((uint)0, (uint)23);
        }
    }
}