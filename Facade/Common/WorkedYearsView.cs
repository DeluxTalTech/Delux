using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class WorkedYearsView : AvailabilityView
    {
        [Required] public double WorkedYears { get; set; }
    }
}
