using Delux.Data.Common;
using Delux.Data.Reservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Data.Reservation
{
    [TestClass]
    public class AppointmentDataTests:SealedClassTests<AppointmentData, IdData>
    {
         [TestMethod]
        public void ClientIdTest()
        {
            IsNullableProperty(() => Obj.ClientId, x => Obj.ClientId = x);
        }
        [TestMethod]
        public void TreatmentIdTest()
        {
            IsNullableProperty(() => Obj.TreatmentId, x => Obj.TreatmentId = x);
        }
        [TestMethod]
        public void TechnicianIdTest()
        {
            IsNullableProperty(() => Obj.TechnicianId, x => Obj.TechnicianId = x);
        }
        [TestMethod]
        public void AppointmentDateTimeTest()
        {
            IsNullableProperty(() => Obj.AppointmentDateTime, x => Obj.AppointmentDateTime = x);
        }
    }
}
