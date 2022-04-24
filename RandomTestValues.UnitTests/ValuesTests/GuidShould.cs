using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class GuidShould
    {
        [TestMethod]
        public void GiveUniqueValuesForEachCall()
        {
            var guid1 = RandomValue.Guid();
            var guid2 = RandomValue.Guid();

            guid1.ShouldNotEqual(guid2);
        }
    }
}