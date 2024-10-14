using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject.Models;

namespace KoiCareSystem.Pages.CareSchedulePage
{
    public class DeleteModel : PageModel
    {
        private readonly KoiCareSystem.BussinessObject.Models.CarekoisystemContext _context;

        public DeleteModel(KoiCareSystem.BussinessObject.Models.CarekoisystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CareSchedule CareSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careschedule = await _context.CareSchedules.FirstOrDefaultAsync(m => m.Id == id);

            if (careschedule == null)
            {
                return NotFound();
            }
            else
            {
                CareSchedule = careschedule;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careschedule = await _context.CareSchedules.FindAsync(id);
            if (careschedule != null)
            {
                CareSchedule = careschedule;
                _context.CareSchedules.Remove(CareSchedule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
