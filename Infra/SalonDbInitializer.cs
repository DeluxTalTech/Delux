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
            new TreatmentData{Id = "1", TreatmentTypeId = "1", Name = "Rasuse ja probleemse naha hooldus", Definition = "", ValidFrom = null, ValidTo = null, Price = "55€", Duration = "45 min"},
            new TreatmentData{Id = "2", TreatmentTypeId = "1", Name = "Jumet ühtlustav hooldus", Definition = "", ValidFrom = null, ValidTo = null, Price = "70€", Duration = "1h"},
            new TreatmentData{Id = "3", TreatmentTypeId = "1", Name = "Kollageenihooldus", Definition = "", ValidFrom = null, ValidTo = null, Price = "80€", Duration = "1h 15 min"},
            new TreatmentData{Id = "4", TreatmentTypeId = "1", Name = "Puhastav hooldus noortele kuni 18.a", Definition = "", ValidFrom = null, ValidTo = null, Price = "35€", Duration = "1h"},
            new TreatmentData{Id = "5", TreatmentTypeId = "2", Name = "Niisutav läikehooldus", Definition = "", ValidFrom = null, ValidTo = null, Price = "60€", Duration = "1h 15 min"},
            new TreatmentData{Id = "6", TreatmentTypeId = "2", Name = "Juukselõikus", Definition = "Sisaldab ka pesu ning föönisoengut", ValidFrom = null, ValidTo = null, Price = "35€", Duration = "1h"},
            new TreatmentData{Id = "7", TreatmentTypeId = "2", Name = "Toonimine", Definition = "", ValidFrom = null, ValidTo = null, Price = "60€", Duration = "1h"},
            new TreatmentData{Id = "8", TreatmentTypeId = "2", Name = "Tuka lõikus", Definition = "Ilma pesuta", ValidFrom = null, ValidTo = null, Price = "10€", Duration = "20 min"},
            new TreatmentData{Id = "9", TreatmentTypeId = "3", Name = "Šokolaadi massaaž", Definition = "MAIKUU ERI! Sensuaalne massaaž nii kehale kui vaimule. Massaaž on tõeline hellitusretk nii stressi, halva meeleolu, kuiva naha, toonuse ja toitainete puuduse korral.", 
                ValidFrom = Convert.ToDateTime("01/05/20"), ValidTo = Convert.ToDateTime("31/05/20"), Price = "50€", Duration = "50 min"},
            new TreatmentData{Id = "10", TreatmentTypeId = "3", Name = "Klassikaline massaaž", Definition = "Klassikaline massaaž ehk Rootsi massaaž on kõige levinum massaažiliik ning kujutab endast erinevate liigutuste ja võtete kompleksi.", 
                ValidFrom = null, ValidTo = null, Price = "42€", Duration = "50 min"},
            new TreatmentData{Id = "11", TreatmentTypeId = "3", Name = "Aroomimassaaž", Definition = "Aroomiteraapia ehk aroomimassaaž ühendab endas klassikalise massaaži kerged pindmised silumisvõtted ja taimede eeterlike õlide raviomadused.", 
                ValidFrom = null, ValidTo = null, Price = "50€", Duration = "45 min"},
            new TreatmentData{Id = "12", TreatmentTypeId = "3", Name = "Sportmassaaž", Definition = "Massaaž mõjub lõdvestavalt kurnatud lihaste, krooniliste valude ja ületreenituse ning üleväsimuse korral.", 
                ValidFrom = null, ValidTo = null, Price = "50€", Duration = "50 min"},
            new TreatmentData{Id = "13", TreatmentTypeId = "4", Name = "Klassikaline maniküür", Definition = "Ilma lakkimiseta", ValidFrom = null, ValidTo = null, Price = "28€", Duration = "1h"},
            new TreatmentData{Id = "14", TreatmentTypeId = "4", Name = "Klassikaline maniküür", Definition = "Lakkimisega", ValidFrom = null, ValidTo = null, Price = "30€", Duration = "1h"},
            new TreatmentData{Id = "15", TreatmentTypeId = "4", Name = "Geelküünte paigaldus", Definition = "Sisaldab aparaadimaniküüri", ValidFrom = null, ValidTo = null, Price = "65€", Duration = "2h 30 min"},
            new TreatmentData{Id = "16", TreatmentTypeId = "4", Name = "Geelküünte hooldus", Definition = "Sisaldab aparaadimaniküüri", ValidFrom = null, ValidTo = null, Price = "60€", Duration = "2h 30 min"},
            new TreatmentData{Id = "17", TreatmentTypeId = "5", Name = "Ripsmepikenduste paigaldamine", Definition = "NB! Vahetult pärast protseduuri tuleb vältida 24h jooksul silmade kokkupuudet veega!", ValidFrom = null, ValidTo = null, Price = "30€", Duration = "1h 30 min"},
            new TreatmentData{Id = "18", TreatmentTypeId = "5", Name = "Ripsmepikenduste hooldus", Definition = "NB! Vahetult pärast protseduuri tuleb vältida 24h jooksul silmade kokkupuudet veega!", ValidFrom = null, ValidTo = null, Price = "25€", Duration = "1h min"},
            new TreatmentData{Id = "19", TreatmentTypeId = "5", Name = "Ripsmete keemiline värvimine", Definition = "", ValidFrom = null, ValidTo = null, Price = "10€", Duration = "20 min"},
            new TreatmentData{Id = "20", TreatmentTypeId = "5", Name = "Lashlift", Definition = "Ripsmete koolutamine spetsiaaksete silikoonpatjade abil jätab loomuliku ja kauni koolutuse. Kauapüsiva tulemuse tagab spetsiaalne 3-etapiline kreemprotseduur, mis fikseerib ripsmed soovitud asendisse. Protseduur sisaldab ka ripsmete keemilist värvimist.",
                ValidFrom = null, ValidTo = null, Price = "30€", Duration = "45 min"},
            new TreatmentData{Id = "21", TreatmentTypeId = "6", Name = "Pidulik jumestus", Definition = "Õhtumeik, lavameik, pruudimeik jne", ValidFrom = null, ValidTo = null, Price = "50€", Duration = "1h 30 min"},
            new TreatmentData{Id = "22", TreatmentTypeId = "6", Name = "Päevameik", Definition = "", ValidFrom = null, ValidTo = null, Price = "25€", Duration = "45 min"},
            new TreatmentData{Id = "23", TreatmentTypeId = "6", Name = "Õhtu- ja stiilimeik", Definition = "Sisaldab ripsmetutikuid", ValidFrom = null, ValidTo = null, Price = "30€", Duration = "1h"},
            new TreatmentData{Id = "24", TreatmentTypeId = "6", Name = "Personaalne jumestusnõustamine", Definition = "", ValidFrom = null, ValidTo = null, Price = "60€", Duration = "1h 30 min"},

        };

        internal static List<TechnicianData>  Technicians => new List<TechnicianData>
        {
            new TechnicianData{Id = "1", TechnicianTypeId = "1", Name = "Annika Meier", AvailableDays = "Esmaspäev, Kolmapäev", WorkedYears = "5a"},
            new TechnicianData{Id = "2", TechnicianTypeId = "1", Name = "Katrin Kuldmaa", AvailableDays = "Esmaspäev, Reede, Laupäev", WorkedYears = "8a"},
            new TechnicianData{Id = "3", TechnicianTypeId = "1", Name = "Triin Rauts", AvailableDays = "Teisipäev, Kolmapäev", WorkedYears = "3a"},
            new TechnicianData{Id = "4", TechnicianTypeId = "1", Name = "Terje Laul", AvailableDays = "Teisipäev, Kolmapäev, Reede, Laupäev, Pühapäev", WorkedYears = "6a"},
            new TechnicianData{Id = "5", TechnicianTypeId = "2", Name = "Mai-Liis Müller", AvailableDays = "Teisipäev, Laupäev, Pühapäev", WorkedYears = "4a"},
            new TechnicianData{Id = "6", TechnicianTypeId = "2", Name = "Emma Pihlak", AvailableDays = "Esmaspäev, Reede, Pühapäev", WorkedYears = "6a"},
            new TechnicianData{Id = "7", TechnicianTypeId = "2", Name = "Erika Vinogradova", AvailableDays = "Neljapäev, Reede, Laupäev, Pühapäev", WorkedYears = "5a"},
            new TechnicianData{Id = "8", TechnicianTypeId = "2", Name = "Hanna-Liis Suvi", AvailableDays = "Teisipäev, Laupäev", WorkedYears = "8a"},
            new TechnicianData{Id = "9", TechnicianTypeId = "3", Name = "Maria Mägi", AvailableDays = "Esmaspäev, Teisipäev, Kolmapäev, Neljapäev, Reede", WorkedYears = "9a"},
            new TechnicianData{Id = "10", TechnicianTypeId = "3", Name = "Anna Ivanova", AvailableDays = "Neljapäev, Reede, Laupäev", WorkedYears = "4a"},
            new TechnicianData{Id = "11", TechnicianTypeId = "3", Name = "Sigrid Sööt", AvailableDays = "Kolmapäev, Laupäev, Pühapäev", WorkedYears = "8a"},
            new TechnicianData{Id = "12", TechnicianTypeId = "3", Name = "Kadri-Ann Saarepera", AvailableDays = "Teisipäev, Neljapäev", WorkedYears = "5a"},
            new TechnicianData{Id = "13", TechnicianTypeId = "4", Name = "Reelika Raag", AvailableDays = "Teisipäev, Laupäev, Pühapäev", WorkedYears = "3a"},
            new TechnicianData{Id = "14", TechnicianTypeId = "4", Name = "Kaisa Lust", AvailableDays = "Esmaspäev, Kolmapäev", WorkedYears = "6a"},
            new TechnicianData{Id = "15", TechnicianTypeId = "4", Name = "Laura Kaarma", AvailableDays = "Esmaspäev, Teisipäev, Reede, Laupäev", WorkedYears = "2a"},
            new TechnicianData{Id = "16", TechnicianTypeId = "4", Name = "Kristina Mülla", AvailableDays = "Neljapäev, Reede, Laupäev", WorkedYears = "2a"},
            new TechnicianData{Id = "17", TechnicianTypeId = "5", Name = "Liza Savostjanova", AvailableDays = "Kolmapäev, Reede, Pühapäev", WorkedYears = "4a"},
            new TechnicianData{Id = "18", TechnicianTypeId = "5", Name = "Carmen Soosepp", AvailableDays = "Esmaspäev, Teisipäev, Reede, Laupäev", WorkedYears = "6a"},
            new TechnicianData{Id = "19", TechnicianTypeId = "5", Name = "Mari-Ann Pauts", AvailableDays = "Neljapäev, Reede, Laupäev", WorkedYears = "1a"},
            new TechnicianData{Id = "20", TechnicianTypeId = "5", Name = "Gertrud Kask", AvailableDays = "Kolmapäev, Pühapäev", WorkedYears = "2a"},
            new TechnicianData{Id = "21", TechnicianTypeId = "6", Name = "Britt Koger", AvailableDays = "Esmaspäev, Teisipäev, Kolmapäev", WorkedYears = "6a"},
            new TechnicianData{Id = "22", TechnicianTypeId = "6", Name = "Nataly Veermaa", AvailableDays = "Esmaspäev, Laupäev", WorkedYears = "8a"},
            new TechnicianData{Id = "23", TechnicianTypeId = "6", Name = "Triin Saarmas", AvailableDays = "Neljapäev, Reede, Laupäev, Pühapäev", WorkedYears = "3a"},
            new TechnicianData{Id = "24", TechnicianTypeId = "6", Name = "Olga Aleksejeva", AvailableDays = "Teisipäev, Laupäev, Pühapäev", WorkedYears = "4a"},
        };

        internal static List<ClientData> Clients => new List<ClientData>
        {
            new ClientData{Id="1", MailAddress = "marimaasikas@gmail.com", Name = "Mari Maasikas", PhoneNumber = "53735654"},
            new ClientData{Id = "2", MailAddress = "karu.kati@gmail.com", Name = "Kati Karu",PhoneNumber = "5147778"},
            new ClientData{Id="3",MailAddress = "kajaluik@gmail.com", Name = "Kaja Luik", PhoneNumber = "56715954"},
            new ClientData{Id="4",MailAddress = "arturluik@gmail.com", Name = "Artur Luik", PhoneNumber = "56354357"},
            new ClientData{Id="5",MailAddress = "virve.magi@gmail.com", Name = "Virve Mägi", PhoneNumber = "5999745"},
            new ClientData{Id="6",MailAddress = "ml.kala@gmail.com", Name = "Marta Liisa Kala", PhoneNumber = "54989595"},
            new ClientData{Id="7",MailAddress = "kallas@gmail.com", Name = "Siiri Kala", PhoneNumber = "54955595"},
            new ClientData{Id="8",MailAddress = "Urmasmagler@gmail.com", Name = "Urmas Maaler", PhoneNumber = "551479295"},
            new ClientData{Id="9",MailAddress = "ml.kala@gmail.com", Name = "Marta Liisa Kala", PhoneNumber = "54989595"},
            new ClientData{Id="10",MailAddress = "mullaa@gmail.com", Name = "Anita Mulla", PhoneNumber = "51433355"},
            new ClientData{Id="11",MailAddress = "yllekaljus@gmail.com", Name = "Ülle Kaljus", PhoneNumber = "54987795"},
            new ClientData{Id="12",MailAddress = "ukumarkus@gmail.com", Name = "Uku-Markus Aisa", PhoneNumber = "54779595"},
        };

        internal static List<AppointmentData> Appointments => new List<AppointmentData>
        {
            new AppointmentData{Id="1", ClientId = "2", TreatmentId = "6", TechnicianId = "7", AppointmentDateTime = Convert.ToDateTime("03/06/2020 09:00")},
            new AppointmentData{Id="2", ClientId = "11", TreatmentId = "19", TechnicianId = "19", AppointmentDateTime = Convert.ToDateTime("04/06/2020 11:00")},
            new AppointmentData{Id="3", ClientId = "6", TreatmentId = "22", TechnicianId = "24", AppointmentDateTime = Convert.ToDateTime("05/06/2020 16:00")},
            new AppointmentData{Id="4", ClientId = "10", TreatmentId = "13", TechnicianId = "17", AppointmentDateTime = Convert.ToDateTime("05/06/2020 17:00")},
            new AppointmentData{Id="5", ClientId = "7", TreatmentId = "1", TechnicianId = "4", AppointmentDateTime = Convert.ToDateTime("06/06/2020 12:00")},
            new AppointmentData{Id="6", ClientId = "3", TreatmentId = "6", TechnicianId = "7", AppointmentDateTime = Convert.ToDateTime("12/06/2020 15:30")},
            new AppointmentData{Id="7", ClientId = "1", TreatmentId = "24", TechnicianId = "23", AppointmentDateTime = Convert.ToDateTime("12/06/2020 16:00")},
            new AppointmentData{Id="8", ClientId = "1", TreatmentId = "22", TechnicianId = "23", AppointmentDateTime = Convert.ToDateTime("12/06/2020 16:30")},
            new AppointmentData{Id="9", ClientId = "4", TreatmentId = "10", TechnicianId = "11", AppointmentDateTime = Convert.ToDateTime("13/06/2020 10:00")}


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
            InitializeAppointments(db);
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

        private static void InitializeAppointments(SalonDbContext db)
        {
            if (db.Appointments.Count() != 0) return;
            db.Appointments.AddRange(Appointments);
            db.SaveChanges();
        }
    }
}