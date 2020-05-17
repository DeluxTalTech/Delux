using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Common;

namespace Delux.Data.Technician
{
    public abstract class TechnicianData : WorkedYearsData
    {
        public string TechnicianTypeId { get; set; }
    }
}
