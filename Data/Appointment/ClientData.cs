using Delux.Data.Common;

namespace Delux.Data.Appointment
{
    public abstract class ClientData : IdData
    {
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
    }
}
