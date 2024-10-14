using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject.Models;

namespace KoiCareSystem.Pages.CareSchdulePage
{
    public class IndexModel : PageModel
    {
        private readonly KoiCareSystem.BussinessObject.Models.CarekoisystemContext _context;

        public IndexModel(KoiCareSystem.BussinessObject.Models.CarekoisystemContext context)
        {
            _context = context;
        }

        public IList<CareProperty> CareProperty { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CareProperty = await _context.CareProperties
                .Include(c => c.Schedule).ToListAsync();
        }
    }
}
