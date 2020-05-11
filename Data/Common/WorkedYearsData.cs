using System.Collections.Generic;
using Delux.Data.Appointment;

namespace Delux.Data.Common
{
    public abstract class WorkedYearsData : AvailabilityData
    {
        public string WorkedYears { get; set; }
        public ICollection<AppointmentData> Appointments { get; set; }
    }
}
