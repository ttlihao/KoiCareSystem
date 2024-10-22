using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.WaterParameterPage
{
    public class EditModel : PageModel
    {
        private readonly IWaterParameterService waterParameterService;

        public EditModel(IWaterParameterService water)
        {
            waterParameterService = water;
        }

        [BindProperty]
        public WaterParameter WaterParameter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterparameter =  waterParameterService.GetWaterParameterByID(id);
            if (waterparameter == null)
            {
                return NotFound();
            }
            WaterParameter = waterparameter;
           ViewData["PondId"] = new SelectList(waterParameterService.GetListWaterParameters(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            waterParameterService.UpdateWaterParameter(WaterParameter);

            return RedirectToPage("./Index");
        }


    }
}
