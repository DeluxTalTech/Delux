using System.Threading.Tasks;
using Delux.Aids;
using Delux.Data.Reservation;
using Delux.Domain.Reservation;
using Delux.Infra.Common;
using Microsoft.EntityFrameworkCore;

//namespace Delux.Infra.Reservation
//{

//    public sealed class AppointmentsRepository : PaginatedRepository<Appointment, AppointmentData>, IAppointmentsRepository
//    {

//        public AppointmentsRepository() : this(null) { }
//        public AppointmentsRepository(SalonDbContext c) : base(c, c?.Appointments) { }

//        protected internal override Appointment ToDomainObject(AppointmentData d) => new Appointment(d);

//        protected override async Task<AppointmentData> GetData(string id)
//        {
//            var treatmentId = GetString.Head(id);
//            var technicianId = GetString.Tail(id);

//            return await DbSet.SingleOrDefaultAsync(x => x.TreatmentId == treatmentId && x.TechnicianId == technicianId);
//        }

//        protected override string GetId(Appointment obj)
//        {
//            return obj?.Data is null ? string.Empty : $"{obj.Data.TreatmentId}.{obj.Data.TechnicianId}";
//        }

//    }

//}