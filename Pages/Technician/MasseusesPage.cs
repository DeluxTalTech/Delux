using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Delux.Pages.Common;

namespace Delux.Pages.Technician
{
    public abstract class MasseusesPage : CommonPage<IMasseusesRepository, Masseuse, MasseuseView, MasseuseData>
    {
        protected internal MasseusesPage(IMasseusesRepository r) : base(r)
        {
            PageTitle = "Masseuses";
        }

        public override string ItemId => Item.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Salon/Masseuses";

        protected internal override Masseuse ToObject(MasseuseView view)
        {
            return MasseuseViewFactory.Create(view);
        }

        protected internal override MasseuseView ToView(Masseuse obj)
        {
            return MasseuseViewFactory.Create(obj);
        }
    }
}