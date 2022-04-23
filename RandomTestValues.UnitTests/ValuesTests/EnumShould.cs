using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.UnitTests.ShouldExtensions;
using RandomTestValues.UnitTests.Types;

namespace RandomTestValues.UnitTests.ValuesTests
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