using Delux.Data.Technician;
using Delux.Domain.Technician;
using Delux.Facade.Technician;
using Delux.Pages.Common;

namespace Delux.Pages.Technician
{
    public class HairdresserPage : CommonPage<IHairdressersRepository, Hairdresser, HairdresserView, HairdresserData>
    {
        protected internal HairdresserPage(IHairdressersRepository r) : base(r)
        {
            PageTitle = "Systems Of Units";
        }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/Quantity/Hairdressers";

        protected internal override Hairdresser ToObject(HairdresserView view)
        {
            return HairdresserViewFactory.Create(view);
        }

        protected internal override HairdresserView ToView(Hairdresser obj)
        {
            return HairdresserViewFactory.Create(obj);
        }
    }
}