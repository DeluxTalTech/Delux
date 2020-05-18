using System.Threading.Tasks;
using Delux.Domain.Technician;
using Delux.Pages.Technician;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Delux.Areas.Salon.Pages.Technicians
{

    public class DeleteModel : TechniciansPage
    {

        public DeleteModel(ITechniciansRepository t, ITechnicianTypesRepository tt) : base(t, tt) { }

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