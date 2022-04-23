using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class ULongShould
    {
        [TestMethod]
        public void ProductUniqueNumbersEachTimeItIsCalled()
        {
            var randomULong1 = RandomValue.ULong();
            var randomULong2 = RandomValue.ULong();

            randomULong1.ShouldNotEqual(randomULong2);
        }

        [TestMethod]
        public void ProduceSomeNumbersLargerThanMaxLong()
        {
            var randomULongs = new List<ulong>();

            for (var i = 0; i < 50; i++)
            {
                randomULongs.Add(RandomValue.ULong());
            }

            var numbersLargerThanMaxLong = randomULongs.Where(x => x > long.MaxValue);
            numbersLargerThanMaxLong.Any().ShouldBeTrue();
        }

        [TestMethod]
        public void RespectTheLargestNumberInput()
        {
            var randomULong = RandomValue.ULong(2000);

            randomULong.ShouldBeInRange((ulong)0, (ulong)2000);
        }
    }
}