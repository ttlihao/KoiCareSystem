using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;

namespace KoiCareSystem.Pages.CareSchdulePage
{
    public class EditModel : PageModel
    {
        private readonly KoiCareSystem.DAO.CarekoisystemContext _context;

        public EditModel(KoiCareSystem.DAO.CarekoisystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CareProperty CareProperty { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careproperty =  await _context.CareProperties.FirstOrDefaultAsync(m => m.Id == id);
            if (careproperty == null)
            {
                return NotFound();
            }
            CareProperty = careproperty;
           ViewData["ScheduleId"] = new SelectList(_context.CareSchedules, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Attach(CareProperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarePropertyExists(CareProperty.Id))
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

        private bool CarePropertyExists(int id)
        {
            return _context.CareProperties.Any(e => e.Id == id);
        }
    }
}
