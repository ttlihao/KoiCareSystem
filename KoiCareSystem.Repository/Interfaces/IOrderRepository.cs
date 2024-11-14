using KoiCareSystem.BussinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystem.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetAllOrdersAsync();
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        Task<Order?> GetPendingOrderByAccountIdAsync(int accountId);
    }
}
