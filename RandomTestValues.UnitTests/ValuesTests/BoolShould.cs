using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class BoolShould
    {
        [TestMethod]
        public void StatisticallyDistributed5050()
        {
            const int total = 1000000;
            var trueCases = Enumerable.Repeat(0, total).Count(i => RandomValue.Bool());
            var ratio = trueCases / (double)total;

            ratio.ShouldBeInRange(0.49, 0.51);
        }
    }
}