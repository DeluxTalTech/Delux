using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Infra.Common;

namespace Delux.Infra.Treatment
{
    public sealed class TreatmentTypesRepository : IdRepository<TreatmentType, TreatmentTypeData>, ITreatmentTypesRepository
    {
        public TreatmentTypesRepository(SalonDbContext c) : base(c, c.TreatmentTypes) { }

        protected internal override TreatmentType ToDomainObject(TreatmentTypeData d) => new TreatmentType(d);
    }
}
