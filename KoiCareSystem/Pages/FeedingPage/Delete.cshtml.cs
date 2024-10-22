using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;

namespace KoiCareSystem.Pages.FeedingPage
{
    public class DeleteModel : PageModel
    {
        private readonly KoiCareSystem.DAO.CarekoisystemContext _context;

        public DeleteModel(KoiCareSystem.DAO.CarekoisystemContext context)
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

            var feeding = await _context.Feedings.FirstOrDefaultAsync(m => m.Id == id);

            if (feeding == null)
            {
                return NotFound();
            }
            else
            {
                Feeding = feeding;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeding = await _context.Feedings.FindAsync(id);
            if (feeding != null)
            {
                Feeding = feeding;
                _context.Feedings.Remove(Feeding);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
