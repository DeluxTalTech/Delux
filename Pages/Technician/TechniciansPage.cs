using System;
using System.Collections.Generic;
using System.Text;
using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Delux.Pages.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Delux.Pages.Technician
{
    public abstract class TechniciansPage : CommonPage<ITechniciansRepository, Domain.Technician.Technician, TechnicianView, TechnicianData>
    {
        public IEnumerable<SelectListItem> TechnicianTypes { get; }
        protected internal TechniciansPage(ITechniciansRepository r, ITechnicianTypesRepository m) : base(r)
        {
            PageTitle = "Tehnikud";
            TechnicianTypes = CreateSelectList<TechnicianType, TechnicianTypeData>(m);
        }

        public override string ItemId
        {
            get
            {
                if (Item is null) return string.Empty;
                return $"{Item.Id}.{Item.TechnicianTypeId}";
            }
        }

        protected internal override string GetPageUrl() => "/Salon/Technicians";

        protected internal override Domain.Technician.Technician ToObject(TechnicianView view)
        {
            return TechnicianViewFactory.Create(view);
        }

        protected internal override TechnicianView ToView(Domain.Technician.Technician obj)
        {
            return TechnicianViewFactory.Create(obj);
        }

        public string GetTechnicianTypeName(string technicianTypeId)
        {
            foreach (var m in TechnicianTypes)
                if (m.Value == technicianTypeId)
                    return m.Text;
            return "Unspecified";
        }

        protected internal override string GetPageSubTitle()
        {
            return FixedValue is null
                ? base.GetPageSubTitle()
                : $"For {GetTechnicianTypeName(FixedValue)}";
        }
    }
}
