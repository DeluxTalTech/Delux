using System.Threading.Tasks;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Delux.Infra.Technician
{
    public sealed class TechniciansRepository : IdRepository<Domain.Technician.Technician, TechnicianData>, ITechniciansRepository
    {
        public TechniciansRepository() : this(null) { }

        public TechniciansRepository(SalonDbContext c) : base(c, c?.Technicians) { }

        protected internal override Domain.Technician.Technician ToDomainObject(TechnicianData d) => new Domain.Technician.Technician(d);

        protected override async Task<TechnicianData> GetData(string id)
        {
            var masterId = GetString.Head(id);
            var technicianTypeId = GetString.Tail(id);
            return await DbSet.SingleOrDefaultAsync(x => x.TechnicianTypeId == technicianTypeId && x.Id == masterId);
        }

        protected override string GetId(Domain.Technician.Technician obj)
        {
            return obj?.Data is null ? string.Empty : $"{obj.Data.Id}.{obj.Data.TechnicianTypeId}";
        }
    }
}
