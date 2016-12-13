using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RandomTestValues.Tests
{

    [TestClass]
    public class FluentApiTests
    {
        private const string rString1 = "Thomas is PrettyAwesome";
        private const int rInt1 = 4654;
        private string[] strings = new string[0];

        [TestMethod]
        public void WhenUsingAFluentApiThePropertiesShouldBeSetCorrectly()
        {
            var newObject = RandomValue.Object(MakeTestObjectAValidUser());

            newObject.RInt.Should().Be(rInt1);
            newObject.RString.Should().Be(rString1);
            newObject.Strings.Should().BeSameAs(strings);
        }

        private System.Func<TestObject, TestObject> MakeTestObjectAValidUser()
        {
            return x => {
                x.RInt = rInt1;
                x.RString = rString1;
                x.Strings = strings;
                return x; };
        }
    }
}
