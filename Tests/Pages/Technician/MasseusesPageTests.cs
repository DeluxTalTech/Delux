﻿using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Delux.Pages.Common;
using Delux.Pages.Technician;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Technician
{
    [TestClass]
    public class MasseusesPageTests : AbstractClassTests<MasseusesPage,
        CommonPage<IMasseusesRepository, Masseuse, MasseuseView, MasseuseData>>
    {
        private class TestClass : MasseusesPage
        {
            internal TestClass(IMasseusesRepository r) : base(r) { }
        }

        private class TestRepository : BaseTestRepositoryForId<Masseuse, MasseuseData>, IMasseusesRepository { }

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
            var item = GetRandom.Object<MasseuseView>();
            Obj.Item = item;
            Assert.AreEqual(item.Id, Obj.ItemId);
            Obj.Item = null;
            Assert.AreEqual(string.Empty, Obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Masseuses", Obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Salon/Masseuses", Obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<MasseuseView>();
            var o = Obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<MasseuseData>();
            var view = Obj.ToView(new Masseuse(data));
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