using Delux.Facade.Common;
using Delux.Facade.Technician;
using Delux.Facade.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Technician
{
    [TestClass]
    public class TechnicianViewTests : SealedClassTests<TechnicianView, WorkedYearsView>
    {
        [TestMethod]
        public void TechnicianTypeIdTest() => IsNullableProperty(() => Obj.TechnicianTypeId, x => Obj.TechnicianTypeId = x);

    }
}