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

namespace KoiCareSystem.Pages.PondPage
{
    public class DeleteModel : PageModel
    {
        private readonly IPondService pondService;

        public DeleteModel(IPondService pondService)
        {
            this.pondService = pondService;
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
            else
            {
                Pond = pond;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pond = pondService.GetPondById(id);
            if (pond != null)
            {
                Pond = pond;
                pondService.DeletePond(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
