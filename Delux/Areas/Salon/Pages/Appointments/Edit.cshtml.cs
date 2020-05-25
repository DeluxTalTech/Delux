using System.Threading.Tasks;
using Delux.Domain.Client;
using Delux.Domain.Reservation;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Pages.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Delux.Areas.Salon.Pages.Appointments
{
    public class EditModel : AppointmentsPage
    {
        public EditModel(IAppointmentsRepository a, IClientsRepository c, ITreatmentsRepository tr, ITechniciansRepository te) : base(a, c, tr, te) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            if (id == null) return NotFound();

            await GetObject(id, fixedFilter, fixedValue);
            if (Item == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            await UpdateObject(fixedFilter, fixedValue);
            return Redirect(IndexUrl);
        }
    }
}