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
using KoiCareSystem.DAO;

namespace KoiCareSystem.Pages.CustomerPage.ManageCareSchedule
{
    public class EditModel : PageModel
    {
        private ICareScheduleService careScheduleService;
        private readonly CarekoisystemContext context;

        public EditModel(ICareScheduleService careScheduleService, CarekoisystemContext context)
        {
            this.careScheduleService = careScheduleService;
            this.context = context;
        }

        [BindProperty]
        public CareSchedule CareSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careschedule = await careScheduleService.GetCareSchedule((int)id);
            if (careschedule == null)
            {
                return NotFound();
            }
            CareSchedule = careschedule;
            ViewData["PondId"] = new SelectList(context.Ponds, "Id", "Name");
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
                isSuccess = await careScheduleService.UpdateCareSchedule(CareSchedule);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await careScheduleService.GetCareSchedule(CareSchedule.Id) == null)
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

            return RedirectToPage("/CustomerPage/Index");
        }

    }
}
