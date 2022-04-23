using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class FloatShould
    {
        [TestMethod]
        public void CreateUniqueValuesEachTimeItIsCalled()
        {
            var randomFloat1 = RandomValue.Float();
            var randomFloat2 = RandomValue.Float();

            randomFloat1.ShouldNotEqual(randomFloat2);
        }
    }
}