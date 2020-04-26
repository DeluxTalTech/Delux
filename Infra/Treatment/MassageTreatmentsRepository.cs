using System.Threading.Tasks;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Delux.Infra.Treatment
{
    public sealed class MassageTreatmentsRepository : PaginatedRepository<MassageTreatment, MassageTreatmentData>, IMassageTreatmentsRepository
    {
        public MassageTreatmentsRepository(SalonDbContext c) : base(c, c.MassageTreatments) { }

        protected internal override MassageTreatment ToDomainObject(MassageTreatmentData d) => new MassageTreatment(d);

        protected override async Task<MassageTreatmentData> GetData(string id)
        {
            return await DbSet.SingleOrDefaultAsync();
        }

        protected override string GetId(MassageTreatment obj)
        {
            throw new System.NotImplementedException();
        }
    }
}