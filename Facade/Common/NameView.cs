using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class NameView : IdView
    {
        [Required] 
        [DisplayName("Nimi")]
        public string Name { get; set; }
    }
}
