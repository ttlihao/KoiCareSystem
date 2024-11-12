using KoiCareSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystem.Pages
{
    public class VerifyModel : PageModel
    {
        private readonly IAccountService _accountService;

        public VerifyModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet(string email, string token)
        {
            
                // Cập nhật trạng thái tài khoản thành "ACTIVE"
                _accountService.ActivateAccount(email);
                TempData["Message"] = "Your account has been successfully verified. You can now log in.";
                return RedirectToPage("/Login");
        }
    }
}
