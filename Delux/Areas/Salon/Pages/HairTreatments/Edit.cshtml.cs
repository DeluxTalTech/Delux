﻿using System.Threading.Tasks;
using Delux.Domain.Treatment;
using Delux.Pages.Treatment;
using Microsoft.AspNetCore.Mvc;

namespace Delux.Delux.Areas.Salon.Pages.HairTreatments
{
    public class EditModel : HairTreatmentsPage
    {
        public EditModel(IHairTreatmentsRepository h) : base(h) { }

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