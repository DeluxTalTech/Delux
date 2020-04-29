using Delux.Data.Technician;
using Delux.Domain.Common;

namespace Delux.Domain.Technician
{
    public sealed class Hairdresser : Entity<HairdresserData>
    {
        public Hairdresser() : this(null) { }

        public Hairdresser(HairdresserData data) : base(data) { }
    }
}
