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
        public Pond Pond { get; set; } = default!;

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
            ViewData["AccountId"] = new SelectList(accountService.GetAllAccounts(), "Id", "Name");
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


            try
            {
                pondService.UpdatePond(Pond);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PondExists(Pond.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PondExists(int id)
        {
            return pondService.GetPondById(id) is not null;
        }
    }
}
