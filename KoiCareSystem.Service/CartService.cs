using KoiCareSystem.BussinessObject;
using KoiCareSystem.DAO;
using Microsoft.EntityFrameworkCore;
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
        _orderDAO = orderDAO;
        _orderDetailDAO = orderDetailDAO;
        _foodItemDAO = foodItemDAO;
    }

    // Retrieve all cart items for the user's pending order
    public async Task<List<CartItem>> GetCartItemsAsync(int accountId)
    {
        var cart = await _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
        if (cart == null) return new List<CartItem>();

        return cart.OrderDetails.Select(od => new CartItem
        {
            FoodItemId = od.FoodItemId ?? 0,
            FoodName = od.FoodItem?.FoodName ?? "Unknown", // Map FoodName
            Price = od.Price ?? 0,
            Quantity = od.Quantity ?? 0,
           
        }).ToList();
    }


    // Add or update an item in the cart
    public async Task AddToCartAsync(int accountId, int foodItemId, int quantity)
    {
        var cart = await _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
        if (cart == null)
        {
            // If no pending order, create a new one
            cart = new Order
            {
                AccountId = accountId,
                Status = "Pending",
                OrderDate = DateTime.Now,
                TotalAmount = 0,
                OrderDetails = new List<OrderDetail>()
            };
            await _orderDAO.CreateOrderAsync(cart);
        }

        // Check if the item already exists in the cart
        var existingDetail = cart.OrderDetails.FirstOrDefault(od => od.FoodItemId == foodItemId);
        if (existingDetail != null)
        {
            // Update quantity if the item already exists
            existingDetail.Quantity += quantity;
        }
        else
        {
            // Add a new item to the order details
            var price = await GetFoodItemPriceAsync(foodItemId);
            var orderDetail = new OrderDetail
            {
                OrderId = cart.Id,
                FoodItemId = foodItemId,
                Quantity = quantity,
                Price = price
            };
            cart.OrderDetails.Add(orderDetail);
        }

        // Update the total amount for the cart
        cart.TotalAmount = cart.OrderDetails.Sum(d => d.Price * d.Quantity);
        await _orderDAO.UpdateOrderAsync(cart);
    }

    // Remove an item from the cart
    public async Task RemoveFromCartAsync(int accountId, int foodItemId)
    {
        var cart = await _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
        if (cart == null) return;

        var item = await _orderDetailDAO.GetOrderDetailAsync(cart.Id, foodItemId);
        if (item != null)
        {
            await _orderDetailDAO.DeleteOrderDetailAsync(item.Id);
            cart.TotalAmount = cart.OrderDetails.Sum(d => d.Price * d.Quantity);
            await _orderDAO.UpdateOrderAsync(cart);
        }
    }

    // Complete the order (checkout)
    public async Task CompleteOrderAsync(int accountId)
    {
        var cart = await _orderDAO.GetPendingOrderByAccountIdAsync(accountId);
        if (cart == null) return;

        cart.Status = "Completed";
        cart.OrderDate = DateTime.Now;
        await _orderDAO.UpdateOrderAsync(cart);
    }

    // Helper method to fetch the price of a food item
    private async Task<decimal> GetFoodItemPriceAsync(int foodItemId)
    {
        var foodItem = await _foodItemDAO.GetFoodItemByIdAsync(foodItemId);
        return foodItem?.Price ?? 0;
    }
}
