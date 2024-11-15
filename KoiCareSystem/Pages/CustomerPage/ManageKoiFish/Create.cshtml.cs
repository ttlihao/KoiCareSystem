using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage.ManageKoiFish
{
    public class CreateModel : PageModel
    {
        private readonly IKoiFishService koiFishService;
        private readonly IWebHostEnvironment environment;
        private readonly IPondService pondService;

        public CreateModel(IKoiFishService koiFishService, IWebHostEnvironment environment, IPondService pondService)
        {
            this.koiFishService = koiFishService;
            this.environment = environment;
            this.pondService = pondService;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        [BindProperty]
        public Pond Pond { get; set; } = default!;

        [BindProperty]
        public IFormFile ImageFile { get; set; } // Thuộc tính để lưu trữ file ảnh upload
        public SelectList PondSelectList { get; set; } = default!;

        [BindProperty]
        public int PondId { get; set; }

        public List<SelectListItem> AvailablePonds { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToPage("/Login");
            }

            // Fetch ponds that are not deleted
            var ponds = await pondService.GetPondsByAccountId(userId.Value);
            AvailablePonds = ponds.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

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
                var uploadsFolder = Path.Combine(environment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                KoiFish.ImagePath = $"/images/{fileName}";
            }

            KoiFish.HealthStatus = "Healthy";

            try
            {
                koiFishService.CreateKoiFish(KoiFish, PondId);
                return RedirectToPage("/CustomerPage/Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return Page();
        }
    }
}
