using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra.Common;

namespace Delux.Infra.Treatment
{
    public sealed class NailTreatmentsRepository : IdRepository<NailTreatment, NailTreatmentData>, INailTreatmentsRepository
    {
        public NailTreatmentsRepository(SalonDbContext c) : base(c, c.NailTreatments) { }

        protected internal override NailTreatment ToDomainObject(NailTreatmentData d) => new NailTreatment(d);

    }
}