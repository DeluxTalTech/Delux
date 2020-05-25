using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Delux.Aids;
using Delux.Facade.Common;

namespace Delux.Facade.Reservation
{
    public sealed class AppointmentView : IdView
    {
        [Required]
        [DisplayName("Klient")]
        public string ClientId { get; set; }
        [Required]
        [DisplayName("Hooldus")]
        public string TreatmentId { get; set; }
        [Required]
        [DisplayName("Tegija")]
        public string TechnicianId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [MyDate] //custom datetime validation attribute
        [DisplayName("Broneeringu kuupäev ja kellaaeg")]
        public DateTime? AppointmentDateTime { get; set; }

        public string GetId()
        {
            return $"{ClientId}.{TreatmentId}.{TechnicianId}";
        }
    }
}
