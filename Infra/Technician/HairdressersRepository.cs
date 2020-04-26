using Delux.Domain.Technician;
using Delux.Data.Technician;
using Delux.Infra.Common;

namespace Delux.Infra.Technician
{
    public sealed class HairdressersRepository : IdRepository<HairDresser, HairdresserData>, IHairdressersRepository
    {

        public HairdressersRepository(SalonDbContext c) : base(c, c.Hairdressers) { }

        protected internal override HairDresser ToDomainObject(HairdresserData d) => new HairDresser(d);

    }
}