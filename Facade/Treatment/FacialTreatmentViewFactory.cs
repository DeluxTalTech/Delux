using Delux.Aids;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;

namespace Delux.Facade.Treatment
{
    public static class FacialTreatmentViewFactory
    {
        public static FacialTreatment Create(FacialTreatmentView view)
        {
            var d = new FacialTreatmentData();
            Copy.Members(view, d);
            return new FacialTreatment(d);
        }

        public static FacialTreatmentView Create(FacialTreatment obj)
        {
            var v = new FacialTreatmentView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
