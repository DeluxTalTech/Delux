using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Delux.Facade.Common
{
    public abstract class PriceView : PeriodView
    {
        [Required] public int Price { get; set; }
    }
}
