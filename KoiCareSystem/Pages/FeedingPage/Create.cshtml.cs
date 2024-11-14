using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.FeedingPage
{
    public class CreateModel : PageModel
    {
        private readonly IFeedingService feedingService;

        private readonly IPondFeedingService pondFeedingService;

        private readonly IPondService pondService;

        public CreateModel(IFeedingService feedingService, IPondFeedingService pondFeedingService, IPondService pondService)
        {
            this.feedingService = feedingService;
            this.pondFeedingService = pondFeedingService;
            this.pondService = pondService;
        }

        public IActionResult OnGet()
        {
            PondSelectList = new SelectList(pondService.GetAllPonds(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Feeding Feeding { get; set; } = default!;


        public SelectList PondSelectList { get; set; } = default!; // SelectList để truyền danh sách hồ




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
