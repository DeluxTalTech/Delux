using Delux.Data.Treatment;
using Delux.Domain.Common;

namespace Delux.Domain.Treatment
{
    public sealed class FacialTreatment : Entity<FacialTreatmentData>
    {
        public FacialTreatment() : this(null) { }

        public FacialTreatment(FacialTreatmentData data) : base(data) { }
    }
}
