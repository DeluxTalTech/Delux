using Delux.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Common
{
    [TestClass]
    public class PeriodViewTests : AbstractClassTests<PeriodView, IdView>
    {
        private class TestClass : PeriodView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void ValidFromTest()
        {
            IsNullableProperty(() => Obj.ValidFrom, x => Obj.ValidFrom = x);
        }

        [TestMethod]
        public void ValidToTest()
        {
            IsNullableProperty(() => Obj.ValidTo, x => Obj.ValidTo = x);
        }
    }
}