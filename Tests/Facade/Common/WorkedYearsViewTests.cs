using Delux.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Common
{
    [TestClass]
    public class WorkedYearsViewTests : AbstractClassTests<WorkedYearsView, AvailabilityView>
    {
        private class TestClass : WorkedYearsView { }

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