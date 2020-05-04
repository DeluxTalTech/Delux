using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Domain.Common
{
    [TestClass]
    public class EntityTests : AbstractClassTests<Entity<BeauticianData>, object>
    {
        private class TestClass : Entity<BeauticianData>
        {
            public TestClass(BeauticianData d = null) : base(d) { }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void DataTest()
        {
            var d = GetRandom.Object<BeauticianData>();
            Assert.AreNotSame(d, Obj.Data);
            Obj = new TestClass(d);
            Assert.AreSame(d, Obj.Data);
        }

        [TestMethod]
        public void DataIsNullTest()
        {
            var d = GetRandom.Object<BeauticianData>();
            Assert.IsNull(Obj.Data);
            Obj.Data = d;
            Assert.AreSame(d, Obj.Data);
        }

        [TestMethod]
        public void CanSetNullDataTest()
        {
            Obj.Data = null;
            Assert.IsNull(Obj.Data);
        }
    }
}
