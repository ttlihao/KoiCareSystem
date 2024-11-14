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

namespace KoiCareSystem.Pages.CustomerPage.ManageKoiFish
{
    public class IndexModel : PageModel
    {
        private readonly IKoiFishService koiFishService;

        public IndexModel(IKoiFishService koiFishService)
        {
            this.koiFishService = koiFishService;
        }

        public IList<KoiFish> KoiFish { get; set; } = default!;

        public async Task OnGetAsync()
        {
            KoiFish = koiFishService.GetAllKoiFish();
        }
    }
}
