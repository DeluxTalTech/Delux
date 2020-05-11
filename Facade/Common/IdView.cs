using System.ComponentModel.DataAnnotations;

namespace Delux.Facade.Common
{
    public abstract class IdView 
    {
        [Required] public string Id { get; set; }
    }
}
