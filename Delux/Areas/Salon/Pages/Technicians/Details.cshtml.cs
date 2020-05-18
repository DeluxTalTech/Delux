using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Delux.Data.Technician;
using Delux.Infra;

namespace Delux.Delux
{
    public class DetailsModel : PageModel
    {
        private readonly Delux.Infra.SalonDbContext _context;

        public DetailsModel(Delux.Infra.SalonDbContext context)
        {
            _context = context;
        }

        public TechnicianData TechnicianData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TechnicianData = await _context.Technicians.FirstOrDefaultAsync(m => m.Id == id);

            if (TechnicianData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
