using System.Threading.Tasks;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Delux.Infra.Treatment
{
    public sealed class HairTreatmentsRepository : PaginatedRepository<HairTreatment, HairTreatmentData>, IHairTreatmentsRepository
    {
        public HairTreatmentsRepository(SalonDbContext c) : base(c, c.HairTreatments) { }

        protected internal override HairTreatment ToDomainObject(HairTreatmentData d) => new HairTreatment(d);

        protected override async Task<HairTreatmentData> GetData(string id)
        {
            return await DbSet.SingleOrDefaultAsync();
        }

        protected override string GetId(HairTreatment obj)
        {
            throw new System.NotImplementedException();
        }
    }
}