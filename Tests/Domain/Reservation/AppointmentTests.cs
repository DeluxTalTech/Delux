using Delux.Data.Reservation;
using Delux.Domain.Common;
using Delux.Domain.Reservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Delux.Tests.Domain.Reservation
{
    [TestClass]
    public class AppointmentTests:SealedClassTests<Appointment,Entity<AppointmentData>>
    {
    }
}
