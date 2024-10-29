using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.WaterParameterPage
{
    public class DetailsModel : PageModel
    {
        private readonly IWaterParameterService waterParameterService;

        public DetailsModel(IWaterParameterService water)
        {
            waterParameterService = water;
        }

        public WaterParameter WaterParameter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (waterParameterService.GetWaterParameterByID(id) == null)
            {
                return NotFound();
            }
            else
            {
                waterParameterService.GetWaterParameterByID(id);
            }
   
            return Page();
        }
    }
}
