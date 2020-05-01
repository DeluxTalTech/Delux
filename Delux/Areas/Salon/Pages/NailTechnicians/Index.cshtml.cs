using System.Threading.Tasks;
using Delux.Domain.Technician;
using Delux.Pages.Technician;

namespace Delux.Delux.Areas.Salon.Pages.NailTechnicians
{
    public class IndexModel : NailTechniciansPage
    {
        public IndexModel(INailTechniciansRepository n) : base(n) { }

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
