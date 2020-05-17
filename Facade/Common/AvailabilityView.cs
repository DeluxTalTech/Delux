using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class AvailabilityView : NameView
    {
        [Required] 
        [DisplayName("Workdays")]
        public string AvailableDays { get; set; }
    }
}
