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
    public class DetailsModel : PageModel
    {
        private readonly KoiCareSystem.BussinessObject.Models.CarekoisystemContext _context;

        public DetailsModel(KoiCareSystem.BussinessObject.Models.CarekoisystemContext context)
        {
            _context = context;
        }

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
    }
}
