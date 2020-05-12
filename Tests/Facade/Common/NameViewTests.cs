using Delux.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Common
{
    [TestClass]
    public class NameViewTests : AbstractClassTests<NameView, IdView>
    {
        private class TestClass : NameView { }

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