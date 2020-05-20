using Delux.Aids;
using Delux.Data.Reservation;
using Delux.Domain.Reservation;

namespace Delux.Facade.Reservation
{
    public static class AppointmentViewFactory
    {
        public static Appointment Create(AppointmentView view)
        {
            var d = new AppointmentData();
            Copy.Members(view, d);
            return new Appointment(d);
        }

        public static AppointmentView Create(Appointment obj)
        {
            var v = new AppointmentView();
            if(!(obj?.Data is null))
                Copy.Members(obj.Data, v);
            return v;
        }
    }
}