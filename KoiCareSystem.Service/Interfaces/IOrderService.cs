using KoiCareSystem.BussinessObject;
using System.Threading.Tasks;

namespace KoiCareSystem.Service.Interfaces
{
    public interface IOrderService
    {
      
        Task<Order> GetOrCreateOrderAsync(int accountId);

        Task AddOrderDetailAsync(int orderId, int itemId, int quantity, decimal price);
    }
}
