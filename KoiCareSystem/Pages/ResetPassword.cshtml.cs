using KoiCareSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KoiCareSystem.Pages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IAccountService _accountService;

        public ResetPasswordModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty]
        [Required, Compare("NewPassword", ErrorMessage = "Passwords do not match"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public IActionResult OnGet()
        {
            // Ensure the user is logged in and has a session
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Retrieve user ID from session
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid session. Please log in again.");
                return RedirectToPage("/Login");
            }

            // Get user by ID
            var user = _accountService.GetAccountById(userId.Value);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                return Page();
            }

            // Reset password
            var resetResult = _accountService.ResetPassword(user.Id, NewPassword);

            if (!resetResult)
            {
                ModelState.AddModelError(string.Empty, "Password reset failed.");
                return Page();
            }
            // Notify the user and redirect to login
            TempData["Message"] = "Password has been reset successfully. Please log in with your new password.";
            return RedirectToPage("/Login");
        }
    }
}
