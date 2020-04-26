using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class NameView
    {
        [Required] public string Name { get; set; }
    }
}
