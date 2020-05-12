using Delux.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Common
{
    [TestClass]
    public class NameDataTests : AbstractClassTests<NameData, IdData>
    {
        private class TestClass : NameData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void NameTest()
        {
            IsNullableProperty(() => Obj.Name, x => Obj.Name = x);
        }
    }
}