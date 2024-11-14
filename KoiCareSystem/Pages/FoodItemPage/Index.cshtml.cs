using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.FoodItemPage
{
    public class IndexModel : PageModel
    {
        private readonly IFoodItemService _foodItemService;

        public IndexModel(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        // Properties for search and sort
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = string.Empty;

        public IList<FoodItem> FilteredFoodItems { get; set; } = new List<FoodItem>();

        // Load food items with search and sort applied
        public async Task<IActionResult> OnGetAsync()
        {
            // Get all food items
            var foodItems = await _foodItemService.GetAllFoodItemsAsync();

            // Filter by search term
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                foodItems = foodItems.Where(f => f.FoodName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sort food items
            foodItems = SortOrder switch
            {
                "name_asc" => foodItems.OrderBy(f => f.FoodName).ToList(),
                "name_desc" => foodItems.OrderByDescending(f => f.FoodName).ToList(),
                "price_asc" => foodItems.OrderBy(f => f.Price).ToList(),
                "price_desc" => foodItems.OrderByDescending(f => f.Price).ToList(),
                _ => foodItems
            };

            FilteredFoodItems = foodItems;
            return Page();
        }
    }
}
