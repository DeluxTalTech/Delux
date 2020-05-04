using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Treatment
{
    [TestClass]
    public class HairTreatmentViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(HairTreatmentViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<HairTreatmentView>();
            var data = HairTreatmentViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<HairTreatmentData>();
            var view = HairTreatmentViewFactory.Create(new HairTreatment(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}
