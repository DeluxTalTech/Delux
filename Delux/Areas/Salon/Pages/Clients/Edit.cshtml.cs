using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Delux.Domain.Client;
using Delux.Pages.Client;

namespace Delux.Delux.Areas.Salon.Pages.Clients
{
    public class EditModel : ClientsPage
    {
        public EditModel(IClientsRepository r) : base(r) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            await UpdateObject(fixedFilter, fixedValue);
            return Redirect(IndexUrl);
        }
    }
}
