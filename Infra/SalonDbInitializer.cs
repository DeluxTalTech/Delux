using System.Collections.Generic;
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

        };

        internal static List<TechnicianTypeData> TechnicianTypes => new List<TechnicianTypeData>
        {

        };
    }
}