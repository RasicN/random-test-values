using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class SByteShould
    {
        [TestMethod]
        public void ReturnSomethingDifferentMostOfTheTimeItIsCalled()
        {
            //Just comparing two would break occasionally. There are only 256 values in sbyte
            var randomBytes = new List<sbyte>();

            for (var i = 0; i < 20; i++)
            {
                randomBytes.Add(RandomValue.SByte());
            }

            var groupedbytes = randomBytes.GroupBy(x => x);
            groupedbytes.Count().ShouldBeGreaterThan(10);
        }

        [TestMethod]
        public void NotExceedTheMaximumValuePassedIn()
        {
            var randomByte = RandomValue.SByte(3);

            randomByte.ShouldBeInRange(0, 3);
        }
    }
}