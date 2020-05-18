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
    public class IndexModel : PageModel
    {
        private readonly Delux.Infra.SalonDbContext _context;

        public IndexModel(Delux.Infra.SalonDbContext context)
        {
            _context = context;
        }

        public IList<TechnicianData> TechnicianData { get;set; }

        public async Task OnGetAsync()
        {
            TechnicianData = await _context.Technicians.ToListAsync();
        }
    }
}
