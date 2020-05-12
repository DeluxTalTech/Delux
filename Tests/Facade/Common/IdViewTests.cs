using Delux.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Common
{
    [TestClass]
    public class IdViewTests : AbstractClassTests<IdView, object>
    {
        private class TestClass : IdView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void IdTest()
        {
            IsNullableProperty(() => Obj.Id, x => Obj.Id = x);
        }
    }
}