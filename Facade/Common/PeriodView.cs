﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Delux.Facade.Common
{
    public abstract class PeriodView : DefinitionView
    {
        [DataType(DataType.Date)]
        [DisplayName("Valid from")]
        public DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Valid to")]
        public DateTime? ValidTo { get; set; }
    }
}