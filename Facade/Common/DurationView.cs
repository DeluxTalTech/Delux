using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Delux.Facade.Common
{
    public abstract class DurationView : PriceView
    {
        [Required] public double Duration { get; set; }
    }
}
