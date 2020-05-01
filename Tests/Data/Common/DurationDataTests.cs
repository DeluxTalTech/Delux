using Delux.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Common
{
    [TestClass]
    public class DurationDataTests : AbstractClassTests<DurationData, PriceData>
    {
        private class TestClass : DurationData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void DurationTest()
        {
            IsNullableProperty(() => Obj.Duration, x => Obj.Duration = x);
        }
    }
}