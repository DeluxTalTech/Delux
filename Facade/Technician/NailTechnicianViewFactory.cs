using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;

namespace Delux.Facade.Technician
{
    public static class NailTechnicianViewFactory
    {
        public static NailTechnician Create(NailTechnicianView view)
        {
            var d = new NailTechnicianData();
            Copy.Members(view, d);
            return new NailTechnician(d);
        }

        public static NailTechnicianView Create(NailTechnician obj)
        {
            var v = new NailTechnicianView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
