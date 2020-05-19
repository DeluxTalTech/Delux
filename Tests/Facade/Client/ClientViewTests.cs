using Delux.Facade.Client;
using Delux.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Client
{
    [TestClass]
    public class ClientViewTests:SealedClassTests<ClientView, NameView>
    {
        [TestMethod]
        public void PhoneNumberTest() => IsNullableProperty(() => Obj.PhoneNumber, x => Obj.PhoneNumber = x);
        [TestMethod]
        public void MailAddressTest() => IsNullableProperty(() => Obj.MailAddress, x => Obj.MailAddress = x);

    }
}
