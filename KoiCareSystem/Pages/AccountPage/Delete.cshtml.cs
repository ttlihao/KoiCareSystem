using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.AccountPage
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DeleteModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = _accountService.GetAccountById(id); 

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = _accountService.GetAccountById(id);
            if (account != null)
            {
               _accountService.DeleteAccount(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
