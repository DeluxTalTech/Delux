using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Delux.Data.Treatment;

namespace Delux.Facade.Treatment
{
    public static class TreatmentViewFactory
    {
        public static Domain.Treatment.Treatment Create(TreatmentView v)
        {
            var d = new TreatmentData();
            Copy.Members(v, d);

            return new Domain.Treatment.Treatment(d);
        }

        public static TreatmentView Create(Domain.Treatment.Treatment o)
        {
            var v = new TreatmentView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);
            return v;
        }
    }
}
