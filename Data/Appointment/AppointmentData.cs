using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Common;

namespace Delux.Data.Appointment
{
    public sealed class AppointmentData : ClientData
    {
        public DateTime? AppointmentDate { get; set; }
        public DateTime? AppointmentTime { get; set; }
    }
}
