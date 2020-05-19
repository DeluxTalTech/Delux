using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Delux.Data.Client;
using Delux.Domain.Client;
using Delux.Facade.Client;
using Delux.Pages.Client;
using Delux.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Pages.Client
{
    [TestClass]
    public class ClientsPageTests:AbstractClassTests<ClientsPage,
    CommonPage<IClientsRepository,global::Delux.Domain.Client.Client, ClientView,ClientData>>
    {
        private class TestClass : ClientsPage
        {
            internal TestClass(IClientsRepository t) : base(t) { }
        }

        private class ClientsRepository : BaseTestRepositoryForId<global::Delux.Domain.Client.Client, ClientData>, IClientsRepository { }

        private ClientsPageTests.ClientsRepository _clients;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _clients = new ClientsPageTests.ClientsRepository();
            Obj = new ClientsPageTests.TestClass(_clients);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<ClientView>();
            Obj.Item = item;
            Assert.AreEqual(item.Id, Obj.ItemId);
            Obj.Item = null;
            Assert.AreEqual(string.Empty, Obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Kliendid", Obj.PageTitle);


        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Salon/Clients", Obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<ClientView>();
            var o = Obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<ClientData>();
            var view = Obj.ToView(new global::Delux.Domain.Client.Client(d));
            TestArePropertyValuesEqual(view, d);
        }
    }
}
