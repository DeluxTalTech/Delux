using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;

namespace Delux.Facade.Technician
{
    public static class HairdresserViewFactory
    {
        public static HairDresser Create(HairdresserView view)
        {
            var d = new HairdresserData();
            Copy.Members(view, d);
            return new HairDresser(d);
        }

        public static HairdresserView Create(HairDresser obj)
        {
            var v = new HairdresserView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
