using System;
using System.Collections.Generic;
using System.Text;

namespace Delux.Infra.Appointment
{
    class AppointmentsRepository
    {
        //public sealed class UnitTermsRepository : PaginatedRepository<UnitTerm, UnitTermData>, IUnitTermsRepository
        //{

        //    public UnitTermsRepository() : this(null) { }

        //    public UnitTermsRepository(QuantityDbContext c) : base(c, c?.UnitTerms) { }

        //    protected internal override UnitTerm toDomainObject(UnitTermData d) => new UnitTerm(d);

        //    protected override async Task<UnitTermData> getData(string id)
        //    {
        //        var masterId = GetString.Head(id);
        //        var termId = GetString.Tail(id);

        //        return await dbSet.SingleOrDefaultAsync(x => x.TermId == termId && x.MasterId == masterId);
        //    }

        //    protected override string getId(UnitTerm obj)
        //    {
        //        return obj?.Data is null ? string.Empty : $"{obj.Data.MasterId}.{obj.Data.TermId}";
        //    }

        //}
    }
}
