using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages
{
    public class FoodItemShopModel : PageModel
    {
        private readonly IFoodItemService _foodItemService;
        private readonly IOrderService _orderService;

        public FoodItemShopModel(IFoodItemService foodItemService, IOrderService orderService)
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

        public async Task OnGetAsync()
        {
            // Retrieve all food items
            var foodItems = await _foodItemService.GetAllFoodItemsAsync();

            // Apply search filter if SearchTerm is not empty
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                foodItems = foodItems.Where(f => f.FoodName.Contains(SearchTerm, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Apply sorting based on SortOrder
            foodItems = SortOrder switch
            {
                "name_asc" => foodItems.OrderBy(f => f.FoodName).ToList(),
                "name_desc" => foodItems.OrderByDescending(f => f.FoodName).ToList(),
                "price_asc" => foodItems.OrderBy(f => f.Price).ToList(),
                "price_desc" => foodItems.OrderByDescending(f => f.Price).ToList(),
                _ => foodItems
            };

            FilteredFoodItems = foodItems;
        }

        // Handles adding items to the cart via AJAX
        public async Task<IActionResult> OnPostAddToCartAsync(int itemId, int quantity)
        {
            // Ensure quantity is valid
            if (quantity <= 0)
            {
                return new JsonResult(new { success = false, message = "Invalid quantity." });
            }

            // Retrieve the food item by ID
            var foodItem = await _foodItemService.GetFoodItemByIdAsync(itemId);

            // Check if the food item exists
            if (foodItem == null)
            {
                return new JsonResult(new { success = false, message = "Item not found." });
            }

            // Retrieve user account ID
            int accountId = GetUserAccountId();
            if (accountId == 0)
            {
                return new JsonResult(new { success = false, message = "User not logged in." });
            }

            // Get or create the user's order (cart)
            var order = await _orderService.GetOrCreateOrderAsync(accountId);

            // Add the item to the order with the specified quantity and price
            await _orderService.AddOrderDetailAsync(order.Id, itemId, quantity, foodItem.Price ?? 0);

            // Return JSON with a success message
            return new JsonResult(new { success = true, message = "Item added to cart successfully." });
        }

        // Helper to retrieve the current user's account ID from session
        private int GetUserAccountId()
        {
            return HttpContext.Session.GetInt32("UserId") ?? 0;
        }
    }
}
