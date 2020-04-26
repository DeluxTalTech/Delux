using Delux.Domain.Technician;
using Delux.Data.Technician;
using Delux.Infra.Common;

namespace Delux.Infra.Technician
{
    public sealed class NailTechniciansRepository : IdRepository<NailTechnician, NailTechnicianData>, INailTechniciansRepository
    {

        public NailTechniciansRepository(SalonDbContext c) : base(c, c.NailTechnicians) { }

        protected internal override NailTechnician ToDomainObject(NailTechnicianData d) => new NailTechnician(d);

    }
}