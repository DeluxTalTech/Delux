using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class PeriodView : DefinitionView
    {
        [DataType(DataType.Date)]
        [DisplayName("Kehtib alates")]
        public DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Kehtib kuni")]
        public DateTime? ValidTo { get; set; }
    }
}
