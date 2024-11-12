using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCareSystem.BussinessObject;

namespace KoiCareSystem.Pages.FoodItemPage
{
    public class DetailsModel : PageModel
    {
        private readonly KoiCareSystem.DAO.CarekoisystemContext _context;

        public DetailsModel(KoiCareSystem.DAO.CarekoisystemContext context)
        {
            _context = context;
        }

        public FoodItem FoodItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodItem = await _context.FoodItems.FirstOrDefaultAsync(m => m.Id == id);
            if (foodItem == null)
            {
                return NotFound();
            }
            else
            {
                FoodItem = foodItem;
            }
            return Page();
        }
    }
}
