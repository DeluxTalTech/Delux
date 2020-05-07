﻿using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class AvailabilityView : IdView
    {
        [Required] public string AvailableDays { get; set; }
    }
}
