using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class ByteShould
    {
        [TestMethod]
        public void ReturnSomethingDifferentMostOfTheTimeItIsCalled()
        {
            //Just comparing two would break occasionally
            var randomBytes = new List<byte>();

            for (var i = 0; i < 20; i++)
            {
                randomBytes.Add(RandomValue.Byte());
            }

            var groupedbytes = randomBytes.GroupBy(x => x);
            groupedbytes.Count().ShouldBeGreaterThan(10);
        }

        [TestMethod]
        public void NotExceedTheMaximumValuePassedIn()
        {
            var randomByte = RandomValue.Byte(5);

            randomByte.ShouldBeInRange((byte)0, (byte)5);
        }
    }
}