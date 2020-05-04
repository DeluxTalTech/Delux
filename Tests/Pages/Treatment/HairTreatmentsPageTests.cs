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
    public class HairTreatmentsPageTests : AbstractClassTests<HairTreatmentsPage,
        CommonPage<IHairTreatmentsRepository, HairTreatment, HairTreatmentView, HairTreatmentData>>
    {
        private class TestClass : HairTreatmentsPage
        {
            internal TestClass(IHairTreatmentsRepository r) : base(r) { }
        }

        private class TestRepository : BaseTestRepositoryForId<HairTreatment, HairTreatmentData>, IHairTreatmentsRepository { }

        //private class TermRepository : BaseTestRepositoryForPeriodEntity<MeasureTerm, MeasureTermData>, IMeasureTermsRepository
        //{

        //    protected override bool IsThis(MeasureTerm entity, string id) => true;
        //    protected override string GetId(MeasureTerm entity) => string.Empty;
        //}

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var r = new HairTreatmentsPageTests.TestRepository();
            // var t = new TermRepository();
            Obj = new HairTreatmentsPageTests.TestClass(r);
            //Obj = new TestClass(r, t);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<HairTreatmentView>();
            Obj.Item = item;
            Assert.AreEqual(item.Id, Obj.ItemId);
            Obj.Item = null;
            Assert.AreEqual(string.Empty, Obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Hair Treatments", Obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Salon/HairTreatments", Obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<HairTreatmentView>();
            var o = Obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<HairTreatmentData>();
            var view = Obj.ToView(new HairTreatment(data));
            TestArePropertyValuesEqual(view, data);
        }

        //[TestMethod]
        //public void LoadDetailsTest()
        //{
        //    var v = GetRandom.Object<HairTreatmentView>();
        //    Obj.LoadDetails(v);
        //    Assert.IsNotNull(Obj.Terms);
        //}
        //[TestMethod] public void TermsTest() => IsReadOnlyProperty(Obj, nameof(Obj.Terms), Obj.Terms);
    }
}