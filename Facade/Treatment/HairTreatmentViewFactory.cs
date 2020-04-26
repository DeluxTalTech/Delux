using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;

namespace Delux.Facade.Treatment
{
    public static class HairTreatmentViewFactory
    {
        public static HairTreatment Create(HairTreatmentView view)
        {
            var d = new HairTreatmentData();
            Copy.Members(view, d);
            return new HairTreatment(d);
        }

        public static HairTreatmentView Create(HairTreatment obj)
        {
            var v = new HairTreatmentView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
