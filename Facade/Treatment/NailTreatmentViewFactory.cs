using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;

namespace Delux.Facade.Treatment
{
    public static class NailTreatmentViewFactory
    {
        public static NailTreatment Create(NailTreatmentView view)
        {
            var d = new NailTreatmentData();
            Copy.Members(view, d);
            return new NailTreatment(d);
        }

        public static NailTreatmentView Create(NailTreatment obj)
        {
            var v = new NailTreatmentView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
