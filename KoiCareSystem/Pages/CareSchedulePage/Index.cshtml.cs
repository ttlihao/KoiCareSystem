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
    public class IndexModel : PageModel
    {
        private readonly KoiCareSystem.BussinessObject.Models.CarekoisystemContext _context;

        public IndexModel(KoiCareSystem.BussinessObject.Models.CarekoisystemContext context)
        {
            _context = context;
        }

        public IList<CareSchedule> CareSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CareSchedule = await _context.CareSchedules
                .Include(c => c.Pond).ToListAsync();
        }
    }
}
