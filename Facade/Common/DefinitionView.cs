using System.ComponentModel;

namespace Delux.Facade.Common
{
    public abstract class DefinitionView : NameView
    {
        [DisplayName("Kirjeldus")]
        public string Definition { get; set; }
    }
}
