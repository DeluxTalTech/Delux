using System.Collections.Generic;
using Delux.Data.Appointment;

namespace Delux.Data.Common
{
    public abstract class DurationData : PriceData
    {
        public string Duration { get; set; }
        //public ICollection<AppointmentData> Appointments { get; set; }
    }
}
