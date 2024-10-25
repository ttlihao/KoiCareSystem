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
    public class EditModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;

        public EditModel(IOrderService orderService, IAccountService accountService)
        {
            _orderService = orderService;
            _accountService = accountService;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
            ViewData["AccountId"] = new SelectList(_accountService.GetAllAccounts(), "Id", "Name");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _orderService.UpdateOrder(Order);

            return RedirectToPage("./Index");
        }
    }
}
