using System.Threading.Tasks;
using Delux.Domain.Technician;
using Delux.Pages.Technician;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Areas.Salon.Pages.Technicians.Masseuses
{

    public class DeleteModel : MasseusesPage
    {

        public DeleteModel(IMasseusesRepository b) : base(b) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string fixedFilter, string fixedValue)
        {
            await DeleteObject(id, fixedFilter, fixedValue);

            return Redirect(IndexUrl);
        }

    }

}