using System;
using System.Collections.Generic;
using System.Linq;
using Delux.Data.Client;
using Delux.Data.Reservation;
using Delux.Data.Technician;
using Delux.Data.Treatment;

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
            new TreatmentData{Id = "17", TreatmentTypeId = "Ripsmehooldus", Name = "Ripsmepikenduste paigaldamine", Definition = "NB! Vahetult pärast protseduuri tuleb vältida 24h jooksul silmade kokkupuudet veega!", ValidFrom = null, ValidTo = null, Price = "30€", Duration = "1h 30 min"},
            new TreatmentData{Id = "18", TreatmentTypeId = "Ripsmehooldus", Name = "Ripsmepikenduste hooldus", Definition = "NB! Vahetult pärast protseduuri tuleb vältida 24h jooksul silmade kokkupuudet veega!", ValidFrom = null, ValidTo = null, Price = "25€", Duration = "1h min"},
            new TreatmentData{Id = "19", TreatmentTypeId = "Ripsmehooldus", Name = "Ripsmete keemiline värvimine", Definition = "", ValidFrom = null, ValidTo = null, Price = "10€", Duration = "20 min"},
            new TreatmentData{Id = "20", TreatmentTypeId = "Ripsmehooldus", Name = "Lashlift", Definition = "Ripsmete koolutamine spetsiaaksete silikoonpatjade abil jätab loomuliku ja kauni koolutuse. Kauapüsiva tulemuse tagab spetsiaalne 3-etapiline kreemprotseduur, mis fikseerib ripsmed soovitud asendisse. Protseduur sisaldab ka ripsmete keemilist värvimist.",
                ValidFrom = null, ValidTo = null, Price = "30€", Duration = "45 min"},
            new TreatmentData{Id = "21", TreatmentTypeId = "Jumestus", Name = "Pidulik jumestus", Definition = "Õhtumeik, lavameik, pruudimeik jne", ValidFrom = null, ValidTo = null, Price = "50€", Duration = "1h 30 min"},
            new TreatmentData{Id = "22", TreatmentTypeId = "Jumestus", Name = "Päevameik", Definition = "", ValidFrom = null, ValidTo = null, Price = "25€", Duration = "45 min"},
            new TreatmentData{Id = "23", TreatmentTypeId = "Jumestus", Name = "Õhtu- ja stiilimeik", Definition = "Sisaldab ripsmetutikuid", ValidFrom = null, ValidTo = null, Price = "30€", Duration = "1h"},
            new TreatmentData{Id = "24", TreatmentTypeId = "Jumestus", Name = "Personaalne jumestusnõustamine", Definition = "", ValidFrom = null, ValidTo = null, Price = "60€", Duration = "1h 30 min"},

        };

        internal static List<TechnicianData>  Technicians => new List<TechnicianData>
        {
            new TechnicianData{Id = "1", TechnicianTypeId = "Kosmeetik", Name = "Annika Meier", AvailableDays = "Esmaspäev, Kolmapäev", WorkedYears = "5a"},
            new TechnicianData{Id = "2", TechnicianTypeId = "Kosmeetik", Name = "Katrin Kuldmaa", AvailableDays = "Esmaspäev, Reede, Laupäev", WorkedYears = "8a"},
            new TechnicianData{Id = "3", TechnicianTypeId = "Kosmeetik", Name = "Triin Rauts", AvailableDays = "Teisipäev, Kolmapäev", WorkedYears = "3a"},
            new TechnicianData{Id = "4", TechnicianTypeId = "Kosmeetik", Name = "Terje Laul", AvailableDays = "Teisipäev, Kolmapäev, Reede, Laupäev, Pühapäev", WorkedYears = "6a"},
            new TechnicianData{Id = "5", TechnicianTypeId = "Juuksur", Name = "Mai-Liis Müller", AvailableDays = "Teisipäev, Laupäev, Pühapäev", WorkedYears = "4a"},
            new TechnicianData{Id = "6", TechnicianTypeId = "Juuksur", Name = "Emma Pihlak", AvailableDays = "Esmaspäev, Reede, Pühapäev", WorkedYears = "6a"},
            new TechnicianData{Id = "7", TechnicianTypeId = "Juuksur", Name = "Erika Vinogradova", AvailableDays = "Neljapäev, Reede, Laupäev, Pühapäev", WorkedYears = "5a"},
            new TechnicianData{Id = "8", TechnicianTypeId = "Juuksur", Name = "Hanna-Liis Suvi", AvailableDays = "Teisipäev, Laupäev", WorkedYears = "8a"},
            new TechnicianData{Id = "9", TechnicianTypeId = "Massöör", Name = "Maria Mägi", AvailableDays = "Esmaspäev, Teisipäev, Kolmapäev, Neljapäev, Reede", WorkedYears = "9a"},
            new TechnicianData{Id = "10", TechnicianTypeId = "Massöör", Name = "Anna Ivanova", AvailableDays = "Neljapäev, Reede, Laupäev", WorkedYears = "4a"},
            new TechnicianData{Id = "11", TechnicianTypeId = "Massöör", Name = "Sigrid Sööt", AvailableDays = "Kolmapäev, Laupäev, Pühapäev", WorkedYears = "8a"},
            new TechnicianData{Id = "12", TechnicianTypeId = "Massöör", Name = "Kadri-Ann Saarepera", AvailableDays = "Teisipäev, Neljapäev", WorkedYears = "5a"},
            new TechnicianData{Id = "13", TechnicianTypeId = "Küünetehnik", Name = "Reelika Raag", AvailableDays = "Teisipäev, Laupäev, Pühapäev", WorkedYears = "3a"},
            new TechnicianData{Id = "14", TechnicianTypeId = "Küünetehnik", Name = "Kaisa Lust", AvailableDays = "Esmaspäev, Kolmapäev", WorkedYears = "6a"},
            new TechnicianData{Id = "15", TechnicianTypeId = "Küünetehnik", Name = "Laura Kaarma", AvailableDays = "Esmaspäev, Teisipäev, Reede, Laupäev", WorkedYears = "2a"},
            new TechnicianData{Id = "16", TechnicianTypeId = "Küünetehnik", Name = "Kristina Mülla", AvailableDays = "Neljapäev, Reede, Laupäev", WorkedYears = "2a"},
            new TechnicianData{Id = "17", TechnicianTypeId = "Ripsmetehnik", Name = "Liza Savostjanova", AvailableDays = "Kolmapäev, Reede, Pühapäev", WorkedYears = "4a"},
            new TechnicianData{Id = "18", TechnicianTypeId = "Ripsmetehnik", Name = "Carmen Soosepp", AvailableDays = "Esmaspäev, Teisipäev, Reede, Laupäev", WorkedYears = "6a"},
            new TechnicianData{Id = "19", TechnicianTypeId = "Ripsmetehnik", Name = "Mari-Ann Pauts", AvailableDays = "Neljapäev, Reede, Laupäev", WorkedYears = "1a"},
            new TechnicianData{Id = "20", TechnicianTypeId = "Ripsmetehnik", Name = "Gertrud Kask", AvailableDays = "Kolmapäev, Pühapäev", WorkedYears = "2a"},
            new TechnicianData{Id = "21", TechnicianTypeId = "Meigikunstnik", Name = "Britt Koger", AvailableDays = "Esmaspäev, Teisipäev, Kolmapäev", WorkedYears = "6a"},
            new TechnicianData{Id = "22", TechnicianTypeId = "Meigikunstnik", Name = "Nataly Veermaa", AvailableDays = "Esmaspäev, Laupäev", WorkedYears = "8a"},
            new TechnicianData{Id = "23", TechnicianTypeId = "Meigikunstnik", Name = "Triin Saarmas", AvailableDays = "Neljapäev, Reede, Laupäev, Pühapäev", WorkedYears = "3a"},
            new TechnicianData{Id = "24", TechnicianTypeId = "Meigikunstnik", Name = "Olga Aleksejeva", AvailableDays = "Teisipäev, Laupäev, Pühapäev", WorkedYears = "4a"},
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
            new TreatmentTypeData{Id="4",Name = "Küüntehooldus"},
            new TreatmentTypeData{Id="5",Name = "Ripsmehooldus"},
            new TreatmentTypeData{Id="6",Name = "Jumestus"}
        };

        internal static List<TechnicianTypeData> TechnicianTypes => new List<TechnicianTypeData>
        {
            new TechnicianTypeData{Id="1",Name = "Kosmeetik"},
            new TechnicianTypeData{Id="2",Name = "Juuksur"},
            new TechnicianTypeData{Id="3",Name = "Massöör"},
            new TechnicianTypeData{Id="4",Name = "Küünetehnik"},
            new TechnicianTypeData{Id="5",Name = "Ripsmetehnik"},
            new TechnicianTypeData{Id="6",Name = "Meigikunstnik"}
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