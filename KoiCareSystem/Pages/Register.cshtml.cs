using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystem.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IWebHostEnvironment _environment;

        public RegisterModel(IAccountService accountService, IWebHostEnvironment environment)
        {
            _accountService = accountService;
            _environment = environment;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        [BindProperty]
        public IFormFile AvatarFile { get; set; } // Thuộc tính cho file upload

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Xử lý file avatar upload nếu có
            if (AvatarFile != null)
            {
                var fileName = $"{Guid.NewGuid()}_{AvatarFile.FileName}"; // Đặt tên file duy nhất
                var filePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);

                // Tạo thư mục nếu chưa có
                Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "uploads"));

                // Lưu file vào thư mục
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await AvatarFile.CopyToAsync(stream);
                }

                // Lưu đường dẫn ảnh vào thuộc tính Avatar của Account
                Account.Avatar = $"/uploads/{fileName}";
            }

            try
            {
                Account.Role = "user";
                _accountService.Register(Account);
                return RedirectToPage("./Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}
