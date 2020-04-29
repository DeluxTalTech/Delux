using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra.Common;

namespace Delux.Infra.Treatment
{
    public sealed class FacialTreatmentsRepository : IdRepository<FacialTreatment, FacialTreatmentData>, IFacialTreatmentsRepository
    {
        public FacialTreatmentsRepository(SalonDbContext c) : base(c, c.FacialTreatments) { }

        protected internal override FacialTreatment ToDomainObject(FacialTreatmentData d) => new FacialTreatment(d);
    }
}