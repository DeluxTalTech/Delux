using Delux.Data.Common;
using Delux.Data.Technician;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Technician
{
    [TestClass]
    public class TechnicianDataTests : SealedClassTests<TechnicianData, DurationData>
    {
        [TestMethod]
        public void TechnicianTypeIdTest()
        {
            IsNullableProperty(() => Obj.TechnicianTypeId, x => Obj.TechnicianTypeId = x);
        }
    }
}