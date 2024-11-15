using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystem.Pages
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

            // Lấy tài khoản từ cơ sở dữ liệu dựa trên email
            Account? account = _accountRepository.GetAccountByEmail(email);

            if (account != null)
            {
                // Kiểm tra trạng thái tài khoản
                    if (account.Status != "ACTIVE")
                      {
                      // Nếu tài khoản chưa kích hoạt, hiển thị thông báo yêu cầu xác minh email
                          ModelState.AddModelError(string.Empty, "Please check your email to verify your account!!");
                          return;
                      }
                // Kiểm tra mật khẩu
                if (account.Password.Equals(password))
                {
                    // Lưu thông tin người dùng vào session
                    HttpContext.Session.SetString("RoleID", account.Role.ToString());
                    HttpContext.Session.SetString("FullName", account.Name);
                    HttpContext.Session.SetString("AvatarUrl", account.Avatar);
                    HttpContext.Session.SetInt32("UserId", account.Id);

                    // Chuyển hướng dựa trên vai trò người dùng
                    if (account.Role.ToLower() == "admin")
                    {
                        Response.Redirect("/AccountPage/Index"); // Trang admin
                    }
                    else
                    {
                        Response.Redirect("/Index"); // Trang người dùng thông thường
                    }
                }
                else
                {
                    // Nếu mật khẩu không đúng
                    ModelState.AddModelError(string.Empty, "Invalid email or password. Please try again.");
                }
            }
            else
            {
                // Nếu không tìm thấy tài khoản với email này
                ModelState.AddModelError(string.Empty, "Email is not registered. Please register!!");
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
}
