using System.Collections.Generic;
using Delux.Data.Client;
using Delux.Data.Reservation;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Delux.Domain.Client;
using Delux.Domain.Reservation;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Facade.Reservation;
using Delux.Facade.Treatment;
using Delux.Pages.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Delux.Pages.Reservation
{
    public abstract class AppointmentsPage : CommonPage<IAppointmentsRepository, Appointment, AppointmentView, AppointmentData>
    {
        public IEnumerable<SelectListItem> Clients { get; }
        public IEnumerable<SelectListItem> Treatments { get; }
        public IEnumerable<SelectListItem> Technicians { get; }

        protected internal AppointmentsPage(IAppointmentsRepository a, IClientsRepository c, ITreatmentsRepository tr, ITechniciansRepository te) 
            : base(a)
        {
            PageTitle = "Broneeringud";
            Clients = CreateSelectList<Domain.Client.Client, ClientData>(c);
            Treatments = CreateSelectList<Domain.Treatment.Treatment, TreatmentData>(tr);
            Technicians = CreateSelectList<Domain.Technician.Technician, TechnicianData>(te);
        }

        //public override string ItemId
        //{
        //    get
        //    {
        //        if (Item is null) return string.Empty;
        //        return $"{Item.ClientId}.{Item.TreatmentId}.{Item.TechnicianId}";
        //    }
        //}
        public override string ItemId => Item is null ? string.Empty : Item.GetId();
        protected internal override string GetPageUrl() => "/Salon/Appointments";

        protected internal override Appointment ToObject(AppointmentView view)
        {
            return AppointmentViewFactory.Create(view);
        }

        protected internal override AppointmentView ToView(Appointment obj)
        {
            return AppointmentViewFactory.Create(obj);
        }

        public string GetClientName(string clientId)
        {
            foreach (var m in Clients)
                if (m.Value == clientId)
                    return m.Text;
            return "Unspecified";
        }

        public string GetTreatmentName(string treatmentId)
        {
            foreach (var m in Treatments)
                if (m.Value == treatmentId)
                    return m.Text;
            return "Unspecified";
        }

        public string GetTechnicianName(string technicianId)
        {
            foreach (var m in Technicians)
                if (m.Value == technicianId)
                    return m.Text;
            return "Unspecified";
        }

        protected internal override string GetPageSubTitle()
        {
            return FixedValue is null
                ? base.GetPageSubTitle()
                : $"For {GetClientName(FixedValue)}.{GetTreatmentName(FixedValue)}.{GetTechnicianName(FixedValue)}";
        }
    }
}