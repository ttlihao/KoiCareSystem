using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using KoiCareSystem.Repository.Interfaces;
using KoiCareSystem.Service;
using KoiCareSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystem.Pages
{
    public class UserPaymentHistoryModel : PageModel
    {
        private readonly IPaymentService paymentService;
        private readonly IAccountService accountService;

        public UserPaymentHistoryModel(IPaymentService paymentService, IAccountService accountService)
        {
            this.paymentService = paymentService;
            this.accountService = accountService;
        }

        public List<Payment> Payments { get; set; } = new List<Payment>();
        public string UserName { get; set; } = string.Empty; // Display the user's name

        public void OnGet()
        {
            // Lấy thông tin userId từ session
            var userIdFromSession = HttpContext.Session.GetInt32("UserId");

            if (userIdFromSession.HasValue)
            {
                // get information of user
                var account = accountService.GetAccountById(userIdFromSession.Value);

                if (account != null)
                {
                    UserName = account.Name ?? "Unknown User"; //get user's name
                                                               
                    Payments = paymentService.GetPaymentsByUserId(account.Id); // get user's payment history
                }
                else
                {
                    UserName = "User Not Found";
                    Payments = new List<Payment>(); // return List empty
                }
            }
            else
            {
                // if there is not userId in session, display error
                UserName = "User Not Found";
                Payments = new List<Payment>(); // return Empty
            }
        }

    }
}
