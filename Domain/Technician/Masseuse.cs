using Delux.Data.Technician;
using Delux.Domain.Common;

namespace Delux.Domain.Technician
{
    public sealed class Masseuse : Entity<MasseuseData>
    {
        public Masseuse() : this(null) { }

        public Masseuse(MasseuseData data) : base(data) { }
    }
}
