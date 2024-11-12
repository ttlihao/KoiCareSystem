using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using KoiCareSystem.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSystem.Pages.PaymentPage
{
    public class UserPaymentHistoryModel : PageModel
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAccountRepository _accountRepository;

        public UserPaymentHistoryModel(IPaymentRepository paymentRepository, IAccountRepository accountRepository)
        {
            _paymentRepository = paymentRepository;
            _accountRepository = accountRepository;
        }

        public List<Payment> Payments { get; set; } = new List<Payment>();
        public string UserName { get; set; } = string.Empty; // Display the user's name

        public void OnGet(int userId)
        {
            // L?y thông tin tài kho?n ng??i dùng d?a vào userId
            var account = _accountRepository.GetAccountById(userId);
            if (account != null)
            {
                UserName = account.Name ?? "Unknown User"; // L?y tên ng??i dùng ho?c ?? tr?ng n?u không có
            }
            else
            {
                UserName = "User Not Found";
            }

            // L?y l?ch s? thanh toán c?a ng??i dùng
            Payments = _paymentRepository.GetPaymentsByUserId(userId);
        }
    }
}
