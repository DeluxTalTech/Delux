using System.ComponentModel;

namespace Delux.Facade.Common
{
    public abstract class DefinitionView : NameView
    {
        [DisplayName("Description")]
        public string Definition { get; set; }
    }
}
