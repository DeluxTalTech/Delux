using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class AvailabilityView : DefinitionView
    {
        [Required] public string AvailableDays { get; set; }
    }
}
