using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CartService
{
    private readonly OrderDAO _orderDAO;
    private readonly OrderDetailDAO _orderDetailDAO;
    private readonly FoodItemDAO _foodItemDAO;

    public CartService(OrderDAO orderDAO, OrderDetailDAO orderDetailDAO, FoodItemDAO foodItemDAO)
    {
        _orderDAO = orderDAO ?? throw new ArgumentNullException(nameof(orderDAO));
        _orderDetailDAO = orderDetailDAO ?? throw new ArgumentNullException(nameof(orderDetailDAO));
        _foodItemDAO = foodItemDAO ?? throw new ArgumentNullException(nameof(foodItemDAO));
    }

    // Retrieve all cart items for the user's pending order
    public async Task<List<CartItem>> GetCartItemsAsync(int accountId)
    {
        var cart = await _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
        if (cart == null)
        {
            Console.WriteLine("No pending cart found for account ID: " + accountId);
            return new List<CartItem>();
        }

        var cartItems = cart.OrderDetails.Select(od => new CartItem
        {
            FoodItemId = od.FoodItemId ?? 0,
            FoodName = od.FoodItem?.FoodName ?? "Unknown",
            Price = od.Price ?? 0,
            Quantity = od.Quantity ?? 0
        }).ToList();

        Console.WriteLine($"Retrieved {cartItems.Count} items for account ID: {accountId}");
        return cartItems;
    }

    // Add or update an item in the cart
    public async Task AddToCartAsync(int accountId, int foodItemId, int quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("Quantity must be greater than zero.");
            return;
        }

        var cart = await _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
        if (cart == null)
        {
            // Create a new cart if no pending order exists
            cart = new Order
            {
                AccountId = accountId,
                Status = "Pending",
                OrderDate = DateTime.Now,
                TotalAmount = 0,
                OrderDetails = new List<OrderDetail>()
            };
            await _orderDAO.CreateOrderAsync(cart);
            Console.WriteLine($"Created a new cart for account ID: {accountId}");
        }

        // Find existing item or add new one
        var existingDetail = cart.OrderDetails.FirstOrDefault(od => od.FoodItemId == foodItemId);
        if (existingDetail != null)
        {
            existingDetail.Quantity += quantity;
            Console.WriteLine($"Updated quantity of FoodItemId {foodItemId} to {existingDetail.Quantity} in cart for account ID {accountId}");
        }
        else
        {
            var price = await GetFoodItemPriceAsync(foodItemId);
            cart.OrderDetails.Add(new OrderDetail
            {
                OrderId = cart.Id,
                FoodItemId = foodItemId,
                Quantity = quantity,
                Price = price
            });
            Console.WriteLine($"Added FoodItemId {foodItemId} to cart for account ID {accountId} with quantity {quantity}");
        }

        // Update total amount and save
        cart.TotalAmount = cart.OrderDetails.Sum(d => d.Price * d.Quantity);
        await _orderDAO.UpdateOrderAsync(cart);
        Console.WriteLine($"Cart updated successfully for account ID: {accountId} with total amount: {cart.TotalAmount}");
    }

    // Remove an item from the cart
    public async Task RemoveFromCartAsync(int accountId, int foodItemId)
    {
        var cart = await _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
        if (cart == null)
        {
            Console.WriteLine("No pending cart found for account ID: " + accountId);
            return;
        }

        // Log cart details before attempting deletion
        Console.WriteLine($"Attempting to delete OrderDetail for order {cart.Id} and food item {foodItemId}");

        // Ensure foodItemId being passed is correct
        bool deleteResult = await _orderDetailDAO.DeleteOrderDetailByOrderAndItemAsync(cart.Id, foodItemId);

        if (deleteResult)
        {
            // Update the cart total only if an item was removed
            cart.TotalAmount = cart.OrderDetails.Sum(d => d.Price * d.Quantity);
            await _orderDAO.UpdateOrderAsync(cart);
            Console.WriteLine($"OrderDetail for FoodItemId {foodItemId} removed successfully from account ID {accountId}'s cart.");
        }
        else
        {
            Console.WriteLine($"OrderDetail for FoodItemId {foodItemId} was not found in account ID {accountId}'s cart.");
        }
    }


    // Complete the order (checkout)
    public async Task CompleteOrderAsync(int accountId)
    {
        var cart = await _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
        if (cart == null)
        {
            Console.WriteLine("No pending cart found for account ID: " + accountId);
            return;
        }

        cart.Status = "Completed";
        cart.OrderDate = DateTime.Now;
        await _orderDAO.UpdateOrderAsync(cart);
        Console.WriteLine($"Order completed successfully for account ID: {accountId} on {cart.OrderDate}");
    }

    // Helper method to fetch the price of a food item
    private async Task<decimal> GetFoodItemPriceAsync(int foodItemId)
    {
        var foodItem = await _foodItemDAO.GetFoodItemByIdAsync(foodItemId);
        if (foodItem == null)
        {
            Console.WriteLine($"Food item with ID {foodItemId} not found.");
            return 0;
        }
        return foodItem.Price ?? 0;
    }

}
