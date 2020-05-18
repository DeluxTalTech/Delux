using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Delux.Data.Technician;
using Delux.Infra;

namespace Delux.Delux
{
    public class CreateModel : PageModel
    {
        private readonly Delux.Infra.SalonDbContext _context;

        public CreateModel(Delux.Infra.SalonDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TechnicianData TechnicianData { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Technicians.Add(TechnicianData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
