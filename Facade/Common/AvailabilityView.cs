using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Delux.Facade.Common
{
    public abstract class AvailabilityView : IdView
    {
        [Required] public string[] AvailableDays { get; set; }
    }
}
