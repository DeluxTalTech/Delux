using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Delux.Facade.Common;

namespace Delux.Facade.Treatment
{
    public sealed class TreatmentView : DurationView
    {
        [Required]
        [DisplayName("Kategooria")]
        public string TreatmentTypeId { get; set; }
    }
}
