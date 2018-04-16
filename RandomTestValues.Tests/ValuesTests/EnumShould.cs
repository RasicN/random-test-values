using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;

namespace RandomTestValues.Tests.ValuesTests
{
    [TestClass]
    public class EnumShould
    {
        [TestMethod]
        public void ReturnAnEmumOfTheCorrectType()
        {
            var randomEnum = RandomValue.Enum<TestEnum>();

            randomEnum.ShouldBeType<TestEnum>();
        }
    }
}