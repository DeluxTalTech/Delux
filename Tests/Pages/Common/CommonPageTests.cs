﻿using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Delux.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Common {

    [TestClass]
    public class CommonPageTests
        : AbstractPageTests<CommonPage<IBeauticiansRepository, Beautician, BeauticianView, BeauticianData>
            , PaginatedPage<IBeauticiansRepository, Beautician, BeauticianView, BeauticianData>> {
       
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass(new TestRepository());
        }

        [TestMethod] public void ItemIdTest() {
            Obj.Item = GetRandom.Object<BeauticianView>();
            Assert.AreEqual(Obj.Item.Id, Obj.ItemId);
        }

        [TestMethod] public void PageTitleTest() {
            IsNullableProperty(()=> Obj.PageTitle, x => Obj.PageTitle = x);
        }

        [TestMethod] public void PageSubTitleTest() {
            IsReadOnlyProperty(Obj, nameof(Obj.PageSubTitle), Obj.GetPageSubTitle());
        }

        [TestMethod] public void GetPageSubtitleTest() {
            Assert.AreEqual(Obj.PageSubTitle, Obj.GetPageSubTitle());
        }

        [TestMethod] public void PageUrlTest() {
            IsReadOnlyProperty(Obj, nameof(Obj.PageUrl), Obj.GetPageUrl());
        }

        [TestMethod] public void GetPageUrlTest() {
            Assert.AreEqual(Obj.PageUrl, Obj.GetPageUrl());
        }

        [TestMethod] public void IndexUrlTest() {
            IsReadOnlyProperty(Obj, nameof(Obj.IndexUrl), Obj.GetIndexUrl());
        }

        [TestMethod] public void GetIndexUrlTest() {
            Assert.AreEqual(Obj.IndexUrl, Obj.GetIndexUrl());
        }

    }

}
