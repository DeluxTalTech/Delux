using Delux.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Common
{
    [TestClass]
    public class AvailabilityDataTests : AbstractClassTests<AvailabilityData, IdData>
    {
        private class TestClass : AvailabilityData { }

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