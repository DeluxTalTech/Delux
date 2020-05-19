using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Delux.Facade.Common;

namespace Delux.Facade.Technician
{
    public sealed class TechnicianView : WorkedYearsView
    {
        [Required]
        [DisplayName("Kategooria")]
        public string TechnicianTypeId { get; set; }
    }
}
