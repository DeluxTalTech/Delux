using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Treatment
{
    [TestClass]
    public class FacialTreatmentViewFactoryTests:BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(FacialTreatmentViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<FacialTreatmentView>();
            var data = FacialTreatmentViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<FacialTreatmentData>();
            var view = FacialTreatmentViewFactory.Create(new FacialTreatment(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}
