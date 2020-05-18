using System.Threading.Tasks;
using Delux.Domain.Client;
using Delux.Pages.Client;

namespace Delux.Delux.Areas.Salon.Pages.Clients
{
    public class IndexModel : ClientsPage
    {
        public IndexModel(IClientsRepository r) : base(r) { }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }
    }
}
