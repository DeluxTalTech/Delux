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
    public class MassageTreatmentsPageTests : AbstractClassTests<MassageTreatmentsPage,
        CommonPage<IMassageTreatmentsRepository, MassageTreatment, MassageTreatmentView, MassageTreatmentData>>
    {
        private class TestClass : MassageTreatmentsPage
        {
            internal TestClass(IMassageTreatmentsRepository r) : base(r) { }
        }

        private class TestRepository : BaseTestRepositoryForId<MassageTreatment, MassageTreatmentData>, IMassageTreatmentsRepository { }

        //private class TermRepository : BaseTestRepositoryForPeriodEntity<MeasureTerm, MeasureTermData>, IMeasureTermsRepository
        //{

        //    protected override bool IsThis(MeasureTerm entity, string id) => true;
        //    protected override string GetId(MeasureTerm entity) => string.Empty;
        //}

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var r = new MassageTreatmentsPageTests.TestRepository();
            // var t = new TermRepository();
            Obj = new MassageTreatmentsPageTests.TestClass(r);
            //Obj = new TestClass(r, t);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<MassageTreatmentView>();
            Obj.Item = item;
            Assert.AreEqual(item.Id, Obj.ItemId);
            Obj.Item = null;
            Assert.AreEqual(string.Empty, Obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Massage Treatments", Obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Salon/MassageTreatments", Obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<MassageTreatmentView>();
            var o = Obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<MassageTreatmentData>();
            var view = Obj.ToView(new MassageTreatment(data));
            TestArePropertyValuesEqual(view, data);
        }

        //[TestMethod]
        //public void LoadDetailsTest()
        //{
        //    var v = GetRandom.Object<MassageTreatmentView>();
        //    Obj.LoadDetails(v);
        //    Assert.IsNotNull(Obj.Terms);
        //}
        //[TestMethod] public void TermsTest() => IsReadOnlyProperty(Obj, nameof(Obj.Terms), Obj.Terms);
    }
}