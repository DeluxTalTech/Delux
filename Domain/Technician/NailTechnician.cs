using Delux.Data.Technician;
using Delux.Domain.Common;

namespace Delux.Domain.Technician
{
    public sealed class NailTechnician : Entity<NailTechnicianData>
    {
        public NailTechnician() : this(null) { }

        public NailTechnician(NailTechnicianData data) : base(data) { }
    }
}
