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

                if (accountId == null)
                {
                    ModelState.AddModelError(string.Empty, "User is not logged in.");
                    return Page();
                }

                Pond.AccountId = accountId.Value;
                Pond.Status = "ACTIVE";
                Pond.Account = accountService.GetAccountById(accountId.Value);
                if (Pond.Account == null)
                {
                    ModelState.AddModelError(string.Empty, "The specified account does not exist.");
                    return Page();
                }

                pondService.CreatePond(Pond);
            }
            catch (Exception ex)
            {
                // Add an error message to ModelState
                ModelState.AddModelError(string.Empty, $"Error: {ex.InnerException?.Message}"); // For debugging; remove in production
                return Page();
            }

            return RedirectToPage("/CustomerPage/Index");
        }

    }
}
