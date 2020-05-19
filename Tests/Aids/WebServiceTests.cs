using System.Net;
using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class WebServiceTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => Type = typeof(WebService);

        [TestMethod]
        public void LoadTest()
        {
            const string source1 = "https://docs.microsoft.com/";

            var webpage = new WebClient();

            Assert.AreEqual(webpage.DownloadString(source1), WebService.Load(source1));
        }
    }
}
