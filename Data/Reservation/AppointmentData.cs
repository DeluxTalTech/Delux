using System;
using Delux.Data.Common;

namespace Delux.Data.Reservation
{
    public sealed class AppointmentData : IdData
    {
        public string TreatmentId { get; set; }
        public string TechnicianId { get; set; }
        public string ClientId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? AppointmentTime { get; set; }
    }
}
