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

       
        public async Task UpdateOrderDetailAsync(OrderDetail updatedOrderDetail)
        {
            try
            {
                var existingOrderDetail = await _context.OrderDetails.FirstOrDefaultAsync(od => od.Id == updatedOrderDetail.Id);
                if (existingOrderDetail != null)
                {
                    existingOrderDetail.OrderId = updatedOrderDetail.OrderId;
                    existingOrderDetail.FoodItemId = updatedOrderDetail.FoodItemId;
                    existingOrderDetail.Price = updatedOrderDetail.Price;
                    existingOrderDetail.Quantity = updatedOrderDetail.Quantity;
                    existingOrderDetail.Total = updatedOrderDetail.Total;

                    await _context.SaveChangesAsync();
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
            try
            {
                var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(od => od.Id == id);
                if (orderDetail != null)
                {
                    
                    _context.OrderDetails.Remove(orderDetail);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine($"Order detail with ID {id} not found for deletion.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting order detail: {ex.Message}");
            }
        }
    }
}
