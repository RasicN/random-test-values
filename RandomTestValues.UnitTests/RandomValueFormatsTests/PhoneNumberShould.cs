using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Formats;

namespace RandomTestValues.UnitTests.RandomValueFormatsTests
{
    [TestClass]
    public class PhoneNumberShould
    {
        [TestMethod]
        public void ReturnRandomPhoneNumber()
        {
            var phone1 = RandomFormat.PhoneNumber();
            var phone2 = RandomFormat.PhoneNumber();

            Assert.AreNotEqual(phone1, phone2);
        }

        [TestMethod]
        public void BeALengthOf10WhenNoFormatPassedIn()
        {
            // Act
            var result = RandomFormat.PhoneNumber();

            // Assert
            Assert.AreEqual(10, result.Length);
        }

        [TestMethod]
        public void BeOnlyDigitsWhenNoFormatPassedIn()
        {
            // Act
            var result = RandomFormat.PhoneNumber();

            // Assert
            long testLong;
            Assert.IsTrue(long.TryParse(result, out testLong), $"{result} is not only digits");
        }

        [TestMethod]
        public void FollowCorrectFormatForNorthAmericanNumberingPlan()
        {
            // Arrange
            var format = PhoneFormat.NANP;

            // Act
            var result = RandomFormat.PhoneNumber(format);

            // Assert
            var pattern = new Regex(@"^\d{3}-\d{3}-\d{4}$");
            Assert.IsTrue(pattern.Match(result).Success, $"{result} does not match pattern: {pattern.ToString()}");
        }
    }
}
