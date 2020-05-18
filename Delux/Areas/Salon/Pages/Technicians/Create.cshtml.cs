using System.Threading.Tasks;
using Delux.Domain.Technician;
using Delux.Domain.Technician;
using Delux.Pages.Technician;
using Delux.Pages.Treatment;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Delux.Areas.Salon.Pages.Technicians
{
    public class CreateModel : TechniciansPage
    {
        public CreateModel(ITechniciansRepository t, ITechnicianTypesRepository tt) : base(t, tt) { }

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
