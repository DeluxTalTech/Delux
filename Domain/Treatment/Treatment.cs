using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Treatment;
using Delux.Domain.Common;

namespace Delux.Domain.Treatment
{
    public sealed class Treatment : Entity<TreatmentData>
    {
        public Treatment() : this(null) { }

        public Treatment(TreatmentData data) : base(data) { }
    }
}
