using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class TimeSpanShould
    {
        [TestMethod]
        public void GiveUniqueValuesForEachCall()
        {
            var timespan1 = RandomValue.TimeSpan();
            var timespan2 = RandomValue.TimeSpan();

            timespan1.ShouldNotEqual(timespan2);
        }
    }
}