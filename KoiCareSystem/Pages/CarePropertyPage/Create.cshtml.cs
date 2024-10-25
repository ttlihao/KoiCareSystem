using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;

namespace KoiCareSystem.Pages.CareSchdulePage
{
    public class CreateModel : PageModel
    {
        private readonly KoiCareSystem.DAO.CarekoisystemContext _context;

        public CreateModel(KoiCareSystem.DAO.CarekoisystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ScheduleId"] = new SelectList(_context.CareSchedules, "Id", "Id");
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
