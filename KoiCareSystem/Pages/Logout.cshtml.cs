using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystem.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            // Xóa thông tin người dùng khỏi Session
            HttpContext.Session.Remove("FullName");
            HttpContext.Session.Remove("AvatarUrl");
            HttpContext.Session.Remove("RoleID");
            HttpContext.Session.Remove("UserId");

            // Chuyển hướng về trang Login
            Response.Redirect("/Login");
        }
    }
}
