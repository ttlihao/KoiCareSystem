using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CarePropertyPage
{
    public class CreateModel : PageModel
    {
        private readonly DAO.CarekoisystemContext _context;
        private readonly ICarePropertyService carePropertyService;
        private readonly ICareScheduleService careScheduleService;

        public CreateModel(DAO.CarekoisystemContext context, ICarePropertyService carePropertyService, ICareScheduleService careScheduleService)
        {
            _context = context;
            this.carePropertyService = carePropertyService;
            this.careScheduleService = careScheduleService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["ScheduleId"] = new SelectList(await careScheduleService.GetCareSchedules(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CareProperty CareProperty { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.CareProperties.Add(CareProperty);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
