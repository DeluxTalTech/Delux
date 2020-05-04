using Delux.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Common
{
    [TestClass]
    public class DefinitionViewTests : AbstractClassTests<DefinitionView, NameView>
    {
        private class TestClass : DefinitionView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void DefinitionTest()
        {
            IsNullableProperty(() => Obj.Definition,x=>Obj.Definition=x);
        }
    }
}