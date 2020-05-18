using System.Threading.Tasks;
using Delux.Domain.Technician;
using Delux.Pages.Technician;

namespace Delux.Delux.Areas.Salon.Pages.Technicians
{
    public class IndexModel : TechniciansPage
    {
        public IndexModel(ITechniciansRepository t, ITechnicianTypesRepository tt) : base(t, tt) { }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }
    }
}