using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class DurationView : PriceView
    {
        [Required] 
        [DisplayName("Kestvus")]
        public string Duration { get; set; }
    }
}
