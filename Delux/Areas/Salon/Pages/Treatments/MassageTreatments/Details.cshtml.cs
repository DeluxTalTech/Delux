using System.Threading.Tasks;
using Delux.Domain.Treatment;
using Delux.Pages.Treatment;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Areas.Salon.Pages.Treatments.MassageTreatments
{
    public class DetailsModel : MassageTreatmentsPage
    {
        public DetailsModel(IMassageTreatmentsRepository m) : base(m) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }
    }
}
