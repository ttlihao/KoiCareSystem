﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage.ManageKoiFish
{
    public class DeleteModel : PageModel
    {
        private readonly IKoiFishService koiFishService;

        public DeleteModel(IKoiFishService koiFishService)
        {
            this.koiFishService = koiFishService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifish = koiFishService.GetKoiFishById(id);
            if (koifish != null)
            {
                KoiFish = koifish;
                koiFishService.DeleteKoiFish(id);
            }

            return RedirectToPage("/CustomerPage/Index");
        }
    }
}
