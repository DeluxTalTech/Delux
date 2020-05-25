using System.Linq;
using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Delux.Pages.Common;
using Delux.Pages.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Treatment
{
    [TestClass]
    public class TreatmentsPageTests : AbstractClassTests<TreatmentsPage,
        CommonPage<ITreatmentsRepository, global::Delux.Domain.Treatment.Treatment, TreatmentView, TreatmentData>>
    {
        private class TestClass : TreatmentsPage
        {
            internal TestClass(ITreatmentsRepository t, ITreatmentTypesRepository tt) : base(t, tt) { }
        }

        private class TreatmentsRepository : BaseTestRepositoryForId<global::Delux.Domain.Treatment.Treatment, TreatmentData>, ITreatmentsRepository
        {
        }

        private class TreatmentTypesRepository : BaseTestRepositoryForId<TreatmentType, TreatmentTypeData>, ITreatmentTypesRepository
        {
        }
        private TreatmentsRepository _treatments;
        private TreatmentTypesRepository _treatmenttypes;
        private TreatmentTypeData _data;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _treatments = new TreatmentsRepository();
            _treatmenttypes = new TreatmentTypesRepository();
            _data = GetRandom.Object<TreatmentTypeData>();
            var t = new TreatmentType(_data);
            _treatmenttypes.Add(t).GetAwaiter();
            AddRandomTreatmentTypes();
            Obj = new TestClass(_treatments, _treatmenttypes);
        }

        private void AddRandomTreatmentTypes()
        {
            for (var i = 0; i < GetRandom.UInt8(3, 10); i++)
            {
                var d = GetRandom.Object<TreatmentTypeData>();
                var t = new TreatmentType(d);
                _treatmenttypes.Add(t).GetAwaiter();
            }
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<TreatmentView>();
            Obj.Item = item;
            Assert.AreEqual(item.Id, Obj.ItemId);
            Obj.Item = null;
            Assert.AreEqual(string.Empty, Obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Hooldused", Obj.PageTitle);


        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Salon/Treatments", Obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<TreatmentView>();
            var o = Obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<TreatmentData>();
            var view = Obj.ToView(new global::Delux.Domain.Treatment.Treatment(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void GetTreatmentTypeNameTest()
        {
            var name = Obj.GetTreatmentTypeName(_data.Id);
            Assert.AreEqual(_data.Name, name);
        }

        [TestMethod]
        public void TreatmentTypesTest()
        {
            var list = _treatmenttypes.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, Obj.TreatmentTypes.Count());
        }
    }
}
