using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiCareSystem.Pages.FoodItemPage
{
    public class IndexModel : PageModel
    {
        private readonly IFoodItemService _foodItemService;
        private readonly IOrderService _orderService;

        public IndexModel(IFoodItemService foodItemService, IOrderService orderService)
        {
            _foodItemService = foodItemService;
            _orderService = orderService;
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
            var foodItems = await _foodItemService.GetAllFoodItemsAsync();

            // Filter by search term
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                foodItems = foodItems.Where(f => f.FoodName.Contains(SearchTerm, System.StringComparison.OrdinalIgnoreCase)).ToList();
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


        public async Task<IActionResult> OnPostAddToCart(int itemId, int quantity)
        {
            var foodItem = await _foodItemService.GetFoodItemByIdAsync(itemId);

            if (foodItem == null)
            {
                return new JsonResult(new { success = false, message = "Item not found." });
            }

            int accountId = GetUserAccountId();
            var order = await _orderService.GetOrCreateOrderAsync(accountId);

            await _orderService.AddOrderDetailAsync(order.Id, itemId, quantity, foodItem.Price ?? 0);

            // Return JSON with success message
            return new JsonResult(new { success = true, message = "Item added to cart successfully." });
        }





        private int GetUserAccountId()
        {
            // Replace this with actual logic to get the logged-in user's account ID
            return HttpContext.Session.GetInt32("UserId") ?? 0;
        }
    }
}
