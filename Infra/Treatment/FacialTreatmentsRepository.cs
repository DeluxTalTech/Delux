using System.Threading.Tasks;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Delux.Infra.Treatment
{
    public sealed class FacialTreatmentsRepository : PaginatedRepository<FacialTreatment, FacialTreatmentData>, IFacialTreatmentsRepository
    {
        public FacialTreatmentsRepository(SalonDbContext c) : base(c, c.FacialTreatments) { }

        protected internal override FacialTreatment ToDomainObject(FacialTreatmentData d) => new FacialTreatment(d);

        protected override async Task<FacialTreatmentData> GetData(string id)
        {
            return await DbSet.SingleOrDefaultAsync();
        }

        protected override string GetId(FacialTreatment obj)
        {
            throw new System.NotImplementedException();
        }
    }
}