using Delux.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Common
{
    [TestClass]
    public class PriceDataTests : AbstractClassTests<PriceData, PeriodData>
    {
        private class TestClass : PriceData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void PriceTest()
        {
            IsNullableProperty(() => Obj.Price, x => Obj.Price = x);
        }
    }
}