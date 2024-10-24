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
    public class DetailsModel : PageModel
    {
        private ICareScheduleService careScheduleService;

        public DetailsModel(ICareScheduleService careScheduleService)
        {
            this.careScheduleService = careScheduleService;
        }

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
    }
}
