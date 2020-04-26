using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class DurationView : PriceView
    {
        [Required] public double Duration { get; set; }
    }
}
