using Delux.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Common
{
    [TestClass]
    public class WorkedYearsDataTests : AbstractClassTests<WorkedYearsData, AvailabilityData>
    {
        private class TestClass : WorkedYearsData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Obj = new TestClass();
        }

        [TestMethod]
        public void WorkedYearsTest()
        {
            IsNullableProperty(() => Obj.WorkedYears, x => Obj.WorkedYears = x);
        }
    }
}