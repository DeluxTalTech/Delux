using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Common;

namespace Delux.Data.Technician
{
    public abstract class TechnicianData : WorkedYearsData
    {
        public string BeauticianId { get; set; }
        public string HairdresserId { get; set; }
        public string MasseuseId { get; set; }
        public string NailTechnicianId { get; set; }
    }
}
