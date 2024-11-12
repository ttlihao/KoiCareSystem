using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.PaymentPage
{
    public class CreateModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public CreateModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [BindProperty]
        public Payment Payment { get; set; } = default!;

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

            _paymentService.AddPayment(Payment);

            return RedirectToPage("./Index");
        }
    }
}
