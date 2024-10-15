using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CareSchedulePage
{
    public class CreateModel : PageModel
    {
        private readonly KoiCareSystem.BussinessObject.Models.CarekoisystemContext _context;
        private ICareScheduleService careScheduleService;
        public CreateModel(KoiCareSystem.BussinessObject.Models.CarekoisystemContext context, ICareScheduleService careScheduleService)
        {
            _context = context;
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await careScheduleService.AddCareSchedule(CareSchedule);

            return RedirectToPage("./Index");
        }
    }
}
