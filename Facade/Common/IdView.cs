using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Delux.Facade.Common
{
    public abstract class IdView : DefinitionView
    {
        [Required] public string Id { get; set; }
    }
}
