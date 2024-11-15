using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service;
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

        public async Task<IActionResult> OnGet()
        {
            // Lấy danh sách các ao và khởi tạo PondSelectList
            int? userId = HttpContext.Session.GetInt32("UserId");
            PondSelectList = new SelectList(await pondService.GetPondsByAccountId(userId.Value), "Id", "Name");
            return Page();
        }


        // Xử lý post để tạo cá Koi mới

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Xử lý lưu ảnh nếu người dùng chọn ảnh
            if (ImageFile != null)
            {
                // Thư mục để lưu ảnh (trong wwwroot/images)
                var uploadsFolder = Path.Combine(environment.WebRootPath, "images");

                // Đảm bảo thư mục tồn tại
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Tạo tên file duy nhất để tránh trùng lặp
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Lưu file ảnh lên server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                // Cập nhật thuộc tính ImageUrl của KoiFish với đường dẫn ảnh
                KoiFish.ImagePath = $"/images/{fileName}";
            }

            // Gọi service để tạo mới cá Koi
            koiFishService.CreateKoiFish(KoiFish);


            return RedirectToPage("/CustomerPage/Index");
        }
    }
}
