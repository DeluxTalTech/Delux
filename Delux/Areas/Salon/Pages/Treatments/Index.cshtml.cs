using System.Threading.Tasks;
using Delux.Domain.Treatment;
using Delux.Pages.Treatment;

namespace Delux.Delux.Areas.Salon.Pages.Treatments
{
    public class IndexModel : TreatmentsPage
    {
        public IndexModel(ITreatmentsRepository t, ITreatmentTypesRepository tt) : base(t, tt) { }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }
    }
}