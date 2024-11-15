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
        private readonly VNPayService _vnPayService;

        // Constructor to inject dependencies
        public CartPageModel(CartService cartService, OrderDAO orderDAO, VNPayService vnPayService)
        {
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
            _orderDAO = orderDAO ?? throw new ArgumentNullException(nameof(orderDAO));
            _vnPayService = vnPayService ?? throw new ArgumentNullException(nameof(vnPayService));
        }

        // Property to store cart items
        public List<CartItem> CartItems { get; private set; } = new List<CartItem>();

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

            CartItems = await GetCartItemsAsync(accountId); // Ensure this fetches items correctly
            return Page();
        }

        private async Task<List<CartItem>> GetCartItemsAsync(int accountId)
        {
            var cart = await _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
            if (cart == null)
            {
                Console.WriteLine($"No pending cart found for account ID: {accountId}");
                return new List<CartItem>();
            }

            return cart.OrderDetails.Select(od => new CartItem
            {
                FoodItemId = od.FoodItemId ?? 0,
                FoodName = od.FoodItem?.FoodName ?? "Unknown",
                Price = od.Price ?? 0,
                Quantity = od.Quantity ?? 0
            }).ToList();
        }

        // Handle adding an item to the cart
        public async Task<IActionResult> OnPostAddToCartAsync(int foodItemId, int quantity)
        {
            if (quantity <= 0)
            {
                return new JsonResult(new { success = false, message = "Quantity must be greater than zero." });
            }

            int accountId = GetAccountId();
            if (accountId == 0)
            {
                return new JsonResult(new { success = false, message = "User not logged in." });
            }

            try
            {
                await _cartService.AddToCartAsync(accountId, foodItemId, quantity);
                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding item to cart: {ex.Message}");
                return new JsonResult(new { success = false, message = "Failed to add item to cart." });
            }
        }

        // Handle removing an item from the cart
        public class RemoveFromCartRequest
        {
            public int FoodItemId { get; set; }
        }

        public async Task<IActionResult> OnPostRemoveFromCartAsync([FromBody] RemoveFromCartRequest request)
        {
            Console.WriteLine($"Attempting to remove item with FoodItemId: {request.FoodItemId}");

            if (request.FoodItemId == 0)
            {
                Console.WriteLine("Invalid foodItemId received in the backend.");
                return new JsonResult(new { success = false, message = "Invalid item ID received." });
            }

            int accountId = GetAccountId();
            if (accountId == 0)
            {
                return new JsonResult(new { success = false, message = "User not logged in." });
            }

            try
            {
                await _cartService.RemoveFromCartAsync(accountId, request.FoodItemId);
                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing item from cart: {ex.Message}");
                return new JsonResult(new { success = false, message = "Failed to remove item from cart." });
            }
        }

        // Handle checkout with VNPay
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string Receiver { get; set; }

        public IActionResult OnPostCheckout()
        {
            int accountId = GetAccountId();
            if (accountId == 0)
            {
                return RedirectToPage("/Login");
            } 

            CartItems = GetCartItemsAsync(accountId).Result;
            decimal totalAmount = CartItems.Sum(item => item.Price * item.Quantity);

            if (!CartItems.Any() || totalAmount <= 0)
            {
                ModelState.AddModelError(string.Empty, "Your cart is empty or the total amount is invalid.");
                return Page();
            }

            try
            {
                string orderId = DateTime.Now.Ticks.ToString();
                string orderInfo = $"Payment for order {orderId}";

                string paymentUrl = _vnPayService.GenerateVnPayUrl(totalAmount, orderInfo, orderId);
                return Redirect(paymentUrl);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Failed to generate payment URL.");
                return Page();
            }
        }

        // Helper to retrieve the current user's account ID
        private int GetAccountId()
        {
            return HttpContext.Session.GetInt32("UserId") ?? 0;
        }
        //public async Task ProcessPaymentCallback(int orderId, bool paymentSuccessful)
        //{
        //    // Fetch the order using the orderId
        //    var order = await _orderDAO.GetOrderByIdAsync(orderId);

        //    if (order == null)
        //    {
        //        Console.WriteLine("Order not found.");
        //        return;
        //    }

        //    if (paymentSuccessful)
        //    {
        //        // Update the order status to "Completed"
        //        order.Status = "Completed";
        //        order.OrderDate = DateTime.Now; // Update order date if necessary
        //        await _orderDAO.UpdateOrderAsync(order);

        //        // Insert a new record into the Payment table
        //        var payment = new Payment
        //        {
        //            OrderId = order.Id,
        //            PaymentDate = DateTime.Now,
        //            Total = order.TotalAmount,
        //            Status = "Completed"
        //        };

        //        Console.WriteLine($"Payment processed successfully for Order ID: {orderId}. Order status updated and payment record created.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Payment failed.");
        //    }
        //}

    }
}
