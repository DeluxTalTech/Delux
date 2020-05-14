using Delux.Data.Common;

namespace Delux.Data.Reservation
{
    public abstract class ClientData : IdData
    {
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
    }
}
