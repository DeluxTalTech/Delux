using Delux.Data.Client;
using Delux.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Client
{
    [TestClass]
    public class ClientDataTests:SealedClassTests<ClientData,NameData>
    {
        [TestMethod]
        public void PhoneNumberTest()
        {
            IsNullableProperty(() => Obj.PhoneNumber, x => Obj.PhoneNumber = x);
        }
        [TestMethod]
        public void MailAddressTest()
        {
            IsNullableProperty(() => Obj.MailAddress, x => Obj.MailAddress = x);
        }
    }
}
