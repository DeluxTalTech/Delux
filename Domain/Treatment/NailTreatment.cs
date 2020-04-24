using Delux.Data.Treatment;
using Delux.Domain.Common;

namespace Delux.Domain.Treatment
{
    public sealed class NailTreatment : Entity<NailTreatmentData>
    {
        public NailTreatment() : this(null) { }

        public NailTreatment(NailTreatmentData data) : base(data) { }
    }
}
