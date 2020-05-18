using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Delux.Data.Technician;
using Delux.Infra;

namespace Delux.Delux
{
    public class EditModel : PageModel
    {
        private readonly Delux.Infra.SalonDbContext _context;

        public EditModel(Delux.Infra.SalonDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TechnicianData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicianDataExists(TechnicianData.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TechnicianDataExists(string id)
        {
            return _context.Technicians.Any(e => e.Id == id);
        }
    }
}
