using System.Threading.Tasks;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Delux.Infra.Treatment
{
    public sealed class NailTreatmentsRepository : PaginatedRepository<NailTreatment, NailTreatmentData>, INailTreatmentsRepository
    {
        public NailTreatmentsRepository(SalonDbContext c) : base(c, c.NailTreatments) { }

        protected internal override NailTreatment ToDomainObject(NailTreatmentData d) => new NailTreatment(d);

        protected override async Task<NailTreatmentData> GetData(string id)
        {
            return await DbSet.SingleOrDefaultAsync();
        }

        protected override string GetId(NailTreatment obj)
        {
            throw new System.NotImplementedException();
        }
    }
}