using System.Threading.Tasks;
using Delux.Domain.Treatment;
using Delux.Pages.Treatment;

namespace Delux.Areas.Salon.Pages.Treatments.NailTreatments
{
    public class IndexModel : NailTreatmentsPage
    {
        public IndexModel(INailTreatmentsRepository r) : base(r) { }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }
    }
}
