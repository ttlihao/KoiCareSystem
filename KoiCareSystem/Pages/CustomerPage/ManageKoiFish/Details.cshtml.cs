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

namespace KoiCareSystem.Pages.CustomerPage.ManageKoiFish
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiFishService koiFishService;

        public DetailsModel(IKoiFishService koiFishService)
        {
            this.koiFishService = koiFishService;
        }

        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifish = koiFishService.GetKoiFishById(id);
            if (koifish == null)
            {
                return NotFound();
            }
            else
            {
                KoiFish = koifish;
            }
            return Page();
        }
    }
}
