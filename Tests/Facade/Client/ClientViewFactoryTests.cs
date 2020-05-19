using Delux.Aids;
using Delux.Data.Client;
using Delux.Facade.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Client
{
    [TestClass]
    public class ClientViewFactoryTests:BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(ClientViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ClientView>();
            var data = ClientViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ClientData>();
            var view = ClientViewFactory.Create(new global::Delux.Domain.Client.Client(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}
