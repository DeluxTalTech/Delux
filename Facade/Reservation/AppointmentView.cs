using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Delux.Facade.Common;

namespace Delux.Facade.Reservation
{
    public sealed class AppointmentView : IdView
    {
        [Required]
        [DisplayName("Vali klient")]
        public string ClientId { get; set; }
        [Required]
        [DisplayName("Vali hooldus")]
        public string TreatmentId { get; set; }
        [Required]
        [DisplayName("Vali tegija")]
        public string TechnicianId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Broneeringu kuupäev")]
        public DateTime? AppointmentDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Broneeringu kellaaeg")]
        public DateTime? AppointmentTime { get; set; }

        public string GetId()
        {
            return $"{ClientId}.{TreatmentId}.{TechnicianId}";
        }
    }
}
