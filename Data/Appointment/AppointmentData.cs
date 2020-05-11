using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Common;

namespace Delux.Data.Appointment
{
    public sealed class AppointmentData : IdData
    {
        public DateTime? AppointmentDate { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public string ClientId { get; set; }
        public string TreatmentId { get; set; }
        public string TechnicianId { get; set; }
    }
}
