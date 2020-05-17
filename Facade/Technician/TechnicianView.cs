using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Delux.Facade.Common;

namespace Delux.Facade.Technician
{
    public sealed class TechnicianView : WorkedYearsView
    {
        [Required]
        [DisplayName("Category")]
        public string TechnicianTypeId { get; set; }
    }
}
