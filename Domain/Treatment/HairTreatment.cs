using Delux.Data.Treatment;
using Delux.Domain.Common;

namespace Delux.Domain.Treatment
{
    public sealed class HairTreatment : Entity<HairTreatmentData>
    {
        public HairTreatment() : this(null) { }

        public HairTreatment(HairTreatmentData data) : base(data) { }
    }
}
