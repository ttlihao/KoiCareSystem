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
    public class DeleteModel : PageModel
    {
        private readonly IWaterParameterService waterParameterService;

        public DeleteModel(IWaterParameterService waterParameterService)
        {
            this.waterParameterService = waterParameterService;
        }

        [BindProperty]
        public WaterParameter WaterParameter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterparameter = waterParameterService.GetWaterParameterByID(id);
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterparameter = waterParameterService.GetWaterParameterByID(id);
            if (waterparameter != null)
            {
                waterParameterService.DeleteWaterParameter(waterparameter);
            }

            return RedirectToPage("./Index");
        }
    }
}
