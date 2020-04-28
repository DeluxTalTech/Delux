using System.Threading.Tasks;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Delux.Infra.Treatment
{
    public sealed class MassageTreatmentsRepository : IdRepository<MassageTreatment, MassageTreatmentData>, IMassageTreatmentsRepository
    {
        public MassageTreatmentsRepository(SalonDbContext c) : base(c, c.MassageTreatments) { }

        protected internal override MassageTreatment ToDomainObject(MassageTreatmentData d) => new MassageTreatment(d);
    }
}