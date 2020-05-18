using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Facade.Technician;
using Delux.Facade.Treatment;
using Delux.Pages.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Delux.Pages.Treatment
{
    public class TreatmentsPage : CommonPage<ITreatmentsRepository, Domain.Treatment.Treatment, TreatmentView, TreatmentData>
    {
        public IEnumerable<SelectListItem> TreatmentTypes { get; }
        protected internal TreatmentsPage(ITreatmentsRepository r, ITreatmentTypesRepository m) : base(r)
        {
            PageTitle = "Hooldused";
            TreatmentTypes = CreateSelectList<TreatmentType, TreatmentTypeData>(m);
        }

        public override string ItemId
        {
            get
            {
                if (Item is null) return string.Empty;
                return $"{Item.Id}.{Item.TreatmentTypeId}";
            }
        }

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
            return "Unspecified";
        }

        protected internal override string GetPageSubTitle()
        {
            return FixedValue is null
                ? base.GetPageSubTitle()
                : $"For {GetTreatmentTypeName(FixedValue)}";
        }
    }
}
