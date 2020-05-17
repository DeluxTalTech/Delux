using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Delux.Facade.Common;

namespace Delux.Facade.Reservation
{
    public sealed class AppointmentView : IdView
    {
        [Required]
        [DisplayName("Choose a customer")]
        public string ClientId { get; set; }
        [Required]
        [DisplayName("Choose a treatment")]
        public string TreatmentId { get; set; }
        [Required]
        [DisplayName("Choose a technician")]
        public string TechnicianId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Appointment Date")]
        public DateTime? AppointmentDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Appointment Time")]
        public DateTime? AppointmentTime { get; set; }

        public string GetId()
        {
            return $"{ClientId}.{TreatmentId}.{TechnicianId}";
        }
    }
}
