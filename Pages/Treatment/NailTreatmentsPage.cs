using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Delux.Pages.Common;

namespace Delux.Pages.Treatment
{
    public abstract class NailTreatmentsPage : CommonPage<INailTreatmentsRepository, NailTreatment, NailTreatmentView, NailTreatmentData>
    {
        protected internal NailTreatmentsPage(INailTreatmentsRepository r) : base(r)
        {
            PageTitle = "Nail Treatments";
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Salon/NailTreatments";

        protected internal override NailTreatment ToObject(NailTreatmentView view) => NailTreatmentViewFactory.Create(view);

        protected internal override NailTreatmentView ToView(NailTreatment obj) => NailTreatmentViewFactory.Create(obj);
    }
}
