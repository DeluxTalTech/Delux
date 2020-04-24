using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Delux.Facade.Common
{
    public abstract class WorkedYearsView : AvailabilityView
    {
        [Required] public double WorkedYears { get; set; }
    }
}
