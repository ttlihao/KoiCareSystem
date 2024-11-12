using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.PaymentPage
{
    public class IndexModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public IndexModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IList<Payment> Payment { get; set; } = new List<Payment>();

        public async Task OnGetAsync()
        {
            Payment = await _paymentService.GetAllPaymentsAsync();
        }

    }
}
