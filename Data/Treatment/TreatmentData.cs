using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Common;

namespace Delux.Data.Treatment
{
    public abstract class TreatmentData : DurationData
    {
        public string TreatmentTypeId { get; set; }
    }
}
