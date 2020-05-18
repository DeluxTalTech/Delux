using System;
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
            new TreatmentData{Id = "1", TreatmentTypeId = "Näohooldus", Name = "Rasuse ja probleemse naha hooldus", Definition = "", ValidFrom = null, ValidTo = null, Price = "55€", Duration = "45 min"},
            new TreatmentData{Id = "2", TreatmentTypeId = "Näohooldus", Name = "Jumet ühtlustav hooldus", Definition = "", ValidFrom = null, ValidTo = null, Price = "70€", Duration = "1h"},
            new TreatmentData{Id = "3", TreatmentTypeId = "Näohooldus", Name = "Kollageenihooldus", Definition = "", ValidFrom = null, ValidTo = null, Price = "80€", Duration = "1h 15 min"},
            new TreatmentData{Id = "4", TreatmentTypeId = "Näohooldus", Name = "Puhastav hooldus noortele kuni 18.a", Definition = "", ValidFrom = null, ValidTo = null, Price = "35€", Duration = "1h"},
            new TreatmentData{Id = "5", TreatmentTypeId = "Juuksehooldus", Name = "Niisutav läikehooldus", Definition = "", ValidFrom = null, ValidTo = null, Price = "60€", Duration = "1h 15 min"},
            new TreatmentData{Id = "6", TreatmentTypeId = "Juuksehooldus", Name = "Juukselõikus", Definition = "Sisaldab ka pesu ning föönisoengut", ValidFrom = null, ValidTo = null, Price = "35€", Duration = "1h"},
            new TreatmentData{Id = "7", TreatmentTypeId = "Juuksehooldus", Name = "Toonimine", Definition = "", ValidFrom = null, ValidTo = null, Price = "60€", Duration = "1h"},
            new TreatmentData{Id = "8", TreatmentTypeId = "Juuksehooldus", Name = "Tuka lõikus", Definition = "Ilma pesuta", ValidFrom = null, ValidTo = null, Price = "10€", Duration = "20 min"},
            new TreatmentData{Id = "9", TreatmentTypeId = "Massaaž", Name = "Šokolaadi massaaž", Definition = "MAIKUU ERI! Sensuaalne massaaž nii kehale kui vaimule. Massaaž on tõeline hellitusretk nii stressi, halva meeleolu, kuiva naha, toonuse ja toitainete puuduse korral.", 
                ValidFrom = Convert.ToDateTime("01/05/20"), ValidTo = Convert.ToDateTime("31/05/20"), Price = "50€", Duration = "50 min"},
            new TreatmentData{Id = "10", TreatmentTypeId = "Massaaž", Name = "Klassikaline massaaž", Definition = "Klassikaline massaaž ehk Rootsi massaaž on kõige levinum massaažiliik ning kujutab endast erinevate liigutuste ja võtete kompleksi.", 
                ValidFrom = null, ValidTo = null, Price = "42€", Duration = "50 min"},
            new TreatmentData{Id = "11", TreatmentTypeId = "Massaaž", Name = "Aroomimassaaž", Definition = "Aroomiteraapia ehk aroomimassaaž ühendab endas klassikalise massaaži kerged pindmised silumisvõtted ja taimede eeterlike õlide raviomadused.", 
                ValidFrom = null, ValidTo = null, Price = "50€", Duration = "45 min"},
            new TreatmentData{Id = "12", TreatmentTypeId = "Massaaž", Name = "Sportmassaaž", Definition = "Massaaž mõjub lõdvestavalt kurnatud lihaste, krooniliste valude ja ületreenituse ning üleväsimuse korral.", 
                ValidFrom = null, ValidTo = null, Price = "50€", Duration = "50 min"},
            new TreatmentData{Id = "13", TreatmentTypeId = "Küüntehooldus", Name = "Klassikaline maniküür", Definition = "Ilma lakkimiseta", ValidFrom = null, ValidTo = null, Price = "28€", Duration = "1h"},
            new TreatmentData{Id = "14", TreatmentTypeId = "Küüntehooldus", Name = "Klassikaline maniküür", Definition = "Lakkimisega", ValidFrom = null, ValidTo = null, Price = "30€", Duration = "1h"},
            new TreatmentData{Id = "15", TreatmentTypeId = "Küüntehooldus", Name = "Geelküünte paigaldus", Definition = "Sisaldab aparaadimaniküüri", ValidFrom = null, ValidTo = null, Price = "65€", Duration = "2h 30 min"},
            new TreatmentData{Id = "16", TreatmentTypeId = "Küüntehooldus", Name = "Geelküünte hooldus", Definition = "Sisaldab aparaadimaniküüri", ValidFrom = null, ValidTo = null, Price = "60€", Duration = "2h 30 min"},

        };

        internal static List<TechnicianData>  Technicians => new List<TechnicianData>
        {

        };

        internal static List<ClientData> Clients => new List<ClientData>
        {
            new ClientData{Id="1", MailAddress = "marimaasikas@gmail.com", Name = "Mari Maasikas", PhoneNumber = "53735654"},
            new ClientData{Id = "2", MailAddress = "karu.kati@gmail.com", Name = "Kati Karu",PhoneNumber = "5147778"},
            new ClientData{Id="3",MailAddress = "kajaluik@gmail.com", Name = "Kaja Luik", PhoneNumber = "56715954"},
            new ClientData{Id="4",MailAddress = "arturluik@gmail.com", Name = "Artur Luik", PhoneNumber = "56354357"},
            new ClientData{Id="5",MailAddress = "virve.magi@gmail.com", Name = "Virve Mägi", PhoneNumber = "5999745"},
            new ClientData{Id="6",MailAddress = "ml.kala@gmail.com", Name = "Marta Liisa Kala", PhoneNumber = "54989595"},
        };

        internal static List<AppointmentData> Appointments => new List<AppointmentData>
        {

        };

        internal static List<TreatmentTypeData> TreatmentTypes => new List<TreatmentTypeData>
        {
            new TreatmentTypeData{Id="1",Name = "Näohooldus"},
            new TreatmentTypeData{Id="2",Name = "Juuksehooldus"},
            new TreatmentTypeData{Id="3",Name = "Massaaž"},
            new TreatmentTypeData{Id="4",Name = "Küüntehooldus"}

        };

        internal static List<TechnicianTypeData> TechnicianTypes => new List<TechnicianTypeData>
        {
            new TechnicianTypeData{Id="1",Name = "Kosmeetik"},
            new TechnicianTypeData{Id="2",Name = "Juuksur"},
            new TechnicianTypeData{Id="3",Name = "Massöör"},
            new TechnicianTypeData{Id="4",Name = "Küünetehnik"}
        };

        public static void Initialize(SalonDbContext db)
        {
            InitializeTreatmentTypes(db);
            InitializeTechnicianTypes(db);
            InitializeTreatments(db);
            InitializeTechnicians(db);
            InitializeClients(db);
        }
        private static void InitializeClients(SalonDbContext db)
        {
            if (db.Clients.Count() != 0) return;
            db.Clients.AddRange(Clients);
            db.SaveChanges();
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