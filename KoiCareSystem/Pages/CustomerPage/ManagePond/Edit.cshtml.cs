using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage.ManagePond
{
    public class EditModel : PageModel
    {
        private readonly IPondService pondService;
        private readonly IAccountService accountService;

        public EditModel(IPondService pondService, IAccountService accountService)
        {
            this.pondService = pondService;
            this.accountService = accountService;
        }

        [BindProperty]
        public Pond Pond { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pond = pondService.GetPondById(id);
            if (pond == null)
            {
                return NotFound();
            }
            Pond = pond;
            int? accountId = HttpContext.Session.GetInt32("UserId");

            // If AccountId is null, redirect the user to the login page (or handle accordingly)
            if (!accountId.HasValue)
            {
                // Optionally, redirect to the login page if the user is not logged in
                return RedirectToPage("/Login");
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int? accountId = HttpContext.Session.GetInt32("UserId");
            if (!accountId.HasValue)
            {
                ModelState.AddModelError(string.Empty, "User is not logged in. Please log in first.");
                return Page();
            }

            try
            {
                // Retrieve and set the Account object
                var account = accountService.GetAccountById(accountId.Value);
                if (account == null)
                {
                    ModelState.AddModelError(string.Empty, "Account not found. Please log in again.");
                    return Page();
                }

                Pond.AccountId = accountId.Value;
                Pond.Account = account;  // Set the Account object
                Pond.Deleted = false;

                pondService.UpdatePond(Pond);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PondExists(Pond.Id))
                {
                    ModelState.AddModelError(string.Empty, "The pond could not be found. It may have been deleted.");
                    return NotFound();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An unexpected error occurred while updating the pond.");
                    throw;
                }
            }

            return RedirectToPage("/CustomerPage/Index");
        }




        private bool PondExists(int id)
        {
            return pondService.GetPondById(id) is not null;
        }
    }
}
