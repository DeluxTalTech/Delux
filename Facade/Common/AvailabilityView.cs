using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class AvailabilityView : DefinitionView
    {
        [Required] 
        [DisplayName("Workdays")]
        public string AvailableDays { get; set; }
    }
}
