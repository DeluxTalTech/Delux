using Delux.Aids;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Delux.Facade.Technician;
using Delux.Facade.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Technician
{
    [TestClass]
    public class TechnicianViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(TechnicianViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<TechnicianView>();
            var data = TechnicianViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<TechnicianData>();
            var view = TechnicianViewFactory.Create(new global::Delux.Domain.Technician.Technician(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}