using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Delux.Facade.Common;

namespace Delux.Facade.Treatment
{
    public sealed class TreatmentView : DurationView
    {
        [Required]
        [DisplayName("Category")]
        public string TreatmentTypeId { get; set; }
    }
}
