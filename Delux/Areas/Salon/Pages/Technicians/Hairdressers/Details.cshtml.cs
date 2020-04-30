using System.Threading.Tasks;
using Delux.Domain.Technician;
using Delux.Pages.Technician;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Areas.Salon.Pages.Technicians.Hairdressers
{
    public class DetailsModel : HairdressersPage
    {
        public DetailsModel(IHairdressersRepository b) : base(b) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }
    }
}
