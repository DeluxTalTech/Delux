using System.Threading.Tasks;
using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Delux.Infra.Treatment
{
    public sealed class TreatmentsRepository : IdRepository<Domain.Treatment.Treatment, TreatmentData>, ITreatmentsRepository
    {
        public TreatmentsRepository() : this(null) { }

        public TreatmentsRepository(SalonDbContext c) : base(c, c?.Treatments) { }

        protected internal override Domain.Treatment.Treatment ToDomainObject(TreatmentData d) => new Domain.Treatment.Treatment(d);

        //protected override async Task<TreatmentData> GetData(string id)
        //{
        //    var masterId = GetString.Head(id);
        //    var treatmentTypeId = GetString.Tail(id);
        //    return await DbSet.SingleOrDefaultAsync(x => x.TreatmentTypeId == treatmentTypeId && x.Id == masterId);
        //}

        //protected override string GetId(Domain.Treatment.Treatment obj)
        //{
        //    return obj?.Data is null ? string.Empty : $"{obj.Data.Id}.{obj.Data.TreatmentTypeId}";
        //}
    }
}
