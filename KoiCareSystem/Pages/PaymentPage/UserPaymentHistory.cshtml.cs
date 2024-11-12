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
            // L?y th�ng tin t�i kho?n ng??i d�ng d?a v�o userId
            var account = _accountRepository.GetAccountById(userId);
            if (account != null)
            {
                UserName = account.Name ?? "Unknown User"; // L?y t�n ng??i d�ng ho?c ?? tr?ng n?u kh�ng c�
            }
            else
            {
                UserName = "User Not Found";
            }

            // L?y l?ch s? thanh to�n c?a ng??i d�ng
            Payments = _paymentRepository.GetPaymentsByUserId(userId);
        }
    }
}
