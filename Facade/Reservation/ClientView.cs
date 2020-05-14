using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Delux.Facade.Common;

namespace Delux.Facade.Reservation
{
    public abstract class ClientView : IdView
    {
        [Required] 
        [DisplayName("Client name")]
        public string ClientName { get; set; }
        [Required]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("E-mail")]
        public string MailAddress { get; set; }
    }
}
