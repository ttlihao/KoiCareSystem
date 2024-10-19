using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject.Models;

namespace KoiCareSystem.Pages.WaterParameterPage
{
    public class DeleteModel : PageModel
    {
        private readonly KoiCareSystem.BussinessObject.Models.CarekoisystemContext _context;

        public DeleteModel(KoiCareSystem.BussinessObject.Models.CarekoisystemContext context)
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

            var waterparameter = await _context.WaterParameters.FirstOrDefaultAsync(m => m.PondId == id);

            if (waterparameter == null)
            {
                return NotFound();
            }
            else
            {
                WaterParameter = waterparameter;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterparameter = await _context.WaterParameters.FindAsync(id);
            if (waterparameter != null)
            {
                WaterParameter = waterparameter;
                _context.WaterParameters.Remove(WaterParameter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
