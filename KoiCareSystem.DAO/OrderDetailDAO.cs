using KoiCareSystem.BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.DAO
{
    public class OrderDetailDAO
    {
        private readonly CarekoisystemContext _context;

        public OrderDetailDAO(CarekoisystemContext context)
        {
            _context = context;
        }

     
        public async Task CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            try
            {
                await _context.OrderDetails.AddAsync(orderDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating order detail: {ex.Message}");
            }
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            try
            {
                return await _context.OrderDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving order details: {ex.Message}");
                return new List<OrderDetail>();
            }
        }

        public async Task<OrderDetail?> GetOrderDetailByIdAsync(int id)
        {
            try
            {
                return await _context.OrderDetails.FirstOrDefaultAsync(od => od.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving order detail by id: {ex.Message}");
                return null;
            }
        }

        public async Task<OrderDetail?> GetOrderDetailAsync(int orderId, int foodItemId)
        {
            try
            {
                return await _context.OrderDetails
                                     .FirstOrDefaultAsync(od => od.OrderId == orderId && od.FoodItemId == foodItemId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving order detail by OrderId and FoodItemId: {ex.Message}");
                return null;
            }
        }

        // Update an existing OrderDetail in the database
        public async Task UpdateOrderDetailAsync(OrderDetail updatedOrderDetail)
        {
            try
            {
                var existingOrderDetail = await _context.OrderDetails.FirstOrDefaultAsync(od => od.Id == updatedOrderDetail.Id);
                if (existingOrderDetail != null)
                {
                    var existingOrderDetail = context.OrderDetails.FirstOrDefault(od => od.Id == updatedOrderDetail.Id);
                    if (existingOrderDetail != null)
                    {
                        existingOrderDetail.OrderId = updatedOrderDetail.OrderId;
                        existingOrderDetail.FoodItemId = updatedOrderDetail.FoodItemId;
                        existingOrderDetail.Price = updatedOrderDetail.Price;
                        existingOrderDetail.Quantity = updatedOrderDetail.Quantity;
                        existingOrderDetail.Total = updatedOrderDetail.Total;

                    await _context.SaveChangesAsync();
                    Console.WriteLine("OrderDetail updated successfully.");
                }
                else
                {
                    Console.WriteLine($"Order detail with ID {updatedOrderDetail.Id} not found for update.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating order detail: {ex.Message}");
            }
        }

        public async Task DeleteOrderDetailAsync(int id)
        {
            Console.WriteLine($"Attempting to delete OrderDetail with ID {id}...");
            try
            {
                var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(od => od.Id == id);
                if (orderDetail != null)
                {
                    _context.OrderDetails.Remove(orderDetail);
                    await _context.SaveChangesAsync();
                    Console.WriteLine("OrderDetail deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"OrderDetail with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting OrderDetail: {ex.Message}");
            }
        }

        // Log all OrderDetail records for a specific OrderId
        public async Task LogOrderDetailsForOrderAsync(int orderId)
        {
            try
            {
                var orderDetails = await _context.OrderDetails
                                                 .Where(od => od.OrderId == orderId)
                                                 .ToListAsync();
                Console.WriteLine($"OrderDetails for OrderId {orderId}: Count = {orderDetails.Count}");
                foreach (var detail in orderDetails)
                {
                    Console.WriteLine($"OrderDetail - ID: {detail.Id}, FoodItemId: {detail.FoodItemId}, Quantity: {detail.Quantity}, Price: {detail.Price}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging order details for OrderId {orderId}: {ex.Message}");
            }
        }

        // Delete an OrderDetail by OrderId and FoodItemId
        public async Task<bool> DeleteOrderDetailByOrderAndItemAsync(int orderId, int foodItemId)
        {
            try
            {
                var orderDetail = await _context.OrderDetails
                                                .FirstOrDefaultAsync(od => od.OrderId == orderId && od.FoodItemId == foodItemId);

                if (orderDetail != null)
                {
                    _context.OrderDetails.Remove(orderDetail);
                    await _context.SaveChangesAsync();
                    Console.WriteLine($"OrderDetail for OrderId {orderId} and FoodItemId {foodItemId} deleted successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"OrderDetail for OrderId {orderId} and FoodItemId {foodItemId} not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting OrderDetail by OrderId and FoodItemId: {ex.Message}");
                return false;
            }
        }

    }
}
