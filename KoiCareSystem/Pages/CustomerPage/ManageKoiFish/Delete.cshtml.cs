using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;

namespace KoiCareSystem.Pages.CustomerPage.ManageKoiFish
{
    public class DeleteModel : PageModel
    {
        private readonly KoiCareSystem.DAO.CarekoisystemContext _context;

        public DeleteModel(KoiCareSystem.DAO.CarekoisystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifish = await _context.KoiFishes.FirstOrDefaultAsync(m => m.Id == id);

            if (koifish == null)
            {
                return NotFound();
            }
            else
            {
                KoiFish = koifish;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifish = await _context.KoiFishes.FindAsync(id);
            if (koifish != null)
            {
                KoiFish = koifish;
                _context.KoiFishes.Remove(KoiFish);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
