using System.Collections.Generic;
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

        public override string ItemId => Item?.Id ?? string.Empty;

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
            return "Määratlemata";
        }
    }
}
