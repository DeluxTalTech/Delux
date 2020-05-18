using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Delux.Domain.Client;
using Delux.Pages.Client;

namespace Delux.Delux.Areas.Salon.Pages.Clients
{
    public class CreateModel : ClientsPage
    {
        public CreateModel(IClientsRepository r) : base(r) { }

        public IActionResult OnGet(string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            if (!await AddObject(fixedFilter, fixedValue)) return Page();
            return Redirect(IndexUrl);
        }
    }
}
