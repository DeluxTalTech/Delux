using System.Threading.Tasks;
using Delux.Domain.Client;
using Delux.Domain.Reservation;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Pages.Reservation;
using Delux.Pages.Treatment;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Delux.Areas.Salon.Pages.Appointments
{

    public class DeleteModel : AppointmentsPage
    {

        public DeleteModel(IAppointmentsRepository a, IClientsRepository c, ITreatmentsRepository tr, ITechniciansRepository te) : base(a, c, tr, te) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string fixedFilter, string fixedValue)
        {
            await DeleteObject(id, fixedFilter, fixedValue);

            return Redirect(IndexUrl);
        }

    }

}