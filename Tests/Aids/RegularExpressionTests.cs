using System.Text.RegularExpressions;
using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class RegularExpressionTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => Type = typeof(RegularExpressionFor);

        [TestMethod]
        public void EnglishCapitalsOnlyTest()
        {
            var match = RegularExpressionFor.EnglishCapitalsOnly;
            Assert.IsTrue(Regex.IsMatch("ABC", match));
            Assert.IsFalse(Regex.IsMatch("ABc", match));
            Assert.IsFalse(Regex.IsMatch("AB ", match));
            Assert.IsFalse(Regex.IsMatch("AB1", match));
        }

        [TestMethod]
        public void EnglishTextOnlyTest()
        {
            var match = RegularExpressionFor.EnglishTextOnly;
            Assert.IsTrue(Regex.IsMatch("ABC", match));
            Assert.IsTrue(Regex.IsMatch("ABc", match));
            Assert.IsTrue(Regex.IsMatch("AB ", match));
            Assert.IsTrue(Regex.IsMatch("AB'", match));
            Assert.IsTrue(Regex.IsMatch("AB\"", match));
            Assert.IsFalse(Regex.IsMatch("AB1", match));
            Assert.IsFalse(Regex.IsMatch("AB?", match));
            Assert.IsFalse(Regex.IsMatch("aBC", match));
        }

        [TestMethod]
        public void EnglishCapitalsAndNumbersOnlyTest()
        {
            var match = RegularExpressionFor.EnglishCapitalsAndNumbersOnly;
            Assert.IsTrue(Regex.IsMatch("ABC", match));
            Assert.IsFalse(Regex.IsMatch("ABc", match));
            Assert.IsFalse(Regex.IsMatch("AB ", match));
            Assert.IsFalse(Regex.IsMatch("AB'", match));
            Assert.IsFalse(Regex.IsMatch("AB\"", match));
            Assert.IsTrue(Regex.IsMatch("AB1", match));
            Assert.IsTrue(Regex.IsMatch("A12345", match));
            Assert.IsFalse(Regex.IsMatch("1AB", match));
            Assert.IsFalse(Regex.IsMatch("aBC", match));
        }
    }
}
