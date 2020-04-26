using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class IdView : DefinitionView
    {
        [Required] public string Id { get; set; }
    }
}
