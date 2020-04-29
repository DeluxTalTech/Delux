using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra.Common;

namespace Delux.Infra.Treatment
{
    public sealed class MassageTreatmentsRepository : IdRepository<MassageTreatment, MassageTreatmentData>, IMassageTreatmentsRepository
    {
        public MassageTreatmentsRepository(SalonDbContext c) : base(c, c.MassageTreatments) { }

        protected internal override MassageTreatment ToDomainObject(MassageTreatmentData d) => new MassageTreatment(d);
    }
}