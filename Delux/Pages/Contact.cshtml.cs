using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Delux.Delux.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public ContactModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
