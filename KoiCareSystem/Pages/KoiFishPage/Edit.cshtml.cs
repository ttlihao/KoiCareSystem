using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.KoiFishPage
{
    public class EditModel : PageModel
    {
        private readonly IKoiFishService koiFishService;

        public EditModel(IKoiFishService koiFishService)
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
            KoiFish = koifish;
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



            try
            {
               koiFishService.UpdateKoiFish(KoiFish);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoiFishExists(KoiFish.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KoiFishExists(int id)
        {
            return koiFishService.GetKoiFishById(id) is not null;
        }
    }
}
