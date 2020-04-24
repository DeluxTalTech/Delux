using System;
using System.Collections.Generic;
using System.Text;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Domain.Technician;

namespace Delux.Facade.Technician
{
    public static class MasseuseViewFactory
    {
        public static Masseuse Create(MasseuseView view)
        {
            var d = new MasseuseData();
            Copy.Members(view, d);
            return new Masseuse(d);
        }

        public static MasseuseView Create(Masseuse obj)
        {
            var v = new MasseuseView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
