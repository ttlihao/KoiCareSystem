using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage.ManagePond
{
    public class IndexModel : PageModel
    {
        private readonly IPondService pondService;

        public IndexModel(IPondService pondService)
        {
            this.pondService = pondService;
        }

        public IList<Pond> Pond { get; set; } = default!;

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
                Pond = pondService.GetPondsByAccountId(userId.Value);
            }
        }

    }
}



