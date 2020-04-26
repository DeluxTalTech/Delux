using Delux.Domain.Technician;
using Delux.Data.Technician;
using Delux.Infra.Common;

namespace Delux.Infra.Technician
{
    public sealed class BeauticiansRepository : IdRepository<Beautician, BeauticianData>, IBeauticiansRepository
    {

        public BeauticiansRepository(SalonDbContext c) : base(c, c.Beauticians) { }

        protected internal override Beautician ToDomainObject(BeauticianData d) => new Beautician(d);

    }
}