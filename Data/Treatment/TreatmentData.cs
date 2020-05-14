using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Common;

namespace Delux.Data.Treatment
{
    public abstract class TreatmentData : DurationData
    {
        public string FacialTreatmentId { get; set; }
        public string HairTreatmentId { get; set; }
        public string MassageTreatmentId { get; set; }
        public string NailTreatmentId { get; set; }
    }
}
