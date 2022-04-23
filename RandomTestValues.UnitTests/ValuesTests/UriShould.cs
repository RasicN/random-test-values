using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class UriShould
    {
        [TestMethod]
        public void ReturnANewUriObjectWithARandomEndpoint()
        {
            var uri1 = RandomValue.Uri();
            var uri2 = RandomValue.Uri();

            uri1.ShouldNotEqual(uri2);
        }
    }
}