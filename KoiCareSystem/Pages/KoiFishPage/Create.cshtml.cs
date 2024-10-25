using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.KoiFishPage
{
    public class CreateModel : PageModel
    {
        private readonly IKoiFishService koiFishService;

        public CreateModel(IKoiFishService koiFishService)
        {
            this.koiFishService = koiFishService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           koiFishService.CreateKoiFish(KoiFish);

            return RedirectToPage("./Index");
        }
    }
}
