using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;

namespace RandomTestValues.UnitTests.ValuesTests
{
    [TestClass]
    public class DateTimeShould
    {
        [TestMethod]
        public void GiveUniqueValuesForEachCall()
        {
            var blindDate1 = RandomValue.DateTime();
            var blindDate2 = RandomValue.DateTime();

            blindDate1.ShouldNotEqual(blindDate2);
        }

        [TestMethod]
        public void GiveUniqueValuesForEachCallWithinGreaterThanMinValue()
        {
            var blindDate1 = RandomValue.DateTime(DateTime.Now.AddDays(-2));
            var blindDate2 = RandomValue.DateTime(DateTime.Now.AddDays(-800));

            blindDate1.ShouldNotEqual(blindDate2);
            blindDate1.ShouldBeGreaterThan(DateTime.Now.AddDays(-2));

            blindDate2.ShouldBeGreaterThan(DateTime.Now.AddDays(-800));
        }

        [TestMethod]
        public void GiveUniqueValuesForEachCallLessThanMaxValue()
        {
            var blindDate1 = RandomValue.DateTime(maxDateTime: DateTime.Now.AddDays(-2));
            var blindDate2 = RandomValue.DateTime(maxDateTime: DateTime.Now.AddDays(-800));

            blindDate1.ShouldNotEqual(blindDate2);
            blindDate1.ShouldBeLessThan(DateTime.Now.AddDays(-2));

            blindDate2.ShouldBeLessThan(DateTime.Now.AddDays(-800));
        }

        [TestMethod]
        public void GiveUniqueValuesForEachCallWithinRange()
        {
            var blindDate1 = RandomValue.DateTime(DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1));
            var blindDate2 = RandomValue.DateTime(DateTime.Now, DateTime.Now.AddDays(500));

            blindDate1.ShouldNotEqual(blindDate2);
            blindDate1.ShouldBeInRange(DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1));

            blindDate2.ShouldBeInRange(DateTime.Now, DateTime.Now.AddDays(500));
        }
    }
}