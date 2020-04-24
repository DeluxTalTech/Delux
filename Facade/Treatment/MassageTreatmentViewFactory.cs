using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;

namespace Delux.Facade.Treatment
{
    public static class MassageTreatmentViewFactory
    {
        public static MassageTreatment Create(MassageTreatmentView view)
        {
            var d = new MassageTreatmentData();
            Copy.Members(view, d);
            return new MassageTreatment(d);
        }

        public static MassageTreatmentView Create(MassageTreatment obj)
        {
            var v = new MassageTreatmentView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
