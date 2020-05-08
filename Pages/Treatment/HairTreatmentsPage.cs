using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Delux.Pages.Common;

namespace Delux.Pages.Treatment
{
    public abstract class HairTreatmentsPage : CommonPage<IHairTreatmentsRepository, HairTreatment, HairTreatmentView, HairTreatmentData>
    {
        protected internal HairTreatmentsPage(IHairTreatmentsRepository r) : base(r)
        {
            PageTitle = "Hair Treatments";
        }
        
        public override string ItemId => Item.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Salon/HairTreatments";

        protected internal override HairTreatment ToObject(HairTreatmentView view) => HairTreatmentViewFactory.Create(view);

        protected internal override HairTreatmentView ToView(HairTreatment obj) => HairTreatmentViewFactory.Create(obj);
    }
}
