using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CareSchedulePage
{
    public class DeleteModel : PageModel
    {
        private ICareScheduleService careScheduleService;

        public DeleteModel(ICareScheduleService careScheduleService)
        {
        this.careScheduleService = careScheduleService;
        }

        [BindProperty]
        public CareSchedule CareSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careschedule = await careScheduleService.GetCareSchedule(id);

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
