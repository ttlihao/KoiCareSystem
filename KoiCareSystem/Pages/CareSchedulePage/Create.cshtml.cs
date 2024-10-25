using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.CareSchedulePage
{
    public class CreateModel : PageModel
    {
        private IPondService pondService;
        private ICareScheduleService careScheduleService;
        public CreateModel(IPondService pondService, ICareScheduleService careScheduleService)
        {
            this.pondService = pondService;
            this.careScheduleService = careScheduleService;
        }

        public IActionResult OnGet()
        {
        ViewData["PondId"] = new SelectList(_context.Ponds, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CareSchedule CareSchedule { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            await careScheduleService.AddCareSchedule(CareSchedule);

            return RedirectToPage("./Index");
        }
    }
}
