using Delux.Data.Treatment;
using Delux.Domain.Common;

namespace Delux.Domain.Treatment
{
    public sealed class TreatmentType : Entity<TreatmentTypeData>
    {
        public TreatmentType() : this(null) { }

        public TreatmentType(TreatmentTypeData data) : base(data) { }
    }
}
