using System.Threading.Tasks;
using Delux.Domain.Technician;
using Delux.Pages.Technician;

namespace Delux.Areas.Salon.Pages.Technicians.Beauticians
{
    public class IndexModel : BeauticiansPage
    {
        public IndexModel(IBeauticiansRepository b) : base(b) { }

        public async Task OnGetAsync(string sortOrder, 
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            SelectedId = id;
            await GetList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }
    }
}
