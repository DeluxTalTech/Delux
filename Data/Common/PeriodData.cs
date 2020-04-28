using System;

namespace Delux.Data.Common
{
    public abstract class PeriodData : IdData
    {
        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }
    }
}
