using System.Collections.Generic;
using Delux.Data.Appointment;
using Delux.Data.Common;

namespace Delux.Data.Client
{
    public abstract class ClientData : NameData
    {
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public ICollection<AppointmentData> Appointments { get; set; }
    }
}
