using System;

namespace Delux.Data.Reservation
{
    public sealed class AppointmentData : ClientData
    {
        public string TreatmentId { get; set; }
        public string TechnicianId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? AppointmentTime { get; set; }
    }
}
