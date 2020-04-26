using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class PriceView : PeriodView
    {
        [Required] public int Price { get; set; }
    }
}
