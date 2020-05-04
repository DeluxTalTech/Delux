using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Technician
{
    [TestClass]
    public class MasseuseViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(MasseuseViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<MasseuseView>();
            var data = MasseuseViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<MasseuseData>();
            var view = MasseuseViewFactory.Create(new Masseuse(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}