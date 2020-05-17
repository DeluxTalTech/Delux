using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Delux.Facade.Common;

namespace Delux.Facade.Client
{
    public abstract class ClientView : NameView
    {
        [Required]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("E-mail")]
        public string MailAddress { get; set; }
    }
}
