using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.CareSchdulePage
{
    public class EditModel : PageModel
    {
        private ICarePropertyService carePropertyService;
        private ICareScheduleService careScheduleService;

        public EditModel(ICarePropertyService carePropertyService, ICareScheduleService careScheduleService)
        {
            this.carePropertyService = carePropertyService;
            this.careScheduleService = careScheduleService; 
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
            CareProperty = careproperty;
           ViewData["ScheduleId"] = new SelectList(await careScheduleService.GetCareSchedules(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            bool isSuccess;
            try
            {
                isSuccess = await carePropertyService.UpdateCareProperty(CareProperty);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await carePropertyService.GetCareProperty(CareProperty.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (!isSuccess)
            {
                return BadRequest("Update failed.");
            }

            return RedirectToPage("./Index");
        }
    }
}
