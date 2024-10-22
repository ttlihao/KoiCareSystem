using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject.Models;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.FeedingPage
{
    public class CreateModel : PageModel
    {
        private readonly IFeedingService feedingService;

        public CreateModel(IFeedingService feedingService)
        {
            this.feedingService = feedingService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Feeding Feeding { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || feedingService.GetListFeeding()== null)
            {
                return Page();
            }

            feedingService.AddFeeding(Feeding);

            return RedirectToPage("./Index");
        }
    }
}
