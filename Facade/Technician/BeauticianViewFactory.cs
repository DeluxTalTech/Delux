using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;

namespace Delux.Facade.Technician
{
    public static class BeauticianViewFactory
    {
        public static Beautician Create(BeauticianView view)
        {
            var d = new BeauticianData();
            Copy.Members(view, d);
            return new Beautician(d);
        }

        public static BeauticianView Create(Beautician obj)
        {
            var v = new BeauticianView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
