﻿using System.Threading.Tasks;
using Delux.Domain.Treatment;
using Delux.Pages.Treatment;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Areas.Salon.Pages.Treatments.NailTreatments
{
    public class EditModel : NailTreatmentsPage
    {
        public EditModel(INailTreatmentsRepository r) : base(r) { }

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
