using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Repository.Interfaces;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.WaterParameterPage
{
    public class CreateModel : PageModel
    {
        private readonly IWaterParameterService waterParameterservice;

        public CreateModel(IWaterParameterService water)
        {
            waterParameterservice = water;
        }

        public IActionResult OnGet()
        {
        ViewData["PondId"] = new SelectList(waterParameterservice.GetListWaterParameters(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public WaterParameter WaterParameter { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || waterParameterservice.GetListWaterParameters() == null || WaterParameter == null)
            {
                return Page();
            }

            waterParameterservice.AddWaterParameter(WaterParameter);

            return RedirectToPage("./Index");
        }
    }
}
