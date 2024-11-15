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
    public class IndexModel : PageModel
    {
        private ICareScheduleService careScheduleService;

        public IndexModel(ICareScheduleService careScheduleService)
        {
            this.careScheduleService = careScheduleService;
        }

        public IList<CareSchedule> CareSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CareSchedule = await careScheduleService.GetCareSchedules();
        }
    }
}
