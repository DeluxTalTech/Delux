using System.Collections.Generic;
using Delux.Data.Treatment;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Delux.Pages.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Delux.Pages.Treatment
{
    public abstract class TreatmentsPage : CommonPage<ITreatmentsRepository, Domain.Treatment.Treatment, TreatmentView, TreatmentData>
    {
        public IEnumerable<SelectListItem> TreatmentTypes { get; }
        protected internal TreatmentsPage(ITreatmentsRepository r, ITreatmentTypesRepository m) : base(r)
        {
            PageTitle = "Hooldused";
            TreatmentTypes = CreateSelectList<TreatmentType, TreatmentTypeData>(m);
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Salon/Treatments";

        protected internal override Domain.Treatment.Treatment ToObject(TreatmentView view)
        {
            return TreatmentViewFactory.Create(view);
        }

        protected internal override TreatmentView ToView(Domain.Treatment.Treatment obj)
        {
            return TreatmentViewFactory.Create(obj);
        }

        public string GetTreatmentTypeName(string treatmentTypeId)
        {
            foreach (var m in TreatmentTypes)
                if (m.Value == treatmentTypeId)
                    return m.Text;
            return "Määratlemata";
        }
    }
}
