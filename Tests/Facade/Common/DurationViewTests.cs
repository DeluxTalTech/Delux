using Delux.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Common
{
    [TestClass]
    public class DurationViewTests : AbstractClassTests<DurationView, PriceView>
    {
        private class TestClass : DurationView { }

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