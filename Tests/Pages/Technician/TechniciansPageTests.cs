using System.Linq;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Delux.Pages.Common;
using Delux.Pages.Technician;
using Delux.Infra.Technician;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Technician
{
    [TestClass]
    public class TechniciansPageTests : AbstractClassTests<TechniciansPage,
        CommonPage<ITechniciansRepository, global::Delux.Domain.Technician.Technician, TechnicianView, TechnicianData>>
    {
        private class TestClass : TechniciansPage
        {
            internal TestClass(ITechniciansRepository t, ITechnicianTypesRepository tt) : base(t, tt) { }
        }

        private class TechnicianRepository : BaseTestRepositoryForId<global::Delux.Domain.Technician.Technician, TechnicianData>, ITechniciansRepository
        {
        }

        private class TechnicianTypesRepository : BaseTestRepositoryForId<TechnicianType, TechnicianTypeData>, ITechnicianTypesRepository
        {
        }
        private TechniciansRepository _technicians;
        private TechnicianTypesRepository _technicianTypes;
        private TechnicianTypeData _data;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _technicians = new TechniciansRepository();
            _technicianTypes = new TechnicianTypesRepository();
            _data = GetRandom.Object<TechnicianTypeData>();
            var t = new TechnicianType(_data);
            _technicianTypes.Add(t).GetAwaiter();
            AddRandomTreatmentTypes();
            Obj = new TestClass(_technicians, _technicianTypes);
        }

        private void AddRandomTreatmentTypes()
        {
            for (var i = 0; i < GetRandom.UInt8(3, 10); i++)
            {
                var d = GetRandom.Object<TechnicianTypeData>();
                var t = new TechnicianType(d);
                _technicianTypes.Add(t).GetAwaiter();
            }
        }

        [TestMethod]
        public void ItemIdTest()
        {
            //var item = GetRandom.Object<TechnicianView>();
            //Obj.Item = item;
            //Assert.AreEqual(item.GetId(), Obj.ItemId);
            //Obj.Item = null;
            //Assert.AreEqual(string.Empty, Obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Tehnikud", Obj.PageTitle);


        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Salon/Technicians", Obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<TechnicianView>();
            var o = Obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<TechnicianData>();
            var view = Obj.ToView(new global::Delux.Domain.Technician.Technician(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void GetTechnicianTypeNameTest()
        {
            var name = Obj.GetTechnicianTypeName(_data.Id);
            Assert.AreEqual(_data.Name, name);
        }

        [TestMethod]
        public void TechnicianTypesTest()
        {
            var list = _technicianTypes.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, Obj.TechnicianTypes.Count());
        }
    }
}
