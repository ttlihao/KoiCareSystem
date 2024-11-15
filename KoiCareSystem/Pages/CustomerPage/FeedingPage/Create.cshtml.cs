using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage.FeedingPage
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
            // Lấy danh sách các ao và khởi tạo PondSelectList
            int? userId = HttpContext.Session.GetInt32("UserId");
            PondSelectList = new SelectList(pondService.GetPondsByAccountId(userId.Value), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Feeding Feeding { get; set; } = default!;

        [BindProperty]
        public Pond Pond { get; set; } = default!;


        public SelectList PondSelectList { get; set; } = default!; // SelectList để truyền danh sách hồ


        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                int? accountId = HttpContext.Session.GetInt32("UserId");

                if (accountId == null)
                {
                    ModelState.AddModelError(string.Empty, "User is not logged in.");
                    return Page();
                }
                if (!ModelState.IsValid || feedingService.GetListFeeding() == null)
                {
                    return Page();
                }

                feedingService.AddFeeding(Feeding);

                pondFeedingService.AddPondFeeding(Feeding.Id, Pond.Id);
            }
            catch (Exception ex)
            {
                // Add an error message to ModelState
                ModelState.AddModelError(string.Empty, $"Error: {ex.InnerException?.Message}"); // For debugging; remove in production
                return Page();
            }


            return RedirectToPage("/CustomerPage/Index");
        }
    }
}
