using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;

namespace KoiCareSystem.Pages.FeedingPage
{
    public class EditModel : PageModel
    {
        private readonly KoiCareSystem.DAO.CarekoisystemContext _context;

        public EditModel(KoiCareSystem.DAO.CarekoisystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Feeding Feeding { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeding =  await _context.Feedings.FirstOrDefaultAsync(m => m.Id == id);
            if (feeding == null)
            {
                return NotFound();
            }
            Feeding = feeding;
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

            _context.Attach(Feeding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedingExists(Feeding.Id))
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

        private bool FeedingExists(int id)
        {
            return _context.Feedings.Any(e => e.Id == id);
        }
    }
}
