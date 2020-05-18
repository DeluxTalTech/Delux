using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class UseCultureTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => Type = typeof(UseCulture);

        [TestMethod]
        public void CurrentTest()
        {
            var current = CultureInfo.CurrentCulture;
            Assert.AreEqual(current, UseCulture.Current);
        }

        [TestMethod]
        public void EnglishTest()
        {
            var current = new CultureInfo("en-GB");
            Assert.AreEqual(current, UseCulture.English);
        }

        [TestMethod]
        public void InvariantTest()
        {
            var current = new CultureInfo("");
            Assert.AreEqual(current, UseCulture.Invariant);
        }
    }
}
