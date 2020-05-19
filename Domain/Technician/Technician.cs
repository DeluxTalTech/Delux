using Delux.Data.Technician;
using Delux.Domain.Common;

namespace Delux.Domain.Technician
{
    public sealed class Technician : Entity<TechnicianData>
    {
        public Technician() : this(null) { }

        public Technician(TechnicianData data) : base(data) { }
    }
}
