using Delux.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Common
{
    [TestClass]
    public class PriceViewTests : AbstractClassTests<PriceView, PeriodView>
    {
        private class TestClass : PriceView { }

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