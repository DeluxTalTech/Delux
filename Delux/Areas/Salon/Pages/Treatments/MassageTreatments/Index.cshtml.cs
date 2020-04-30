using System.Threading.Tasks;
using Delux.Domain.Treatment;
using Delux.Pages.Treatment;

namespace Delux.Areas.Salon.Pages.Treatments.MassageTreatements
{
    public class IndexModel : MassageTreatmentsPage
    {
        public IndexModel(IMassageTreatmentsRepository r) : base(r) { }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }
    }
}
