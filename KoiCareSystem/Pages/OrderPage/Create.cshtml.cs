using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.OrderPage
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;

        public CreateModel(IOrderService orderService, IAccountService accountService)
        {
            _orderService = orderService;
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            ViewData["AccountId"] = new SelectList(_accountService.GetAllAccounts(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _orderService.CreateOrder(Order);

            return RedirectToPage("./Index");
        }
    }
}
