using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;
using KoiCareSystem.Service;
using Microsoft.Identity.Client;

namespace KoiCareSystem.Pages.CustomerPage.FeedingPage
{
    public class IndexModel : PageModel
    {
        private readonly IFeedingService feedingService;

        public IndexModel(IFeedingService feedingService)
        {
            this.feedingService = feedingService;
        }

        public IList<Feeding> Feeding { get; set; } = default!;

        public async Task OnGetAsync()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                // Redirect to login if user ID is not in session
                RedirectToPage("/Login");
            }
            else
            {
                // Get ponds by account ID
                Feeding = feedingService.GetFeedingsByAccount(userId.Value);
            }
        }
    }
}
