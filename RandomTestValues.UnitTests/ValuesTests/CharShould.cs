using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class CharShould
    {
        [TestMethod]
        public void ProducesAUniqueValueEachTimeItIsCalled()
        {
            var randomChar1 = RandomValue.Char();
            var randomChar2 = RandomValue.Char();

            randomChar1.ShouldNotEqual(randomChar2);
        }
    }
}