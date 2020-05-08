using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class DurationView : PriceView
    {
        [Required] public string Duration { get; set; }
    }
}
