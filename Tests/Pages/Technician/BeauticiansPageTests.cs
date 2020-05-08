using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Delux.Pages.Common;
using Delux.Pages.Technician;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Technician
{
    [TestClass]
    public class BeauticiansPageTests : AbstractClassTests<BeauticiansPage,
        CommonPage<IBeauticiansRepository, Beautician, BeauticianView, BeauticianData>>
    {
        private class TestClass : BeauticiansPage
        {
            internal TestClass(IBeauticiansRepository r) : base(r) { }
        }

        private class TestRepository : BaseTestRepositoryForId<Beautician, BeauticianData>, IBeauticiansRepository { }

        //private class TermRepository : BaseTestRepositoryForPeriodEntity<MeasureTerm, MeasureTermData>, IMeasureTermsRepository
        //{

        //    protected override bool IsThis(MeasureTerm entity, string id) => true;
        //    protected override string GetId(MeasureTerm entity) => string.Empty;
        //}

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var r = new TestRepository();
            // var t = new TermRepository();
            Obj = new TestClass(r);
            //Obj = new TestClass(r, t);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<BeauticianView>();
            Obj.Item = item;
            Assert.AreEqual(item.Id, Obj.ItemId);
            Obj.Item = null;
            Assert.AreEqual(string.Empty, Obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Beauticians", Obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Salon/Beauticians", Obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<BeauticianView>();
            var o = Obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<BeauticianData>();
            var view = Obj.ToView(new Beautician(data));
            TestArePropertyValuesEqual(view, data);
        }

        //[TestMethod]
        //public void LoadDetailsTest()
        //{
        //    var v = GetRandom.Object<FacialTreatmentView>();
        //    Obj.LoadDetails(v);
        //    Assert.IsNotNull(Obj.Terms);
        //}
        //[TestMethod] public void TermsTest() => IsReadOnlyProperty(Obj, nameof(Obj.Terms), Obj.Terms);
    }
}