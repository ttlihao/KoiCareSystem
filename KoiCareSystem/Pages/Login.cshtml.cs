using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystem.Pages.AccountPage
{
    public class LoginModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public LoginModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        public void OnPost()
        {
            string email = Request.Form["txtEmail"];
            string password = Request.Form["txtPassword"];

            Account? account = _accountRepository.GetAccountByEmail(email);

            if (account != null && account.Password.Equals(password))
            {
                // Store user information in Session
                HttpContext.Session.SetString("RoleID", account.Role.ToString());
                HttpContext.Session.SetString("FullName", account.Name);
                HttpContext.Session.SetString("AvatarUrl", account.Avatar);
                HttpContext.Session.SetInt32("UserId", account.Id);

                // Redirect based on role
                if (account.Role.ToLower() == "admin")
                {
                    Response.Redirect("/AccountPage/Index"); // Admin page
                }
                else
                {
                    Response.Redirect("/Index"); // Default page for other roles
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password. Please try again.");
            }
        }



        //private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        //{
        //    // Mã hóa mật khẩu đã nhập và so sánh với mật khẩu mã hóa lưu trong cơ sở dữ liệu
        //    using (var sha256 = System.Security.Cryptography.SHA256.Create())
        //    {
        //        var bytes = System.Text.Encoding.UTF8.GetBytes(enteredPassword);
        //        var hash = sha256.ComputeHash(bytes);
        //        var enteredPasswordHash = Convert.ToBase64String(hash);
        //        return enteredPasswordHash == storedPasswordHash;
        //    }
        //}
    }
}
