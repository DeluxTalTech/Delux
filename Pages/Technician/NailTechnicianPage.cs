﻿using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Delux.Pages.Common;

namespace Delux.Pages.Technician
{
    public class NailTechnicianPage : CommonPage<INailTechniciansRepository, NailTechnician, NailTechnicianView, NailTechnicianData>
    {
        protected internal NailTechnicianPage(INailTechniciansRepository r) : base(r)
        {
            PageTitle = "Nail Technicians";
        }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/Quantity/NailTechnicians";

        protected internal override NailTechnician ToObject(NailTechnicianView view)
        {
            return NailTechnicianViewFactory.Create(view);
        }

        protected internal override NailTechnicianView ToView(NailTechnician obj)
        {
            return NailTechnicianViewFactory.Create(obj);
        }
    }
}