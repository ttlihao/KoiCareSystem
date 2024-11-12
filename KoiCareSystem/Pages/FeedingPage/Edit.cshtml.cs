using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.FeedingPage
{
    public class EditModel : PageModel
    {
        private readonly IFeedingService feedingService;

        public EditModel(IFeedingService feedingService)
        {
            this.feedingService = feedingService;
        }

        [BindProperty]
        public Feeding Feeding { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeding =  feedingService.GetFeedingByPondID(id);
            if (feeding == null)
            {
                return NotFound();
            }
            Feeding = feeding;
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

            feedingService.UpdateFeeding(Feeding);

            return RedirectToPage("./Index");
        }


    }
}
