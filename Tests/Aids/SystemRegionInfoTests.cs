using System.Globalization;
using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class SystemRegionInfoTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(SystemRegionInfo);
        }

        [TestMethod]
        public void IsCountryTest()
        {
            Assert.IsFalse(SystemRegionInfo.IsCountry(null));
            TestEstonia();
            TestWorld();
        }

        private static void TestEstonia()
        {
            var r = new RegionInfo("et-EE");
            Assert.IsNotNull(r);
            Assert.IsTrue(SystemRegionInfo.IsCountry(r));
            Assert.AreEqual("Estonia", r.EnglishName);
        }

        private static void TestWorld()
        {
            var r = new RegionInfo("001");
            Assert.IsNotNull(r);
            Assert.IsFalse(SystemRegionInfo.IsCountry(r));
            Assert.AreEqual("World", r.EnglishName);
        }

    }
}
