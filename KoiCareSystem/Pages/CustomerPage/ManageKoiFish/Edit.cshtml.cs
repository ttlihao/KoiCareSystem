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
using KoiCareSystem.Service.Interfaces;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.CustomerPage.ManageKoiFish
{
    public class EditModel : PageModel
    {
        private readonly IKoiFishService koiFishService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IKoiFishService koiFishService, IWebHostEnvironment webHostEnvironment)
        {
            this.koiFishService = koiFishService;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        [BindProperty]
        public IFormFile ImageFile { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ImageFile != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                var extension = Path.GetExtension(ImageFile.FileName);
                var newFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", newFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                KoiFish.ImagePath = "/images/" + newFileName;
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

            return RedirectToPage("/CustomerPage/Index");
        }

        private bool KoiFishExists(int id)
        {
            return koiFishService.GetKoiFishById(id) is not null;
        }
    }
}
