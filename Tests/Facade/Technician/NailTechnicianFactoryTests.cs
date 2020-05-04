using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Technician
{
    [TestClass]
    public class NailTechnicianViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(NailTechnicianViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<NailTechnicianView>();
            var data = NailTechnicianViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<NailTechnicianData>();
            var view = NailTechnicianViewFactory.Create(new NailTechnician(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}