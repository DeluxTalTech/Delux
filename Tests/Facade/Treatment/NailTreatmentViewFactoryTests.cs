using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Treatment
{
    [TestClass]
    public class NailTreatmentViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(NailTreatmentViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<NailTreatmentView>();
            var data = NailTreatmentViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<NailTreatmentData>();
            var view = NailTreatmentViewFactory.Create(new NailTreatment(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}
