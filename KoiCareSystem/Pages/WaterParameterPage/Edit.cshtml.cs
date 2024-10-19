﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject.Models;

namespace KoiCareSystem.Pages.WaterParameterPage
{
    public class EditModel : PageModel
    {
        private readonly KoiCareSystem.BussinessObject.Models.CarekoisystemContext _context;

        public EditModel(KoiCareSystem.BussinessObject.Models.CarekoisystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WaterParameter WaterParameter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterparameter =  await _context.WaterParameters.FirstOrDefaultAsync(m => m.PondId == id);
            if (waterparameter == null)
            {
                return NotFound();
            }
            WaterParameter = waterparameter;
           ViewData["PondId"] = new SelectList(_context.Ponds, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WaterParameter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaterParameterExists(WaterParameter.PondId))
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

        private bool WaterParameterExists(int id)
        {
            return _context.WaterParameters.Any(e => e.PondId == id);
        }
    }
}
