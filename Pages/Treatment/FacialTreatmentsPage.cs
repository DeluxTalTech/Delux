using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Delux.Pages.Common;

namespace Delux.Pages.Treatment
{
    public class FacialTreatmentsPage:CommonPage<IFacialTreatmentsRepository, FacialTreatment, FacialTreatmentView,FacialTreatmentData>
    {
        protected internal FacialTreatmentsPage(IFacialTreatmentsRepository r) : base(r)
        {
            PageTitle = "Facial Treatments";
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Treatments/FacialTreatments";

        protected internal override FacialTreatment ToObject(FacialTreatmentView view) => FacialTreatmentViewFactory.Create(view);

        protected internal override FacialTreatmentView ToView(FacialTreatment obj) => FacialTreatmentViewFactory.Create(obj);
    }
}
