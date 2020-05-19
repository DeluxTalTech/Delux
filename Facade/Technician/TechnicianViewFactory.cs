using Delux.Aids;
using Delux.Data.Technician;

namespace Delux.Facade.Technician
{
    public static class TechnicianViewFactory
    {
        public static Domain.Technician.Technician Create(TechnicianView v)
        {
            var d = new TechnicianData();
            Copy.Members(v, d);

            return new Domain.Technician.Technician(d);
        }

        public static TechnicianView Create(Domain.Technician.Technician o)
        {
            var v = new TechnicianView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);
            return v;
        }
    }
}
