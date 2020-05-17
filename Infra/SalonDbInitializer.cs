using System.Collections.Generic;
using System.Linq;
using Delux.Data.Client;
using Delux.Data.Reservation;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Delux.Domain.Reservation;

namespace Delux.Infra
{
    public static class SalonDbInitializer
    {
        internal static List<TreatmentData> Treatments => new List<TreatmentData>
        {
            
        };

        internal static List<TechnicianData>  Technicians => new List<TechnicianData>
        {

        };

        internal static List<ClientData> Clients => new List<ClientData>
        {

        };

        internal static List<AppointmentData> Appointments => new List<AppointmentData>
        {

        };

        internal static List<TreatmentTypeData> TreatmentTypes => new List<TreatmentTypeData>
        {
            new TreatmentTypeData{Id="1",Name = "Facial Treatment"},
            new TreatmentTypeData{Id="2",Name = "Hair Treatment"},
            new TreatmentTypeData{Id="3",Name = "Massage Treatment"},
            new TreatmentTypeData{Id="4",Name = "Nail Treatment"}

        };

        internal static List<TechnicianTypeData> TechnicianTypes => new List<TechnicianTypeData>
        {
            new TechnicianTypeData{Id="1",Name = "Beautician"},
            new TechnicianTypeData{Id="2",Name = "Hairdresser"},
            new TechnicianTypeData{Id="3",Name = "Masseuse"},
            new TechnicianTypeData{Id="4",Name = "Nailtechnician"}
        };

        public static void Initialize(SalonDbContext db)
        {
            InitializeTreatmentTypes(db);
            InitializeTechnicianTypes(db);
            InitializeTreatments(db);
            InitializeTechnicians(db);
        }

        private static void InitializeTreatmentTypes(SalonDbContext db)
        {
            if (db.TreatmentTypes.Count() != 0) return;
            db.TreatmentTypes.AddRange(TreatmentTypes);
            db.SaveChanges();
        }

        private static void InitializeTechnicianTypes(SalonDbContext db)
        {
            if (db.TechnicianTypes.Count() != 0) return;
            db.TechnicianTypes.AddRange(TechnicianTypes);
            db.SaveChanges();
        }

        private static void InitializeTreatments(SalonDbContext db)
        {
            if (db.Treatments.Count() != 0) return;
            db.Treatments.AddRange(Treatments);
            db.SaveChanges();
        }

        private static void InitializeTechnicians(SalonDbContext db)
        {
            if (db.Technicians.Count() != 0) return;
            db.Technicians.AddRange(Technicians);
            db.SaveChanges();
        }

    }
}