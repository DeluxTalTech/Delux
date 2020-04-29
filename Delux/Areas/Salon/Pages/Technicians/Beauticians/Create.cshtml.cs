using System.Threading.Tasks;
using Delux.Domain.Technician;
using Delux.Pages.Technician;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Areas.Salon.Pages.Technicians.Beauticians
{
    public class CreateModel : BeauticiansPage
    {
        public CreateModel(IBeauticiansRepository b) : base(b) { }

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
