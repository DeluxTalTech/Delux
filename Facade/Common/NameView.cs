using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class NameView : IdView
    {
        [Required] public string Name { get; set; }
    }
}
