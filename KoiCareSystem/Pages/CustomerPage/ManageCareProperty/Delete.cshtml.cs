using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CustomerPage.ManageCareProperty
{
    public class DeleteModel : PageModel
    {
        private readonly ICarePropertyService carePropertyService;

        public DeleteModel(ICarePropertyService carePropertyService)
        {
            this.carePropertyService = carePropertyService;
        }

        [BindProperty]
        public CareProperty CareProperty { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careproperty = await carePropertyService.GetCareProperty((int)id);

            if (careproperty == null)
            {
                return NotFound();
            }
            else
            {
                CareProperty = careproperty;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careproperty = await carePropertyService.GetCareProperty((int)id);
            if (careproperty != null)
            {
                CareProperty = careproperty;
                await carePropertyService.RemoveCareProperty(CareProperty.Id);
            }

            return RedirectToPage("/CustomerPage/Index");
        }
    }
}
