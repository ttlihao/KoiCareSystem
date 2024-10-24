using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
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

            var careschedule = await careScheduleService.GetCareSchedule((int)id);

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

            var careschedule = await careScheduleService.GetCareSchedule((int)id);
            if (careschedule != null)
            {
                CareSchedule = careschedule;
                await careScheduleService.RemoveCareSchedule((int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
