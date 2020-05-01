using System.Threading.Tasks;
using Delux.Domain.Treatment;
using Delux.Pages.Treatment;

namespace Delux.Delux.Areas.Salon.Pages.HairTreatments
{
    public class IndexModel : HairTreatmentsPage
    {
        public IndexModel(IHairTreatmentsRepository h) : base(h) { }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }
    }
}
