using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiCareSystem.Pages.FoodItemPage
{
    public class DeleteModel : PageModel
    {
        private readonly IFoodItemService _foodItemService;

        public DeleteModel(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodItem = await _foodItemService.GetFoodItemByIdAsync(id.Value);

            if (FoodItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _foodItemService.DeleteFoodItemAsync(id.Value);
            return RedirectToPage("./Index");
        }
    }
}
