using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.PondPage
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
        ViewData["AccountId"] = new SelectList(accountService.GetAllAccounts(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Pond Pond { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                pondService.CreatePond(Pond);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
