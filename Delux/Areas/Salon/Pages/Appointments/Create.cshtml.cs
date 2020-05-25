using System.Threading.Tasks;
using Delux.Domain.Client;
using Delux.Domain.Reservation;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Pages.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Delux.Areas.Salon.Pages.Appointments
{
    public class CreateModel : AppointmentsPage
    {
        public CreateModel(IAppointmentsRepository a, IClientsRepository c, ITreatmentsRepository tr, ITechniciansRepository te) : base(a, c, tr, te) { }

        public IActionResult OnGet(string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            if (!await AddObject(fixedFilter, fixedValue)) return Page();
            return Redirect(IndexUrl);
        }
    }
}