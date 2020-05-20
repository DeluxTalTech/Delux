using Delux.Facade.Common;
using Delux.Facade.Treatment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Facade.Treatment
{
    [TestClass]
    public class TreatmentViewTests : SealedClassTests<TreatmentView, DurationView>
    {
        [TestMethod]
        public void TreatmentTypeIdTest() => IsNullableProperty(() => Obj.TreatmentTypeId, x => Obj.TreatmentTypeId = x);

        [TestMethod]
        public void GetIdTest()
        {
            var actual = Obj.GetId();
            var expected = $"{Obj.Id}.{Obj.TreatmentTypeId}";
            Assert.AreEqual(expected, actual);
        }
    }
}
