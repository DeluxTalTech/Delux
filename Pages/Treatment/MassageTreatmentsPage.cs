using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Delux.Pages.Common;

namespace Delux.Pages.Treatment
{
    public class MassageTreatmentsPage : CommonPage<IMassageTreatmentsRepository, MassageTreatment, MassageTreatmentView, MassageTreatmentData>
    {
        protected internal MassageTreatmentsPage(IMassageTreatmentsRepository r) : base(r)
        {
            PageTitle = "Massage Treatments";
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Salon/MassageTreatments";

        protected internal override MassageTreatment ToObject(MassageTreatmentView view) => MassageTreatmentViewFactory.Create(view);

        protected internal override MassageTreatmentView ToView(MassageTreatment obj) => MassageTreatmentViewFactory.Create(obj);
    }
}
