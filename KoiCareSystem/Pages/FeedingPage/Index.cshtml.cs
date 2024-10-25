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
    public class IndexModel : PageModel
    {   
        private readonly IFeedingService feedingService;

        public IndexModel(IFeedingService feedingService)
        {
            this.feedingService = feedingService;
        }

        public IList<Feeding> Feeding { get;set; } = default!;

        public async Task OnGetAsync()
        {
            feedingService.GetListFeeding();
        }
    }
}
