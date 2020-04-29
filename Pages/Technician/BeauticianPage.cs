﻿using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Delux.Pages.Common;

namespace Delux.Pages.Technician
{
    public class BeauticianPage : CommonPage<IBeauticiansRepository, Beautician, BeauticianView, BeauticianData>
    {
        protected internal BeauticianPage(IBeauticiansRepository r) : base(r)
        {
            PageTitle = "Beauticians";
        }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/Quantity/Beauticians";

        protected internal override Beautician ToObject(BeauticianView view)
        {
            return BeauticianViewFactory.Create(view);
        }

        protected internal override BeauticianView ToView(Beautician obj)
        {
            return BeauticianViewFactory.Create(obj);
        }
    }
}