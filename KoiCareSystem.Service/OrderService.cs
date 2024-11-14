using KoiCareSystem.BussinessObject;
using KoiCareSystem.Repository;
using KoiCareSystem.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace KoiCareSystem.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        // Constructor with dependency injection for IOrderRepository
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Method to get or create an order based on accountId
        public async Task<Order> GetOrCreateOrderAsync(int accountId)
        {
            // Attempt to retrieve an existing open order by account ID
            var existingOrder = await _orderRepository.GetPendingOrderByAccountIdAsync(accountId);
            if (existingOrder != null)
            {
                return existingOrder;
            }

            // If no open order exists, create a new one with initial values
            var newOrder = new Order
            {
                AccountId = accountId,
                OrderDate = DateTime.Now,
                Status = "Pending", // Set to "Pending" to indicate it's an open cart
                TotalAmount = 0,
                OrderDetails = new List<OrderDetail>() // Initialize OrderDetails list
            };

            return await _orderRepository.CreateOrderAsync(newOrder);
        }

        // Method to add an order detail to an existing order
        public async Task AddOrderDetailAsync(int orderId, int itemId, int quantity, decimal price)
        {
            // Retrieve the existing order
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                throw new Exception("Order not found.");
            }

            // Check if the item already exists in the order to update quantity and total if necessary
            var existingDetail = order.OrderDetails?.FirstOrDefault(od => od.FoodItemId == itemId);
            if (existingDetail != null)
            {
                // Update the quantity and total for the existing order detail
                existingDetail.Quantity += quantity;
                existingDetail.Total += price * quantity;
            }
            else
            {
                // Create a new OrderDetail
                var orderDetail = new OrderDetail
                {
                    OrderId = orderId,
                    FoodItemId = itemId, // Assuming FoodItemId is the correct field name
                    Quantity = quantity,
                    Price = price,
                    Total = price * quantity
                };

                // Add the new OrderDetail to the order's details collection
                order.OrderDetails.Add(orderDetail);
            }

            // Update the total amount of the order
            order.TotalAmount = order.OrderDetails.Sum(od => od.Total);

            // Update the order in the repository
            await _orderRepository.UpdateOrderAsync(order);
        }
    }
}
