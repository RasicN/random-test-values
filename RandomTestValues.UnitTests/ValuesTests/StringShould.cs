using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class StringShould
    {
        [TestMethod]
        public void ReturnSomethingDifferentEveryTimeItsCalled()
        {
            var randomString1 = RandomValue.String();
            var randomString2 = RandomValue.String();

            randomString1.ShouldNotEqual(randomString2);
        }

        [TestMethod]
        public void LimitLengthToMaxValuePassedIn()
        {
            var length = RandomValue.Int(500);
            var rs = RandomValue.String(length);

            Assert.AreEqual(length, rs.Length);
        }
    }
}