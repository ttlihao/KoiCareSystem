using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiCareSystem.Pages.FoodItemPage
{
    public class CreateModel : PageModel
    {
        private readonly IFoodItemService _foodItemService;

        public CreateModel(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _foodItemService.CreateFoodItemAsync(FoodItem);
            return RedirectToPage("./Index");
        }
    }
}
