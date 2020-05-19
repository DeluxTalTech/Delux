using Delux.Data.Technician;
using Delux.Domain.Common;

namespace Delux.Domain.Technician
{
    public sealed class TechnicianType : Entity<TechnicianTypeData>
    {
        public TechnicianType() : this(null) { }

        public TechnicianType(TechnicianTypeData data) : base(data) { }
    }
}
