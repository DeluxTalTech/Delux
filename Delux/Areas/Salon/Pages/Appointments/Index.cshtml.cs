using System.Threading.Tasks;
using Delux.Domain.Client;
using Delux.Domain.Reservation;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Pages.Reservation;
using Delux.Pages.Treatment;

namespace Delux.Delux.Areas.Salon.Pages.Appointments
{
    public class IndexModel : AppointmentsPage
    {
        public IndexModel(IAppointmentsRepository a, IClientsRepository c, ITreatmentsRepository tr, ITechniciansRepository te) : base(a, c, tr, te) { }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }
    }
}