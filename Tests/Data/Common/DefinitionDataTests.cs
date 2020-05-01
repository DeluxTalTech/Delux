using Delux.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Common
{
    [TestClass]
    public class DefinitionDataTests : AbstractClassTests<DefinitionData, NameData>
    {
        private class TestClass : DefinitionData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void DefinitionTest()
        {
            IsNullableProperty(() => Obj.Definition,x=> Obj.Definition= x);
        }
    }
}