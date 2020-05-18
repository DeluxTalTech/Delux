using System.Threading.Tasks;
using Delux.Domain.Technician;
using Delux.Pages.Technician;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Delux.Areas.Salon.Pages.Technicians
{
    public class EditModel : TechniciansPage
    {
        public EditModel(ITechniciansRepository t, ITechnicianTypesRepository tt) : base(t, tt) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            if (id == null) return NotFound();

            await GetObject(id, fixedFilter, fixedValue);
            if (Item == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            await UpdateObject(fixedFilter, fixedValue);
            return Redirect(IndexUrl);
        }
    }
}