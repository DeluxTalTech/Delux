using Delux.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Common
{
    [TestClass]
    public class IdDataTests : AbstractClassTests<IdData, object>
    {
        private class TestClass : IdData { }

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