using Delux.Data.Technician;
using Delux.Domain.Common;

namespace Delux.Domain.Technician
{
    public sealed class HairDresser : Entity<HairdresserData>
    {
        public HairDresser() : this(null) { }

        public HairDresser(HairdresserData data) : base(data) { }
    }
}
