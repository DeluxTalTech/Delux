using Delux.Domain.Technician;
using Delux.Data.Technician;
using Delux.Infra.Common;

namespace Delux.Infra.Technician
{
    public sealed class MasseusesRepository : IdRepository<Masseuse, MasseuseData>, IMasseusesRepository
    {

        public MasseusesRepository(SalonDbContext c) : base(c, c.Masseuses) { }

        protected internal override Masseuse ToDomainObject(MasseuseData d) => new Masseuse(d);

    }
}