using Delux.Data.Technician;
using Delux.Domain.Common;

namespace Delux.Domain.Technician
{
    public sealed class Beautician : Entity<BeauticianData>
    {
        public Beautician() : this(null) { }

        public Beautician(BeauticianData data) : base(data) { }
    }
}
