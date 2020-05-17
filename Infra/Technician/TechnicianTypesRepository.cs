using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Infra.Common;

namespace Delux.Infra.Technician
{
    public sealed class TechnicianTypesRepository : IdRepository<TechnicianType, TechnicianTypeData>, ITechnicianTypesRepository
    {
        public TechnicianTypesRepository(SalonDbContext c) : base(c, c.TechnicianTypes) { }

        protected internal override TechnicianType ToDomainObject(TechnicianTypeData d) => new TechnicianType(d);
    }
}
