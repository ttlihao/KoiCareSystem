using KoiCareSystem.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using KoiCareSystem.BussinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using KoiCareSystem.DAO;
using System;

namespace KoiCareSystem.Pages
{
    public class CartPageModel : PageModel
    {
        private readonly CartService _cartService;
        private readonly OrderDAO _orderDAO;

        // Inject CartService and OrderDAO in the constructor
        public CartPageModel(CartService cartService, OrderDAO orderDAO)
        {
            _cartService = cartService;
            _orderDAO = orderDAO;
        }

        // Property to store cart items
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        // Property to calculate total amount
        public decimal TotalAmount => CartItems.Sum(item => item.Price * item.Quantity);

        // Load the cart items when the page loads
        public async Task<IActionResult> OnGetAsync()
        {
            int accountId = GetAccountId();
            if (accountId == 0)
            {
                return RedirectToPage("/Login"); // Redirect if user is not logged in
            }

            CartItems = await GetCartItemsAsync(accountId);
            return Page();
        }

        // Get the cart items asynchronously for the given account ID
        public async Task<List<CartItem>> GetCartItemsAsync(int accountId)
        {
            var cart = await _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
            if (cart == null)
            {
                Console.WriteLine("No pending cart found for account ID: " + accountId);
                return new List<CartItem>();
            }
            var items = cart.OrderDetails.Select(od => new CartItem
            {
                FoodItemId = od.FoodItemId ?? 0,
                FoodName = od.FoodItem?.FoodName ?? "Unknown",
                Price = od.Price ?? 0,
                Quantity = od.Quantity ?? 0
            }).ToList();
            Console.WriteLine("Cart Items Count: " + items.Count);
            return items;
        }

        // Handle adding an item to the cart
        public async Task<IActionResult> OnPostAddToCartAsync(int foodItemId, int quantity)
        {
            if (quantity <= 0)
            {
                ModelState.AddModelError(string.Empty, "Quantity must be greater than zero.");
                return Page(); // Reload the page with validation error
            }

            int accountId = GetAccountId();
            if (accountId == 0)
            {
                return RedirectToPage("/Login"); // Redirect if user is not logged in
            }

            await _cartService.AddToCartAsync(accountId, foodItemId, quantity);
            return RedirectToPage(); // Reload page to show updated cart
        }

        // Handle removing an item from the cart
        public async Task<IActionResult> OnPostRemoveFromCartAsync(int foodItemId)
        {
            int accountId = GetAccountId();
            if (accountId == 0)
            {
                return RedirectToPage("/Login"); // Redirect if user is not logged in
            }

            await _cartService.RemoveFromCartAsync(accountId, foodItemId);
            return RedirectToPage(); // Reload page to show updated cart
        }

        // Handle checkout
        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            int accountId = GetAccountId();
            if (accountId == 0)
            {
                return RedirectToPage("/Login"); // Redirect if user is not logged in
            }

            await _cartService.CompleteOrderAsync(accountId);
            return RedirectToPage("OrderConfirmation"); // Redirect to a confirmation page
        }

        // Helper to retrieve the current user's account ID
        private int GetAccountId()
        {
            // Implement logic to retrieve the current user's account ID, e.g., from session or claims
            return HttpContext.Session.GetInt32("UserId") ?? 0; // Returns 0 if no user is logged in
        }
    }
}
