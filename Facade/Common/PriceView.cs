using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class PriceView : PeriodView
    {
        [Required] 
        [DisplayName("Hind")]
        public string Price { get; set; }
    }
}
