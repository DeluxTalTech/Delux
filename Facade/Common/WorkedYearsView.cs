using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class WorkedYearsView : AvailabilityView
    {
        [Required] 
        [DisplayName("Töökogemus")]
        public string WorkedYears { get; set; }
    }
}
