using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.FeedingPage
{
    public class DetailsModel : PageModel
    {
        private readonly IFeedingService feedingService;

        public DetailsModel(IFeedingService feedingService)
        {
            this.feedingService = feedingService;
        }

        public Feeding Feeding { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeding = feedingService.GetFeedingByPondID(id);
            if (feeding == null)
            {
                return NotFound();
            }
            else
            {
                Feeding = feeding;
            }
            return Page();
        }
    }
}
