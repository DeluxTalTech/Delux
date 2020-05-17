using Delux.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Common
{
    [TestClass]
    public class AvailabilityViewTests : AbstractClassTests<AvailabilityView, NameView>
    {
        private class TestClass : AvailabilityView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void AvailableDaysTest()
        {
            IsNullableProperty(() => Obj.AvailableDays, x => Obj.AvailableDays = x);
        }
    }
}