using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;

namespace Delux.Facade.Technician
{
    public static class HairdresserViewFactory
    {
        public static Hairdresser Create(HairdresserView view)
        {
            var d = new HairdresserData();
            Copy.Members(view, d);
            return new Hairdresser(d);
        }

        public static HairdresserView Create(Hairdresser obj)
        {
            var v = new HairdresserView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
