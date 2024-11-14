using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service;
using Microsoft.Identity.Client;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage.ManagePond
{
    public class CreateModel : PageModel
    {
        private readonly IPondService pondService;
        private readonly IAccountService accountService;

        public CreateModel(IPondService pondService, IAccountService accountService)
        {
            this.pondService = pondService;
            this.accountService = accountService;
        }

        public IActionResult OnGet()
        {
            int? accountId = HttpContext.Session.GetInt32("UserId");

            // If AccountId is null, redirect the user to the login page (or handle accordingly)
            if (!accountId.HasValue)
            {
                // Optionally, redirect to the login page if the user is not logged in
                return RedirectToPage("/Login");
            }

            return Page();
        }


        [BindProperty]
        public Pond Pond { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                int? accountId = HttpContext.Session.GetInt32("UserId");
                Pond.AccountId = accountId.Value;
                Pond.Account = accountService.GetAccountById(accountId.Value);
                pondService.CreatePond(Pond);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Page();
            }

            return RedirectToPage("/CustomerPage/Index");
        }
    }
}
