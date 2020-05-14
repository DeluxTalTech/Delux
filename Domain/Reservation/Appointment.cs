using Delux.Data.Reservation;
using Delux.Domain.Common;

namespace Delux.Domain.Reservation
{
    public sealed class Appointment : Entity<AppointmentData>
    {
        public Appointment() : this(null) { }

        public Appointment(AppointmentData data) : base(data) { }
    }
}