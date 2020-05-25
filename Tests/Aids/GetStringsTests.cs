using Delux.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Aids
{
    [TestClass]
    public class GetStringsTests : BaseTests
    {
            [TestMethod]
            public void HeadTest()
            {
                static string Str() => GetRandom.String();
                var x = GetRandom.String();
                Assert.AreEqual(x, (x + '.' + Str() + '.' + Str()).GetHead());
                Assert.AreEqual(string.Empty, ((string)null).GetHead());
            }

            [TestMethod]
            public void TailTest()
            {
                static string Str() => GetRandom.String();
                var x = Str() + '.' + Str() + '.' + Str();
                Assert.AreEqual(x, (Str() + '.' + x).GetTail());
                Assert.AreEqual(string.Empty, ((string)null).GetTail());
            }

            [TestMethod]
            public void GetHeadTest()
            {
                static string Str() => GetRandom.String();
                var x = GetRandom.String();
                Assert.AreEqual(x, (x + '.' + Str() + '.' + Str()).GetHead());
                Assert.AreEqual(string.Empty, ((string)null).GetHead());
            }

            [TestMethod]
            public void GetTailTest()
            {
                static string Str() => GetRandom.String();
                var x = Str() + '.' + Str() + '.' + Str();
                Assert.AreEqual(x, (Str() + '.' + x).GetTail());
                Assert.AreEqual(string.Empty, ((string)null).GetTail());
            }
    }
}
