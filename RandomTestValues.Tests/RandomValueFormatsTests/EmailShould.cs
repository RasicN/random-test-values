using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Formats;

namespace RandomTestValues.Tests.RandomValueFormatsTests
{
    [TestClass]
    public class EmailShould
    {
        [TestMethod]
        public void MatchAnEmailRegex()
        {
            // Act
            var result = RandomFormat.Email();

            // Assert
            Assert.IsTrue(IsValid(result), $"{result} is not a valid email address.");
        }

        private bool IsValid(string emailaddress)
        {
            var pattern = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");

            return pattern.IsMatch(emailaddress);
        }
    }
}
