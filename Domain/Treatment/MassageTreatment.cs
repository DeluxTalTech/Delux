using Delux.Data.Treatment;
using Delux.Domain.Common;

namespace Delux.Domain.Treatment
{
    public sealed class MassageTreatment : Entity<MassageTreatmentData>
    {
        public MassageTreatment() : this(null) { }

        public MassageTreatment(MassageTreatmentData data) : base(data) { }
    }
}
