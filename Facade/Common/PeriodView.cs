﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class PeriodView : IdView
    {
        [DataType(DataType.Date)]
        [DisplayName("Valid from")]
        public DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Valid to")]
        public DateTime? ValidTo { get; set; }
    }
}
