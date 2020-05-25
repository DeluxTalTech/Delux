using System;
using Delux.Data.Common;

namespace Delux.Data.Reservation
{
    public sealed class AppointmentData : IdData
    {
        public string ClientId { get; set; }
        public string TreatmentId { get; set; }
        public string TechnicianId { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
    }
}
