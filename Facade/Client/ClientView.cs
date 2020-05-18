using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Delux.Facade.Common;

namespace Delux.Facade.Client
{
    public sealed class ClientView : NameView
    {
        [Required]
        [DisplayName("Telefoninumber")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("E-mail")]
        public string MailAddress { get; set; }
    }
}
